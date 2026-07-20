#!/usr/bin/env python
"""
Lang-to-NX MCP — 启动入口

用法:
  python run.py                  # 启动 MCP Server (stdio)
  python run.py --api            # 启动 FastAPI Server (HTTP)
  python run.py --list-tools     # 列出所有注册的工具
"""
from __future__ import annotations

import argparse
import os
import sys
from pathlib import Path

# 确保 backend 在 Python path 中
sys.path.insert(0, str(Path(__file__).parent))


def run_mcp():
    """启动 MCP Server（stdio 传输，供 AI Agent 连接）"""
    from backend.mcp.server import async_main
    import asyncio
    asyncio.run(async_main())


def run_api():
    """启动 FastAPI Server（HTTP 传输，供前端连接）"""
    import uvicorn
    from backend.config import config
    print(f"启动 FastAPI Server: http://{config.host}:{config.port}")
    uvicorn.run("backend.api:app", host=config.host, port=config.port, reload=True)


def list_tools():
    """列出所有已注册的 MCP 工具"""
    from backend.mcp.registry import ToolRegistry
    from backend.mcp.server import _discover_tools

    _discover_tools()
    tools = ToolRegistry.list_tools()
    print(f"\n已注册 {len(tools)} 个 MCP 工具:\n")
    for t in sorted(tools, key=lambda x: x["name"]):
        print(f"  {t['name']}")
        print(f"    描述: {t['description'][:80]}")
        params = t.get("inputSchema", {}).get("properties", {})
        if params:
            print(f"    参数: {', '.join(params.keys())}")
        print()


def main():
    parser = argparse.ArgumentParser(description="Lang-to-NX MCP")
    parser.add_argument("--api", action="store_true", help="启动 FastAPI Server（HTTP）")
    parser.add_argument("--list-tools", action="store_true", help="列出所有工具")
    args = parser.parse_args()

    # 加载 .env
    from dotenv import load_dotenv
    env_path = Path(__file__).parent / ".env"
    if env_path.exists():
        load_dotenv(env_path)
        print(f"已加载配置: {env_path}")

    if args.api:
        run_api()
    elif args.list_tools:
        list_tools()
    else:
        # 验证配置
        from backend.config import config
        errors = config.validate()
        if errors:
            print("⚠️  配置检查发现以下问题:")
            for e in errors:
                print(f"  - {e}")
            print("请检查 .env 文件或环境变量\n")

        run_mcp()


if __name__ == "__main__":
    main()
