"""
核心执行工具

提供 plan 级别的执行入口，是所有工具的底层执行引擎。

nx_execute_plan:
  接收一个完整的工具调用列表（plan），生成一条 C# Journal 并执行。
  这是最核心的工具 — 无论是 agent pipeline 的输出，还是单个工具的调用，
  最终都汇总到这里统一执行。
"""
from __future__ import annotations

import json
from typing import Any

from backend.mcp.registry import mcp_tool
from backend.mcp.executor import execute_journal, generate_output_path
from backend.mcp.response import ToolResult, ToolError
from backend.journal.generator import JournalGenerator


@mcp_tool(
    name="nx_execute_plan",
    description=(
        "执行一组建模步骤。这是最核心的工具——接收一个工具调用列表，"
        "生成完整的 C# Journal 并通过 run_journal.exe 在 NX 中执行。"
        "每个步骤包含 tool 名称和 params 参数。"
    ),
    params={
        "steps": {
            "type": "array",
            "description": "建模步骤列表，每步包含 tool 和 params",
            "items": {
                "type": "object",
                "properties": {
                    "tool": {"type": "string", "description": "工具名称"},
                    "params": {"type": "object", "description": "工具参数"},
                },
                "required": ["tool"],
            },
        },
        "description": {
            "type": "string",
            "description": "模型描述（用于输出文件名）",
            "required": False,
        },
    },
)
async def nx_execute_plan(steps: list[dict], description: str = "") -> ToolResult:
    """执行一组建模步骤

    这是所有工具的底层执行入口。接收一个工具调用列表，
    生成 C# Journal，通过 run_journal.exe 在 NX 中执行。

    Args:
        steps: 建模步骤列表，如 [{"tool": "cylinder", "params": {"radius": 25, "height": 50}}, ...]
        description: 模型描述，用于生成文件名

    Returns:
        ToolResult: 包含生成的 .prt 文件路径等信息
    """
    if not steps:
        return ToolError("EMPTY_PLAN", "步骤列表为空", "请提供至少一个工具调用")

    # 1. 确保所有 plan 都从 new_document 开始
    if steps[0].get("tool") not in ("new_document", "create_sketch_on_plane"):
        steps = [{"tool": "new_document", "params": {}}] + steps

    # 2. 生成文件名
    tag = "model"
    if description:
        # 取描述前几个 ASCII 字符
        ascii_chars = [c for c in description if 32 <= ord(c) < 127]
        if ascii_chars:
            tag = "".join(ascii_chars).strip().replace(" ", "_")[:16]
    fname, _ = generate_output_path(tag=tag)

    # 3. 生成 C# Journal
    gen = JournalGenerator(tag=fname)
    try:
        code = gen.generate(steps)
    except Exception as e:
        return ToolError(
            "GENERATION_FAILED",
            f"Journal 生成失败: {str(e)}",
            "检查工具名称和参数是否正确",
        )

    # 4. 保存并执行
    jpath = gen.save_journal(code)
    result = execute_journal(code, tag=fname)

    if result["success"]:
        return ToolResult.success(
            data={
                "part_path": result["part_path"],
                "journal_path": result["journal_path"],
                "output": result["output"][:500] if result["output"] else "",
                "steps_count": len(steps),
            },
            message=f"模型生成成功: {result['part_path']}",
        )
    else:
        return ToolError(
            "EXECUTION_FAILED",
            f"NX 执行失败: {result['error']}",
            "检查 NX 安装和工具参数",
        )


@mcp_tool(
    name="nx_validate_plan",
    description="验证一组建模步骤是否合法（不执行，只检查）",
    params={
        "steps": {
            "type": "array",
            "description": "要验证的建模步骤列表",
            "items": {
                "type": "object",
                "properties": {
                    "tool": {"type": "string", "description": "工具名称"},
                    "params": {"type": "object", "description": "工具参数"},
                },
                "required": ["tool"],
            },
        },
    },
)
async def nx_validate_plan(steps: list[dict]) -> ToolResult:
    """验证一组步骤是否合法"""
    errors = []
    gen = JournalGenerator()

    for i, step in enumerate(steps):
        tool = step.get("tool", "")
        method_name = f"_gen_{tool}"
        method = getattr(gen, method_name, None)
        if method is None:
            errors.append(f"步骤 {i+1}: 未知工具 '{tool}'")
            continue
        try:
            method(step.get("params", {}))
        except Exception as e:
            errors.append(f"步骤 {i+1} ({tool}): 参数错误 - {str(e)}")

    if errors:
        return ToolResult.success(
            data={
                "valid": False,
                "errors": errors,
                "total_steps": len(steps),
            },
            message=f"发现 {len(errors)} 个问题",
        )
    else:
        return ToolResult.success(
            data={
                "valid": True,
                "errors": [],
                "total_steps": len(steps),
            },
            message=f"全部 {len(steps)} 个步骤验证通过",
        )
