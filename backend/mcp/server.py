"""
MCP Server — 通过 stdio 传输层与 AI Agent 通信

每个工具 handler 不直接调用 NXOpen API，而是：
  生成 C# Journal → run_journal.exe（外部进程）→ 返回结果

这确保了：
  - NX 不需要持续打开（用完即退）
  - 不会在 NX 进程内跑重型 Python
  - 适合批量建模场景
"""
from __future__ import annotations

import asyncio
import importlib
import json
import logging
import pkgutil
import sys
from typing import Any

from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp.types import TextContent, Tool

from backend.mcp.registry import ToolRegistry
from backend.mcp.response import ToolError, ToolResult

logger = logging.getLogger("lang-to-nx-mcp")


def _discover_tools() -> None:
    """自动发现所有工具模块（在 tools/ 目录下）"""
    import backend.mcp.tools as tools_pkg

    for _importer, modname, _ispkg in pkgutil.iter_modules(tools_pkg.__path__):
        if modname == "registry" or modname.startswith("_"):
            continue
        full_name = f"{tools_pkg.__name__}.{modname}"
        try:
            importlib.import_module(full_name)
            logger.info("发现工具模块: %s", full_name)
        except Exception as e:
            logger.error("导入工具模块失败 %s: %s", full_name, e)


def create_server() -> Server:
    """创建 MCP Server"""
    _discover_tools()

    server = Server("lang-to-nx-mcp")

    @server.list_tools()
    async def list_tools() -> list[Tool]:
        tools = []
        for t in ToolRegistry.list_tools():
            tools.append(
                Tool(
                    name=t["name"],
                    description=t["description"],
                    inputSchema=t["inputSchema"],
                )
            )
        return tools

    @server.call_tool()
    async def call_tool_handler(name: str, arguments: dict[str, Any]) -> list[TextContent]:
        result = await _call_tool(name, arguments)
        return result

    return server


async def _call_tool(name: str, arguments: dict[str, Any]) -> list[TextContent]:
    """派发工具调用"""
    handler = ToolRegistry.get_handler(name)
    if handler is None:
        error = ToolError(
            error_code="TOOL_NOT_FOUND",
            message=f"未知工具: {name}",
            suggestion=f"可用工具: {', '.join(ToolRegistry.get_tool_names())}",
        )
        return [TextContent(type="text", text=error.to_text())]

    try:
        result = await handler(**arguments)
        if isinstance(result, str):
            text = result
        elif isinstance(result, (ToolResult, ToolError)):
            text = result.to_text()
        elif isinstance(result, dict):
            text = json.dumps(result, indent=2, ensure_ascii=False)
        else:
            text = str(result)
        return [TextContent(type="text", text=text)]
    except Exception as exc:
        error = ToolError(
            error_code="EXECUTION_ERROR",
            message=str(exc),
            suggestion="检查 NX 安装路径和配置文件",
        )
        return [TextContent(type="text", text=error.to_text())]


async def async_main() -> None:
    """启动 MCP Server（stdio 传输）"""
    logging.basicConfig(
        level=logging.INFO,
        format="%(asctime)s [%(name)s] %(levelname)s: %(message)s",
        stream=sys.stderr,
    )

    server = create_server()
    logger.info("Lang-to-NX MCP Server 启动 (stdio 传输)")

    async with stdio_server() as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options(),
        )


def main() -> None:
    """入口点"""
    asyncio.run(async_main())


if __name__ == "__main__":
    main()
