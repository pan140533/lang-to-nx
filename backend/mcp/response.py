"""
统一的响应类型

每个 MCP 工具返回 ToolResult（成功）或 ToolError（失败），
序列化为 JSON 文本供 MCP 协议传输。
"""
from __future__ import annotations

import json
from typing import Any


class ToolResult:
    """成功响应"""

    def __init__(self, data: dict[str, Any] | None = None, message: str = ""):
        self.data = data or {}
        self.message = message

    def to_text(self) -> str:
        return json.dumps({
            "status": "success",
            "message": self.message,
            "data": self.data,
        }, ensure_ascii=False, indent=2)

    @classmethod
    def success(cls, data: dict[str, Any] | None = None, message: str = "") -> "ToolResult":
        return cls(data=data, message=message)


class ToolError:
    """错误响应"""

    def __init__(self, error_code: str, message: str, suggestion: str = ""):
        self.error_code = error_code
        self.message = message
        self.suggestion = suggestion

    def to_text(self) -> str:
        return json.dumps({
            "status": "error",
            "error_code": self.error_code,
            "message": self.message,
            "suggestion": self.suggestion,
        }, ensure_ascii=False, indent=2)

    @classmethod
    def from_exception(cls, exc: Exception, context: str = "") -> "ToolError":
        return cls(
            error_code="NX_EXECUTION_ERROR",
            message=f"{context}: {str(exc)}" if context else str(exc),
            suggestion="检查 NX 安装和路径配置",
        )
