"""
C# Journal 脚本生成器

将 JSON 格式的工具调用列表转换为完整的 C# Journal 脚本，
通过 nx_modeler.cs 中固定的 NXOpen API 封装来执行。

架构：
  JSON tool_calls → generator.py → .cs 文件 → run_journal.exe → NX

数据流：
  [{"tool": "block", "params": {...}}, ...]
    → _gen_block() 生成 "m.Tool_Block(...);"
    → 拼装为完整 C# 脚本（using + class NXJournal + class NXModeler）
    → 保存 .cs 文件 → run_journal.exe 执行
"""
from __future__ import annotations

import os
import uuid
from pathlib import Path
from typing import Any

from backend.config import config


class JournalGenerator:
    """Journal 脚本生成器

    用法:
        gen = JournalGenerator()
        code = gen.generate(tool_calls)  # tool_calls = [{"tool": "block", "params": {...}}, ...]
        path = gen.save_journal(code)
    """

    def __init__(self, tag: str = ""):
        self.tag = tag or f"mcp_{uuid.uuid4().hex[:8]}"
        self._refs: dict[str, str] = {}

    # ═══════════════════════════════════════════════════════════════════════
    # 核心方法
    # ═══════════════════════════════════════════════════════════════════════

    def generate(self, steps: list[dict]) -> str:
        """将工具调用列表转为 C# 代码字符串"""
        # 1. 读取 nx_modeler.cs 类体
        modeler_body = self._load_modeler_body()

        # 2. 生成步骤调用
        step_lines = []
        step_lines.append("using System;")
        step_lines.append("using System.Collections.Generic;")
        step_lines.append("using NXOpen;")
        step_lines.append("using NXOpen.Features;")
        step_lines.append("using NXOpen.GeometricUtilities;")
        step_lines.append("")
        step_lines.append("public class NXJournal")
        step_lines.append("{")
        step_lines.append("  public static void Main(string[] args)")
        step_lines.append("  {")
        step_lines.append("    NXModeler m = new NXModeler();")
        step_lines.append("    m.Init();")
        step_lines.append("    m.outPath = @\"" + config.output_dir.replace("\\", "\\\\") + "\";")
        step_lines.append("")

        for i, step in enumerate(steps):
            tool = step.get("tool", "")
            params = step.get("params", {})
            method_name = f"_gen_{tool}"
            method = getattr(self, method_name, None)
            if method is None:
                step_lines.append(f"    // ? 跳过未实现: {tool}")
                continue

            step_lines.append(f"    // 步骤 {i+1}: {tool}")
            try:
                call_line = method(params)
                if call_line:
                    step_lines.append(call_line)
            except Exception as e:
                step_lines.append(f"    // ! 生成失败: {e}")

        # 保存（使用配置中的输出目录）
        step_lines.append("")
        output_models = os.path.join(config.output_dir, "models")
        os.makedirs(output_models, exist_ok=True)
        part_path = os.path.join(output_models, f"{self.tag}.prt").replace("\\", "\\\\")
        step_lines.append(f'    m.Tool_SaveModel(@"{part_path}");')
        step_lines.append("  }")
        step_lines.append("}")
        step_lines.append("")

        return "\n".join(step_lines) + "\n" + modeler_body

    def save_journal(self, code: str) -> str:
        """保存 .cs 文件，返回完整路径"""
        script_dir = os.path.join(config.output_dir, "scripts")
        os.makedirs(script_dir, exist_ok=True)
        cs_path = os.path.join(script_dir, f"journal_{self.tag}.cs")
        with open(cs_path, "w", encoding="utf-8-sig") as f:
            f.write(code)
        return os.path.abspath(cs_path)

    def _load_modeler_body(self) -> str:
        """加载 nx_modeler.cs 中的 NXModeler 类体"""
        modeler_path = Path(__file__).parent / "nx_modeler.cs"
        if not modeler_path.exists():
            return "public class NXModeler { public void Init() {} public string outPath; public void Tool_SaveModel(string p) {} }"

        lines = modeler_path.read_text(encoding="utf-8").split("\n")
        # 去掉 using 和注释头，只保留 public class NXModeler 及之后
        body_lines = []
        in_class = False
        for line in lines:
            if not in_class:
                if line.strip().startswith("public class NXModeler"):
                    in_class = True
                    body_lines.append(line)
                continue
            body_lines.append(line)
        return "\n".join(body_lines)

    # ═══════════════════════════════════════════════════════════════════════
    # 文档操作
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_new_document(self, p: dict) -> str:
        return f'    m.Tool_NewDocument("{self.tag}");'

    def _gen_save_model(self, p: dict) -> str:
        path = p.get("path", "")
        if path:
            safe = path.replace("\\", "\\\\")
            return f'    m.Tool_SaveModel(@"{safe}");'
        return ""

    # ═══════════════════════════════════════════════════════════════════════
    # 草图操作
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_create_sketch(self, p: dict) -> str:
        return "    m.Tool_CreateSketch();"

    def _gen_create_sketch_on_plane(self, p: dict) -> str:
        return "    m.Tool_CreateSketch();"

    def _gen_create_sketch_on_face(self, p: dict) -> str:
        fi = p.get("face_index", 0)
        return f"    m.Tool_CreateSketchOnFace({int(fi)});"

    def _gen_close_sketch(self, p: dict) -> str:
        return "    m.Tool_CloseSketch();"

    # ═══════════════════════════════════════════════════════════════════════
    # 绘图工具
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_draw_circle(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0); r = p.get("radius", 10.0)
        return f"    m.Tool_DrawCircle({float(x)}, {float(y)}, {float(r)});"

    def _gen_draw_closed_circle(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0); r = p.get("radius", 10.0)
        return f"    m.Tool_DrawCircle({float(x)}, {float(y)}, {float(r)});"

    def _gen_draw_arc(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0); r = p.get("radius", 10.0)
        sa = p.get("start_angle", 0.0); ea = p.get("end_angle", 90.0)
        return f"    m.Tool_DrawArc({float(x)}, {float(y)}, {float(r)}, {float(sa)}, {float(ea)});"

    def _gen_draw_rectangle(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0)
        w = p.get("width", 100.0); h = p.get("height", 60.0)
        return f"    m.Tool_DrawRectangle({float(x)}, {float(y)}, {float(w)}, {float(h)});"

    def _gen_draw_line(self, p: dict) -> str:
        x1 = p.get("x1", 0.0); y1 = p.get("y1", 0.0)
        x2 = p.get("x2", 50.0); y2 = p.get("y2", 0.0)
        return f"    m.Tool_DrawLine({float(x1)}, {float(y1)}, {float(x2)}, {float(y2)});"

    def _gen_draw_polyline(self, p: dict) -> str:
        pts = p.get("points", [])
        if not pts:
            return "    // ! 多段线缺少点数据"
        pts_str = ", ".join([f"new Point3d({float(pt[0])}, {float(pt[1])}, 0)" for pt in pts])
        return f"    m.Tool_DrawPolyline(new Point3d[]{{{pts_str}}});"

    def _gen_draw_spline(self, p: dict) -> str:
        pts = p.get("points", [])
        if not pts:
            return "    // ! 样条曲线缺少点数据"
        pts_str = ", ".join([f"new Point3d({float(pt[0])}, {float(pt[1])}, 0)" for pt in pts])
        return f"    m.Tool_DrawSpline(new Point3d[]{{{pts_str}}});"

    # ═══════════════════════════════════════════════════════════════════════
    # 基本体素
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_block(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0); z = p.get("z", 0.0)
        l = p.get("length", 100.0); w = p.get("width", 100.0); h = p.get("height", 100.0)
        return f"    m.Tool_Block({float(x)}, {float(y)}, {float(z)}, {float(l)}, {float(w)}, {float(h)});"

    def _gen_cylinder(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0); z = p.get("z", 0.0)
        r = p.get("radius", 25.0); h = p.get("height", 50.0)
        return f"    m.Tool_Cylinder({float(x)}, {float(y)}, {float(z)}, {float(r)}, {float(h)});"

    def _gen_cone(self, p: dict) -> str:
        r = p.get("radius", 20.0); h = p.get("height", 50.0)
        return f"    m.Tool_Cone({float(r)}, {float(h)});"

    def _gen_sphere(self, p: dict) -> str:
        r = p.get("radius", 25.0)
        return f"    m.Tool_Sphere({float(r)});"

    def _gen_torus(self, p: dict) -> str:
        major = p.get("major_radius", 50.0)
        minor = p.get("minor_radius", 10.0)
        return f"    m.Tool_Torus({float(major)}, {float(minor)});"

    # ═══════════════════════════════════════════════════════════════════════
    # 扫描特征
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_extrude(self, p: dict) -> str:
        length = p.get("length", 10.0)
        return f"    m.Tool_Extrude({float(length)});"

    def _gen_extrude_from(self, p: dict) -> str:
        start = p.get("start", 0.0); length = p.get("length", 10.0)
        return f"    m.Tool_ExtrudeFrom({float(start)}, {float(length)});"

    def _gen_extrude_cut(self, p: dict) -> str:
        length = p.get("length", 10.0)
        return f"    m.Tool_ExtrudeCut({float(length)});"

    def _gen_revolve(self, p: dict) -> str:
        angle = p.get("angle", 360.0)
        return f"    m.Tool_Revolve({float(angle)});"

    def _gen_sweep(self, p: dict) -> str:
        pts = p.get("path_points", [])
        if not pts:
            return "    // ! 扫掠缺少路径点"
        pts_str = ", ".join([f"new Point3d({float(pt[0])}, {float(pt[1])}, {float(pt[2])})" for pt in pts])
        return f"    m.Tool_Sweep(new Point3d[]{{{pts_str}}});"

    def _gen_loft(self, p: dict) -> str:
        sections = p.get("sections", [])
        if not sections:
            return "    // ! 放样缺少截面"
        refs_str = ", ".join([f'"{ref}"' for ref in sections])
        return f"    m.Tool_Loft(new string[]{{{refs_str}}});"

    # ═══════════════════════════════════════════════════════════════════════
    # 布尔操作
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_boolean_unite(self, p: dict) -> str:
        return f'    m.Tool_BooleanUnite("{p.get("target_body", "")}", "{p.get("tool_body", "")}");'

    def _gen_boolean_subtract(self, p: dict) -> str:
        return f'    m.Tool_BooleanSubtract("{p.get("target_body", "")}", "{p.get("tool_body", "")}");'

    def _gen_boolean_intersect(self, p: dict) -> str:
        return f'    m.Tool_BooleanIntersect("{p.get("target_body", "")}", "{p.get("tool_body", "")}");'

    # ═══════════════════════════════════════════════════════════════════════
    # 细节特征
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_chamfer(self, p: dict) -> str:
        return f"    m.Tool_Chamfer({float(p.get('length', 2.0))});"

    def _gen_fillet(self, p: dict) -> str:
        return f"    m.Tool_Fillet({float(p.get('radius', 5.0))});"

    def _gen_edge_blend(self, p: dict) -> str:
        r = p.get("radius", 5.0)
        edges = p.get("edge_indices", [])
        if not edges:
            return f"    m.Tool_Fillet({float(r)});"
        es = ", ".join([str(int(e)) for e in edges])
        return f"    m.Tool_EdgeBlend({float(r)}, new int[]{{{es}}});"

    def _gen_shell(self, p: dict) -> str:
        t = p.get("thickness", 2.0); fi = p.get("remove_face_index", -1)
        return f"    m.Tool_Shell({float(t)}, {int(fi)});"

    def _gen_hole(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0)
        d = p.get("diameter", 10.0); dp = p.get("depth", 20.0)
        ht = p.get("hole_type", "simple")
        return f'    m.Tool_Hole({float(x)}, {float(y)}, {float(d)}, {float(dp)}, "{ht}");'

    def _gen_pocket(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0)
        l = p.get("length", 50.0); w = p.get("width", 30.0); d = p.get("depth", 10.0)
        return f"    m.Tool_Pocket({float(x)}, {float(y)}, {float(l)}, {float(w)}, {float(d)});"

    def _gen_boss(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0)
        d = p.get("diameter", 20.0); h = p.get("height", 30.0)
        return f"    m.Tool_Boss({float(x)}, {float(y)}, {float(d)}, {float(h)});"

    def _gen_pad(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0)
        l = p.get("length", 40.0); w = p.get("width", 20.0); h = p.get("height", 15.0)
        return f"    m.Tool_Pad({float(x)}, {float(y)}, {float(l)}, {float(w)}, {float(h)});"

    def _gen_slot(self, p: dict) -> str:
        x = p.get("x", 0.0); y = p.get("y", 0.0)
        l = p.get("length", 60.0); w = p.get("width", 10.0); d = p.get("depth", 5.0)
        return f"    m.Tool_Slot({float(x)}, {float(y)}, {float(l)}, {float(w)}, {float(d)});"

    def _gen_groove(self, p: dict) -> str:
        d = p.get("diameter", 30.0); w = p.get("width", 5.0); dp = p.get("depth", 3.0)
        return f"    m.Tool_Groove({float(d)}, {float(w)}, {float(dp)});"

    def _gen_thread(self, p: dict) -> str:
        ref = p.get("cylinder_ref", ""); tp = p.get("thread_type", "metric"); l = p.get("length", 20.0)
        return f'    m.Tool_Thread("{ref}", "{tp}", {float(l)});'

    def _gen_pattern_linear(self, p: dict) -> str:
        ref = p.get("feature_ref", "")
        cx = p.get("count_x", 2); sx = p.get("spacing_x", 50.0)
        cy = p.get("count_y", 1); sy = p.get("spacing_y", 0.0)
        return f'    m.Tool_PatternLinear("{ref}", {int(cx)}, {float(sx)}, {int(cy)}, {float(sy)});'

    def _gen_pattern_circular(self, p: dict) -> str:
        ref = p.get("feature_ref", ""); cnt = p.get("count", 6); a = p.get("angle", 360.0)
        return f'    m.Tool_PatternCircular("{ref}", {int(cnt)}, {float(a)});'

    def _gen_mirror_feature(self, p: dict) -> str:
        ref = p.get("feature_ref", ""); pl = p.get("mirror_plane", "YZ")
        return f'    m.Tool_MirrorFeature("{ref}", "{pl}");'

    # ═══════════════════════════════════════════════════════════════════════
    # 曲面建模
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_through_curves(self, p: dict) -> str:
        sections = p.get("sections", [])
        if not sections:
            return "    // ! 通过曲线组缺少截面"
        rs = ", ".join([f'"{r}"' for r in sections])
        return f"    m.Tool_ThroughCurves(new string[]{{{rs}}});"

    def _gen_through_curve_mesh(self, p: dict) -> str:
        pri = p.get("primary_curves", []); cross = p.get("cross_curves", [])
        if not pri or not cross:
            return "    // ! 通过曲线网格缺少曲线"
        ps = ", ".join([f'"{r}"' for r in pri]); cs = ", ".join([f'"{r}"' for r in cross])
        return f"    m.Tool_ThroughCurveMesh(new string[]{{{ps}}}, new string[]{{{cs}}});"

    def _gen_ruled(self, p: dict) -> str:
        return f'    m.Tool_Ruled("{p.get("curve1_ref", "")}", "{p.get("curve2_ref", "")}");'

    def _gen_bounded_plane(self, p: dict) -> str:
        curves = p.get("boundary_curves", [])
        if not curves:
            return "    // ! 有界平面缺少边界曲线"
        rs = ", ".join([f'"{r}"' for r in curves])
        return f"    m.Tool_BoundedPlane(new string[]{{{rs}}});"

    def _gen_fill_surface(self, p: dict) -> str:
        curves = p.get("boundary_curves", [])
        if not curves:
            return "    // ! 填充曲面缺少边界曲线"
        rs = ", ".join([f'"{r}"' for r in curves])
        return f"    m.Tool_FillSurface(new string[]{{{rs}}});"

    def _gen_offset_surface(self, p: dict) -> str:
        return f'    m.Tool_OffsetSurface("{p.get("face_ref", "")}", {float(p.get("distance", 5.0))});'

    def _gen_extension(self, p: dict) -> str:
        return f'    m.Tool_Extension("{p.get("face_ref", "")}", "{p.get("edge_ref", "")}", {float(p.get("length", 10.0))});'

    def _gen_trim_surface(self, p: dict) -> str:
        face = p.get("face_ref", ""); curves = p.get("boundary_curves", [])
        if not curves:
            return "    // ! 修剪曲面缺少边界曲线"
        rs = ", ".join([f'"{r}"' for r in curves])
        return f'    m.Tool_TrimSurface("{face}", new string[]{{{rs}}});'

    def _gen_face_blend(self, p: dict) -> str:
        f1 = p.get("face1_ref", ""); f2 = p.get("face2_ref", ""); r = p.get("radius", 10.0)
        return f'    m.Tool_FaceBlend("{f1}", "{f2}", {float(r)});'

    # ═══════════════════════════════════════════════════════════════════════
    # 变换操作
    # ═══════════════════════════════════════════════════════════════════════

    def _gen_translate(self, p: dict) -> str:
        dx = p.get("dx", 0.0); dy = p.get("dy", 0.0); dz = p.get("dz", 0.0)
        return f"    m.Tool_Translate({float(dx)}, {float(dy)}, {float(dz)});"

    def _gen_rotate(self, p: dict) -> str:
        axis = p.get("axis", "Z"); angle = p.get("angle", 90.0)
        return f"    m.Tool_Rotate({float(angle)}, \"{axis}\");"

    def _gen_scale(self, p: dict) -> str:
        return f"    m.Tool_Scale({float(p.get('factor', 1.0))});"
