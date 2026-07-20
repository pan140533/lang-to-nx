"""
MCP 工具的执行引擎

每个 MCP 工具的 handler 不直接调 NXOpen API，而是：
  1. 把工具调用转为 JSON tool_calls
  2. 交给 JournalGenerator 生成 C# 代码
  3. 通过 subprocess 调 run_journal.exe 执行
  4. 返回结果

这样既保持了 MCP 协议层，又满足了"外部进程执行"的要求。
"""
from __future__ import annotations

import json
import os
import subprocess
import time
import uuid
from pathlib import Path
from typing import Any

from backend.config import config
from backend.mcp.response import ToolResult, ToolError


# ── 会话状态（每个 session 追踪当前 part 文件） ──
_sessions: dict[str, dict[str, Any]] = {}


def _new_session_id() -> str:
    return uuid.uuid4().hex[:12]


def create_session() -> str:
    """创建一个新会话，返回 session_id"""
    sid = _new_session_id()
    _sessions[sid] = {
        "part_path": None,
        "created_at": time.time(),
        "file_name": None,
    }
    return sid


def get_session(sid: str) -> dict[str, Any] | None:
    return _sessions.get(sid)


def set_session_part(sid: str, part_path: str) -> None:
    if sid in _sessions:
        _sessions[sid]["part_path"] = part_path


def generate_output_path(extension: str = ".prt", tag: str = "model") -> tuple[str, str]:
    """生成输出文件路径，返回 (文件名, 完整路径)"""
    config.ensure_dirs()
    timestamp = time.strftime("%Y_%m_%d_%H_%M_%S")
    fname = f"{timestamp}_{tag}_{uuid.uuid4().hex[:6]}"
    ext = extension if extension.startswith(".") else f".{extension}"
    full = os.path.join(config.output_dir, "models", fname + ext)
    return fname, full


def execute_journal(journal_cs_code: str, tag: str = "script") -> dict[str, Any]:
    """执行一段 C# Journal 代码

    流程:
      1. 保存 .cs 文件
      2. subprocess 调 run_journal.exe
      3. 解析输出
      4. 返回结果

    Args:
        journal_cs_code: 完整的 C# Journal 代码字符串
        tag: 脚本标签（用于文件名）

    Returns:
        {
            "success": bool,
            "output": str,        # NX 的输出
            "error": str,         # 错误信息（如果有）
            "journal_path": str,  # 生成的 .cs 文件路径
            "part_path": str,     # 生成的 .prt 文件路径（如果成功）
        }
    """
    config.ensure_dirs()

    # 1. 保存 .cs 文件
    script_dir = os.path.join(config.output_dir, "scripts")
    timestamp = time.strftime("%Y%m%d_%H%M%S")
    cs_filename = f"{timestamp}_{tag}_{uuid.uuid4().hex[:6]}.cs"
    cs_path = os.path.abspath(os.path.join(script_dir, cs_filename))

    # 确保脚本目录存在
    os.makedirs(script_dir, exist_ok=True)

    # 写文件（UTF-8 BOM，NX 编译器要求）
    with open(cs_path, "w", encoding="utf-8-sig") as f:
        f.write(journal_cs_code)

    # 2. 执行
    run_exe = config.run_journal_path
    if not os.path.exists(run_exe):
        return {
            "success": False,
            "output": "",
            "error": f"run_journal.exe 未找到: {run_exe}",
            "journal_path": cs_path,
            "part_path": "",
        }

    try:
        result = subprocess.run(
            [run_exe, cs_path],
            capture_output=True,
            text=True,
            timeout=180,
            encoding="gbk",
            errors="ignore",
        )

        stdout = result.stdout or ""
        stderr = result.stderr or ""

        # 3. 从输出中提取 .prt 路径
        part_path = ""
        for line in stdout.splitlines():
            line = line.strip()
            # 匹配 "Saved: path/to/file.prt" 或直接路径
            if ".prt" in line:
                # 提取 .prt 路径（可能在 "Saved: " 之后）
                idx = line.find(".prt")
                prt_end = idx + 4
                # 往回找到路径开始
                prt_start = line.rfind(" ", 0, idx) + 1
                if prt_start == 0:
                    prt_start = line.rfind(":", 0, idx) + 1
                candidate = line[prt_start:prt_end].strip().replace("\\", "/")
                if os.path.exists(candidate):
                    part_path = candidate
                    break
        # 如果 stdout 没找到，尝试从脚本目录推断
        if not part_path:
            base = os.path.splitext(cs_filename)[0]
            candidate = os.path.join(config.output_dir, "models", base + ".prt")
            if os.path.exists(candidate):
                part_path = candidate

        if result.returncode == 0:
            return {
                "success": True,
                "output": stdout,
                "error": stderr,
                "journal_path": cs_path,
                "part_path": part_path,
            }
        else:
            return {
                "success": False,
                "output": stdout,
                "error": stderr[:500],
                "journal_path": cs_path,
                "part_path": part_path,
            }

    except subprocess.TimeoutExpired:
        return {
            "success": False,
            "output": "",
            "error": f"执行超时（180秒）: {cs_path}",
            "journal_path": cs_path,
            "part_path": "",
        }
    except Exception as e:
        return {
            "success": False,
            "output": "",
            "error": f"执行异常: {str(e)}",
            "journal_path": cs_path,
            "part_path": "",
        }
