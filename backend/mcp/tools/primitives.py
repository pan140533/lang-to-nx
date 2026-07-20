"""
基本体素工具（便捷版）

每个工具生成一个完整的 C# Journal，创建独立的新部件。
适用于快速建模场景，AI Agent 可以单独调用。
"""
from __future__ import annotations

from backend.mcp.registry import mcp_tool
from backend.mcp.executor import execute_journal, generate_output_path
from backend.mcp.response import ToolResult, ToolError
from backend.journal.generator import JournalGenerator


def _build_plan(tool: str, params: dict, tag: str) -> dict:
    """执行一个工具调用（单步），生成完整部件"""
    steps = [
        {"tool": "new_document", "params": {}},
    ]
    # 体素需要额外的组合步骤
    if tool in ("block", "cylinder", "cone", "sphere", "torus"):
        # 体素不依赖草图，直接创建
        steps.append({"tool": tool, "params": params})
    elif tool in ("extrude",):
        # 拉伸需要先画草图
        sketch_params = {}
        if "start" in params:
            start = params.pop("start", 0.0)
            steps.append({"tool": "create_sketch_on_plane", "params": {}})
            steps.append({"tool": "draw_rectangle", "params": {
                "x": 0, "y": 0, "width": 50, "height": 50
            }})
            steps.append({"tool": "close_sketch", "params": {}})
            steps.append({"tool": "extrude_from", "params": {"start": start, "length": params.get("length", 50)}})
        else:
            steps.append({"tool": "create_sketch_on_plane", "params": {}})
            steps.append({"tool": "draw_rectangle", "params": {
                "x": 0, "y": 0, "width": 50, "height": 50
            }})
            steps.append({"tool": "close_sketch", "params": {}})
            steps.append({"tool": tool, "params": params})
    else:
        steps.append({"tool": tool, "params": params})

    # 只生成代码，不执行（调用方统一执行）
    gen = JournalGenerator(tag=tag)
    code = gen.generate(steps)
    jpath = gen.save_journal(code)
    return {"success": True, "code": code, "journal_path": jpath, "tag": tag, "steps": steps}


async def _execute_single_tool(tool: str, params: dict, tag: str = "") -> ToolResult:
    """执行单个工具的通用方法

    1. 构建 plan
    2. 生成 C# Journal
    3. 执行
    4. 返回结果
    """
    fname, _ = generate_output_path(tag=tag or tool)
    gen = JournalGenerator(tag=fname)

    # 根据工具类型构建对应的步骤列表
    steps = _build_steps_for_tool(tool, params)

    try:
        code = gen.generate(steps)
    except Exception as e:
        return ToolError("GENERATION_FAILED", f"代码生成失败: {str(e)}")

    jpath = gen.save_journal(code)
    result = execute_journal(code, tag=fname)

    if result["success"]:
        return ToolResult.success(
            data={
                "tool": tool,
                "params": params,
                "part_path": result["part_path"],
                "journal_path": result["journal_path"],
            },
            message=f"创建成功: {result['part_path']}",
        )
    else:
        return ToolError(
            "EXECUTION_FAILED",
            f"执行失败: {result['error']}",
            "检查 NX 安装和参数",
        )


def _build_steps_for_tool(tool: str, params: dict) -> list[dict]:
    """根据工具类型构建步骤列表"""
    # 始终从 new_document 开始
    steps = [{"tool": "new_document", "params": {}}]

    if tool == "block":
        # 块可以直接使用体素工具
        steps.append({"tool": "block", "params": params})

    elif tool == "cylinder":
        steps.append({"tool": "cylinder", "params": params})

    elif tool == "cone":
        steps.append({"tool": "cone", "params": params})

    elif tool == "sphere":
        steps.append({"tool": "sphere", "params": params})

    elif tool == "torus":
        steps.append({"tool": "torus", "params": params})

    elif tool == "revolve":
        # 旋转：画矩形截面 → 旋转
        w = params.get("width", 50)
        h = params.get("height", 100)
        steps.append({"tool": "create_sketch_on_plane", "params": {}})
        steps.append({"tool": "draw_rectangle", "params": {"x": 0, "y": 0, "width": w, "height": h}})
        steps.append({"tool": "close_sketch", "params": {}})
        steps.append({"tool": "revolve", "params": {"angle": params.get("angle", 360)}})

    else:
        steps.append({"tool": tool, "params": params})

    return steps


