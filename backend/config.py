"""
配置管理

从 .env 或环境变量加载，提供所有 NX 相关路径。
支持两种 NX 执行方式：
  1. run_journal.exe（外部进程，批量场景）
  2. NXOpen Python API（进程内交互场景，可选）
"""
from __future__ import annotations

import os
from dataclasses import dataclass, field
from pathlib import Path
from typing import Optional


def _env(key: str, default: str = "") -> str:
    return os.environ.get(key, default)


@dataclass
class Config:
    # ── NX Installation ──
    nx_root: str = field(default_factory=lambda: _env("NX_ROOT", r"C:\Program Files\Siemens\NX"))
    nx_version: str = field(default_factory=lambda: _env("NX_VERSION", "2412"))

    # ── NX Execution ──
    run_journal_exe: str = field(init=False)
    nx_exe: str = field(default_factory=lambda: _env("NX_EXE", ""))  # fallback

    def __post_init__(self):
        default_exe = os.path.join(self.nx_root, "NXBIN", "run_journal.exe")
        self.run_journal_exe = _env("RUN_JOURNAL_EXE", default_exe)

    @property
    def run_journal_path(self) -> str:
        return self.run_journal_exe

    # ── Output ──
    output_dir: str = field(default_factory=lambda: _env("OUTPUT_DIR", os.path.join(Path(__file__).parent.parent, "output")))

    # ── LLM (optional, for agent pipeline) ──
    llm_api_key: str = field(default_factory=lambda: _env("LLM_API_KEY", ""))
    llm_base_url: str = field(default_factory=lambda: _env("LLM_BASE_URL", "https://api.deepseek.com"))
    llm_model: str = field(default_factory=lambda: _env("LLM_MODEL", "deepseek-chat"))
    llm_temperature: float = float(_env("LLM_TEMPERATURE", "0.7"))

    # ── Server ──
    host: str = field(default_factory=lambda: _env("HOST", "127.0.0.1"))
    port: int = int(_env("PORT", "8000"))

    # ── C# Journal generation ──
    journal_template_path: str = field(default_factory=lambda: _env("JOURNAL_TEMPLATE_PATH", ""))

    def ensure_dirs(self):
        os.makedirs(self.output_dir, exist_ok=True)
        os.makedirs(os.path.join(self.output_dir, "models"), exist_ok=True)
        os.makedirs(os.path.join(self.output_dir, "scripts"), exist_ok=True)

    def validate(self) -> list[str]:
        errors: list[str] = []
        if not os.path.exists(self.run_journal_exe):
            errors.append(f"run_journal.exe 未找到: {self.run_journal_exe}")
        return errors


# ── Global singleton ──
config = Config()
