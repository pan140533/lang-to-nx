"""
工具注册装饰器和注册表

从 NX_MCP 移植，保持 MCP 协议兼容。
每个工具由 @mcp_tool 装饰器注册，自动发现。
"""
from __future__ import annotations

import json
from typing import Any, Callable, Coroutine


class _ToolDef:
    """单个 MCP 工具的定义"""

    def __init__(
        self,
        name: str,
        description: str,
        params: dict[str, dict[str, Any]],
        handler: Callable[..., Coroutine],
    ) -> None:
        self.name = name
        self.description = description
        self.params = params
        self.handler = handler

    def to_mcp_format(self) -> dict[str, Any]:
        """转换为 MCP 协议标准的 Tool 字典"""
        properties: dict[str, Any] = {}
        required: list[str] = []
        for pname, pdef in self.params.items():
            prop: dict[str, Any] = {
                "type": pdef.get("type", "string"),
                "description": pdef.get("description", ""),
            }
            # 枚举约束
            if "enum" in pdef:
                prop["enum"] = pdef["enum"]
            # 默认值
            if "default" in pdef:
                prop["default"] = pdef["default"]
            properties[pname] = prop
            if pdef.get("required", True):
                required.append(pname)

        return {
            "name": self.name,
            "description": self.description,
            "inputSchema": {
                "type": "object",
                "properties": properties,
                "required": required if required else None,
            },
        }


class ToolRegistry:
    """全局工具注册表（单例）"""

    _tools: dict[str, _ToolDef] = {}

    @classmethod
    def register(cls, tool_def: _ToolDef) -> None:
        cls._tools[tool_def.name] = tool_def

    @classmethod
    def list_tools(cls) -> list[dict[str, Any]]:
        return [t.to_mcp_format() for t in cls._tools.values()]

    @classmethod
    def get_handler(cls, name: str) -> Callable | None:
        tool = cls._tools.get(name)
        return tool.handler if tool else None

    @classmethod
    def get_tool_names(cls) -> list[str]:
        return list(cls._tools.keys())

    @classmethod
    def clear(cls) -> None:
        cls._tools.clear()


def mcp_tool(
    name: str,
    description: str,
    params: dict[str, dict[str, Any]] | None = None,
) -> Callable:
    """装饰器：将 async 函数注册为 MCP 工具

    用法:
        @mcp_tool(
            name="nx_create_block",
            description="创建方块",
            params={
                "length": {"type": "number", "description": "长度 (mm)"},
                "width": {"type": "number", "description": "宽度 (mm)"},
                "height": {"type": "number", "description": "高度 (mm)"},
            }
        )
        async def nx_create_block(length=100, width=100, height=50) -> ToolResult:
            ...
    """

    def decorator(func: Callable) -> Callable:
        tool_def = _ToolDef(
            name=name,
            description=description,
            params=params or {},
            handler=func,
        )
        ToolRegistry.register(tool_def)
        return func

    return decorator