# ═════════════════════════════════════════════════════════════════════════
# MCP 工具定义
# ═════════════════════════════════════════════════════════════════════════


@mcp_tool(
    name="nx_create_block",
    description="创建一个方块/立方体模型，生成独立 .prt 文件",
    params={
        "length": {"type": "number", "description": "长度 (mm)", "default": 100},
        "width": {"type": "number", "description": "宽度 (mm)", "default": 100},
        "height": {"type": "number", "description": "高度 (mm)", "default": 100},
        "x": {"type": "number", "description": "原点X (mm)", "default": 0, "required": False},
        "y": {"type": "number", "description": "原点Y (mm)", "default": 0, "required": False},
        "z": {"type": "number", "description": "原点Z (mm)", "default": 0, "required": False},
    },
)
async def nx_create_block(
    length: float = 100, width: float = 100, height: float = 100,
    x: float = 0, y: float = 0, z: float = 0,
) -> ToolResult:
    return await _execute_single_tool("block", {
        "x": x, "y": y, "z": z,
        "length": length, "width": width, "height": height,
    }, tag="block")


@mcp_tool(
    name="nx_create_cylinder",
    description="创建一个圆柱体模型，生成独立 .prt 文件",
    params={
        "radius": {"type": "number", "description": "半径 (mm)", "default": 25},
        "height": {"type": "number", "description": "高度 (mm)", "default": 50},
        "x": {"type": "number", "description": "底面中心X (mm)", "default": 0, "required": False},
        "y": {"type": "number", "description": "底面中心Y (mm)", "default": 0, "required": False},
        "z": {"type": "number", "description": "底面中心Z (mm)", "default": 0, "required": False},
    },
)
async def nx_create_cylinder(
    radius: float = 25, height: float = 50,
    x: float = 0, y: float = 0, z: float = 0,
) -> ToolResult:
    return await _execute_single_tool("cylinder", {
        "x": x, "y": y, "z": z, "radius": radius, "height": height,
    }, tag="cylinder")


@mcp_tool(
    name="nx_create_cone",
    description="创建一个圆锥体模型，生成独立 .prt 文件",
    params={
        "radius": {"type": "number", "description": "底部半径 (mm)", "default": 20},
        "height": {"type": "number", "description": "高度 (mm)", "default": 50},
    },
)
async def nx_create_cone(radius: float = 20, height: float = 50) -> ToolResult:
    return await _execute_single_tool("cone", {
        "radius": radius, "height": height,
    }, tag="cone")


@mcp_tool(
    name="nx_create_sphere",
    description="创建一个球体模型，生成独立 .prt 文件",
    params={
        "radius": {"type": "number", "description": "半径 (mm)", "default": 25},
        "x": {"type": "number", "description": "中心X (mm)", "default": 0, "required": False},
        "y": {"type": "number", "description": "中心Y (mm)", "default": 0, "required": False},
        "z": {"type": "number", "description": "中心Z (mm)", "default": 0, "required": False},
    },
)
async def nx_create_sphere(
    radius: float = 25,
    x: float = 0, y: float = 0, z: float = 0,
) -> ToolResult:
    return await _execute_single_tool("sphere", {
        "x": x, "y": y, "z": z, "radius": radius,
    }, tag="sphere")


@mcp_tool(
    name="nx_create_torus",
    description="创建一个圆环体模型，生成独立 .prt 文件",
    params={
        "major_radius": {"type": "number", "description": "主半径（环中心到管中心的距离）(mm)", "default": 50},
        "minor_radius": {"type": "number", "description": "次半径（管的半径）(mm)", "default": 10},
    },
)
async def nx_create_torus(major_radius: float = 50, minor_radius: float = 10) -> ToolResult:
    return await _execute_single_tool("torus", {
        "major_radius": major_radius, "minor_radius": minor_radius,
    }, tag="torus")
