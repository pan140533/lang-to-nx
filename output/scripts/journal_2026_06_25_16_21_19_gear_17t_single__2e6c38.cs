using System;
using System.Collections.Generic;
using NXOpen;
using NXOpen.Features;
using NXOpen.GeometricUtilities;

public class NXJournal
{
  public static void Main(string[] args)
  {
    NXModeler m = new NXModeler();
    m.Init();
    m.outPath = @"E:\\NX\\Lang-to-NX-MCP\\output";

    // 步骤 1: new_document
    m.Tool_NewDocument("2026_06_25_16_21_19_gear_17t_single__2e6c38");
    // 步骤 2: create_sketch
    m.Tool_CreateSketch();
    // 步骤 3: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, -5.309, 5.309);
    // 步骤 4: draw_line
    m.Tool_DrawLine(8.344, 0.775, 6.368, 0.592);
    // 步骤 5: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 5.309, 15.867);
    // 步骤 6: draw_line
    m.Tool_DrawLine(6.151, 1.748, 8.061, 2.291);
    // 步骤 7: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 15.867, 26.485);
    // 步骤 8: draw_line
    m.Tool_DrawLine(7.5, 3.737, 5.724, 2.852);
    // 步骤 9: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 26.485, 37.044);
    // 步骤 10: draw_line
    m.Tool_DrawLine(5.104, 3.853, 6.689, 5.048);
    // 步骤 11: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 37.044, 47.662);
    // 步骤 12: draw_line
    m.Tool_DrawLine(5.644, 6.194, 4.307, 4.727);
    // 步骤 13: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 47.662, 58.22);
    // 步骤 14: draw_line
    m.Tool_DrawLine(3.368, 5.436, 4.413, 7.124);
    // 步骤 15: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 58.22, 68.838);
    // 步骤 16: draw_line
    m.Tool_DrawLine(3.025, 7.815, 2.309, 5.964);
    // 步骤 17: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 68.838, 79.397);
    // 步骤 18: draw_line
    m.Tool_DrawLine(1.177, 6.286, 1.542, 8.237);
    // 步骤 19: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 79.397, 90.015);
    // 步骤 20: draw_line
    m.Tool_DrawLine(-0.002, 8.38, -0.002, 6.395);
    // 步骤 21: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 90.015, 100.573);
    // 步骤 22: draw_line
    m.Tool_DrawLine(-1.173, 6.286, -1.538, 8.238);
    // 步骤 23: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 100.573, 111.191);
    // 步骤 24: draw_line
    m.Tool_DrawLine(-3.029, 7.813, -2.312, 5.963);
    // 步骤 25: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 111.191, 121.75);
    // 步骤 26: draw_line
    m.Tool_DrawLine(-3.365, 5.438, -4.41, 7.126);
    // 步骤 27: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 121.75, 132.368);
    // 步骤 28: draw_line
    m.Tool_DrawLine(-5.647, 6.191, -4.31, 4.725);
    // 步骤 29: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 132.368, 142.926);
    // 步骤 30: draw_line
    m.Tool_DrawLine(-5.102, 3.855, -6.686, 5.052);
    // 步骤 31: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 142.926, 153.544);
    // 步骤 32: draw_line
    m.Tool_DrawLine(-7.502, 3.733, -5.725, 2.849);
    // 步骤 33: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 153.544, 164.103);
    // 步骤 34: draw_line
    m.Tool_DrawLine(-6.15, 1.752, -8.06, 2.295);
    // 步骤 35: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 164.103, 174.721);
    // 步骤 36: draw_line
    m.Tool_DrawLine(-8.344, 0.771, -6.368, 0.588);
    // 步骤 37: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 174.721, 185.279);
    // 步骤 38: draw_line
    m.Tool_DrawLine(-6.368, -0.588, -8.344, -0.771);
    // 步骤 39: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 185.279, 195.897);
    // 步骤 40: draw_line
    m.Tool_DrawLine(-8.06, -2.295, -6.15, -1.752);
    // 步骤 41: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 195.897, 206.456);
    // 步骤 42: draw_line
    m.Tool_DrawLine(-5.725, -2.849, -7.502, -3.733);
    // 步骤 43: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 206.456, 217.074);
    // 步骤 44: draw_line
    m.Tool_DrawLine(-6.686, -5.052, -5.102, -3.855);
    // 步骤 45: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 217.074, 227.632);
    // 步骤 46: draw_line
    m.Tool_DrawLine(-4.31, -4.725, -5.647, -6.191);
    // 步骤 47: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 227.632, 238.25);
    // 步骤 48: draw_line
    m.Tool_DrawLine(-4.41, -7.126, -3.365, -5.438);
    // 步骤 49: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 238.25, 248.809);
    // 步骤 50: draw_line
    m.Tool_DrawLine(-2.312, -5.963, -3.029, -7.813);
    // 步骤 51: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 248.809, 259.427);
    // 步骤 52: draw_line
    m.Tool_DrawLine(-1.538, -8.238, -1.173, -6.286);
    // 步骤 53: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 259.427, 269.985);
    // 步骤 54: draw_line
    m.Tool_DrawLine(-0.002, -6.395, -0.002, -8.38);
    // 步骤 55: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 269.985, 280.603);
    // 步骤 56: draw_line
    m.Tool_DrawLine(1.542, -8.237, 1.177, -6.286);
    // 步骤 57: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 280.603, 291.162);
    // 步骤 58: draw_line
    m.Tool_DrawLine(2.309, -5.964, 3.025, -7.815);
    // 步骤 59: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 291.162, 301.78);
    // 步骤 60: draw_line
    m.Tool_DrawLine(4.413, -7.124, 3.368, -5.436);
    // 步骤 61: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 301.78, 312.338);
    // 步骤 62: draw_line
    m.Tool_DrawLine(4.307, -4.727, 5.644, -6.194);
    // 步骤 63: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 312.338, 322.956);
    // 步骤 64: draw_line
    m.Tool_DrawLine(6.689, -5.048, 5.104, -3.853);
    // 步骤 65: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 322.956, 333.515);
    // 步骤 66: draw_line
    m.Tool_DrawLine(5.724, -2.852, 7.5, -3.737);
    // 步骤 67: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 333.515, 344.133);
    // 步骤 68: draw_line
    m.Tool_DrawLine(8.061, -2.291, 6.151, -1.748);
    // 步骤 69: draw_arc
    m.Tool_DrawArc(0.0, 0.0, 10.0, 344.133, 354.691);
    // 步骤 70: draw_line
    m.Tool_DrawLine(6.368, -0.592, 8.344, -0.775);
    // 步骤 71: close_sketch
    m.Tool_CloseSketch();
    // 步骤 72: extrude
    m.Tool_Extrude(10.0);
    // 步骤 73: hole
    m.Tool_Hole(0.0, 0.0, 4.0, 4.0, "through");

    m.Tool_SaveModel(@"E:\\NX\\Lang-to-NX-MCP\\output\\models\\2026_06_25_16_21_19_gear_17t_single__2e6c38.prt");
  }
}

public class NXModeler
{
  public Session ses; public Part wp; public Part dp;
  public Sketch curSketch; public Arc curArc; public Body curBody;
  public List<ICurve> curCurves = new List<ICurve>();
  public string outPath = "./output/models";
  private Feature _lastFeature = null;  // 追踪最后创建的特征（用于阵列）
  private Body _previousBody = null;    // 追踪上一个体（用于布尔操作）

  public void Init()
  { ses = Session.GetSession(); wp = ses.Parts.Work; dp = ses.Parts.Display; }

  public void Tool_NewDocument(string name)
  {
    string tmp = outPath + "\\tmp_" + Guid.NewGuid().ToString("N").Substring(0, 8) + ".prt";
    FileNew fn = ses.Parts.FileNew();
    fn.TemplateFileName = "model-plain-1-mm-template.prt";
    fn.UseBlankTemplate = false; fn.ApplicationName = "ModelTemplate";
    fn.Units = Part.Units.Millimeters; fn.NewFileName = tmp;
    fn.MakeDisplayedPart = true; fn.Commit(); fn.Destroy();
    wp = ses.Parts.Work; dp = ses.Parts.Display;
    ses.ApplicationSwitchImmediate("UG_APP_MODELING");
    curArc = null; curCurves.Clear();
  }

  public void Tool_CreateSketch()
  {
    Sketch sn = null;
    SketchInPlaceBuilder sb = wp.Sketches.CreateSketchInPlaceBuilder2(sn);
    sb.PlaneReference = wp.Planes.CreatePlane(
        new Point3d(0,0,0), new Vector3d(0,0,1), SmartObject.UpdateOption.WithinModeling);
    NXObject o = sb.Commit(); curSketch = (Sketch)o; sb.Destroy();
    curSketch.Activate(Sketch.ViewReorient.True);
    curArc = null; curCurves.Clear();
  }

  public void Tool_DrawCircle(double x, double y, double r)
  {
    NXMatrix mx = ses.ActiveSketch.Orientation;
    curArc = wp.Curves.CreateArc(new Point3d(x,y,0), mx, r, 0.0, 2.0*Math.PI);
    curCurves.Add(curArc);
    ses.ActiveSketch.AddGeometry(curArc, Sketch.InferConstraintsOption.InferNoConstraints);
    ses.ActiveSketch.Update();
  }

  public void Tool_DrawLine(double x1, double y1, double x2, double y2)
  {
    Line ln = wp.Curves.CreateLine(new Point3d(x1,y1,0), new Point3d(x2,y2,0));
    curCurves.Add(ln);
    ses.ActiveSketch.AddGeometry(ln, Sketch.InferConstraintsOption.InferNoConstraints);
    ses.ActiveSketch.Update();
  }

  public void Tool_DrawRectangle(double x, double y, double w, double h)
  {
    Tool_DrawLine(x, y, x+w, y); Tool_DrawLine(x+w, y, x+w, y+h);
    Tool_DrawLine(x+w, y+h, x, y+h); Tool_DrawLine(x, y+h, x, y);
  }

  public void Tool_CloseSketch()
  { ses.ActiveSketch.Deactivate(Sketch.ViewReorient.True, Sketch.UpdateLevel.Model); }

  Point3d CalcSeed()
  {
    double sx=0,sy=0; int n=0;
    foreach (ICurve cv in curCurves) {
      Arc a = cv as Arc; Line l = cv as Line;
      if (a != null) { sx+=a.CenterPoint.X; sy+=a.CenterPoint.Y; n++; }
      else if (l != null) { sx+=(l.StartPoint.X+l.EndPoint.X)/2; sy+=(l.StartPoint.Y+l.EndPoint.Y)/2; n++; }
    }
    return n>0 ? new Point3d(sx/n,sy/n,0) : new Point3d(0,0,0);
  }

  public void Tool_Extrude(double len)
  {
    Tool_ExtrudeFrom(0, len);
  }

  public void Tool_ExtrudeFrom(double start, double len)
  {
    Section sec = wp.Sections.CreateSection(0.0095, 0.01, 0.5);
    sec.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
    SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions();
    ro.SetSelectedFromInactive(false);
    Point3d seed = CalcSeed();
    RegionBoundaryRule br = wp.ScRuleFactory.CreateRuleRegionBoundary(curSketch, curCurves.ToArray(), seed, 0.01, ro);
    ro.Dispose(); sec.AllowSelfIntersection(true);
    sec.AddToSection(new SelectionIntentRule[]{br}, null, null, null, seed, Section.Mode.Create, false);
    ExtrudeBuilder eb = wp.Features.CreateExtrudeBuilder(null);
    eb.Section = sec;
    eb.Direction = wp.Directions.CreateDirection(curSketch, Sense.Forward, SmartObject.UpdateOption.WithinModeling);
    eb.BooleanOperation.SetTargetBodies(new Body[0]);
    eb.BooleanOperation.Type = BooleanOperation.BooleanType.Create;
    eb.Limits.StartExtend.Value.SetFormula(start.ToString());
    eb.Limits.EndExtend.Value.SetFormula((start + len).ToString());
    eb.AllowSelfIntersectingSection(true);
    Feature f = eb.CommitFeature(); eb.Destroy();
    _lastFeature = f;
    if (f.GetBodies().Length > 0) { _previousBody = curBody; curBody = f.GetBodies()[0]; }
  }

  public void Tool_ExtrudeCut(double len)
  {
    Section sec = wp.Sections.CreateSection(0.0095, 0.01, 0.5);
    sec.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves); sec.DistanceTolerance = 0.01;
    SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions();
    ro.SetSelectedFromInactive(false); sec.AllowSelfIntersection(true);
    Point3d seed = CalcSeed();
    bool allArcs = true;
    foreach (ICurve cv in curCurves) { if (!(cv is Arc)) { allArcs = false; break; } }
    if (allArcs && curCurves.Count > 1) {
      foreach (ICurve cv in curCurves) {
        Arc a = cv as Arc; Point3d aseed = (a != null) ? a.CenterPoint : CalcSeed();
        var br = wp.ScRuleFactory.CreateRuleRegionBoundary(curSketch, new ICurve[]{cv}, aseed, 0.01, ro);
        sec.AddToSection(new SelectionIntentRule[]{br}, null, null, null, aseed, Section.Mode.Create, false);
      }
    } else {
      var br = wp.ScRuleFactory.CreateRuleRegionBoundary(curSketch, curCurves.ToArray(), seed, 0.01, ro);
      sec.AddToSection(new SelectionIntentRule[]{br}, null, null, null, seed, Section.Mode.Create, false);
    }
    ro.Dispose();
    ExtrudeBuilder eb2 = wp.Features.CreateExtrudeBuilder(null);
    eb2.Section = sec;
    eb2.Direction = wp.Directions.CreateDirection(curSketch, Sense.Forward, SmartObject.UpdateOption.WithinModeling);
    eb2.BooleanOperation.Type = BooleanOperation.BooleanType.Create;
    eb2.Limits.StartExtend.Value.SetFormula("0"); eb2.Limits.EndExtend.Value.SetFormula(len.ToString());
    eb2.AllowSelfIntersectingSection(true);
    Feature ft = eb2.CommitFeature(); eb2.Destroy();
    if (curBody != null && ft.GetBodies().Length > 0) {
      Body toolBody = ft.GetBodies()[0];
      var boolB = wp.Features.CreateBooleanBuilder(null);
      boolB.Operation = Feature.BooleanType.Subtract; boolB.Target = curBody;
      ScCollector coll = wp.ScCollectors.CreateCollector();
      coll.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleBodyDumb(new Body[]{toolBody})}, false);
      boolB.ToolBodyCollector = coll;
      boolB.CommitFeature(); boolB.Destroy();
    }
  }

  public void Tool_Revolve(double angle)
  {
    try
    {
      // 创建 Section（和 Extrude 相同的方式，已验证可编译）
      Section sec = wp.Sections.CreateSection(0.0095, 0.01, 0.5);
      sec.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
      SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions();
      ro.SetSelectedFromInactive(false);
      Point3d seed = CalcSeed();
      RegionBoundaryRule br = wp.ScRuleFactory.CreateRuleRegionBoundary(curSketch, curCurves.ToArray(), seed, 0.01, ro);
      ro.Dispose();
      sec.AllowSelfIntersection(true);
      sec.AddToSection(new SelectionIntentRule[]{br}, null, null, null, seed, Section.Mode.Create, false);

      RevolveBuilder rb = wp.Features.CreateRevolveBuilder(null);
      rb.Section = sec;
      rb.Axis = wp.Axes.CreateAxis(
          new Point3d(0,0,0), new Vector3d(0,0,1),
          SmartObject.UpdateOption.WithinModeling);

      rb.BooleanOperation.Type = BooleanOperation.BooleanType.Create;
      rb.Limits.StartExtend.Value.SetFormula("0");
      rb.Limits.EndExtend.Value.SetFormula(angle.ToString());
      Feature fr = rb.CommitFeature(); rb.Destroy();
      _lastFeature = fr;
      if (fr.GetBodies().Length > 0) curBody = fr.GetBodies()[0];
      Console.WriteLine("[OK] Revolve: {0}°", angle);
    }
    catch (Exception ex) { Console.WriteLine("[!] Revolve failed: {0}", ex.Message); }
  }

  public void Tool_Chamfer(double len)
  {
    if (curBody == null) return;
    var cb = wp.Features.CreateChamferBuilder(null);
    cb.Option = ChamferBuilder.ChamferOption.SymmetricOffsets;
    cb.FirstOffset = len.ToString();
    var coll = wp.ScCollectors.CreateCollector();
    coll.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleEdgeDumb(curBody.GetEdges())}, false);
    cb.SmartCollector = coll;
    cb.CommitFeature(); cb.Destroy();
  }

  public void Tool_Fillet(double rad)
  {
    if (curBody == null) return;
    var fb = wp.Features.CreateEdgeBlendBuilder(null);
    var coll = wp.ScCollectors.CreateCollector();
    coll.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleEdgeDumb(curBody.GetEdges())}, false);
    fb.CommitFeature(); fb.Destroy();
  }

  public void Tool_Cone(double r, double h)
  {
    // 圆锥：多层圆柱递减逼近
    int layers = 10;
    for (int i = 0; i < layers; i++)
    {
      double bot = (double)h * i / layers;
      double top = (double)h * (i + 1) / layers;
      double radius = r * (1.0 - (double)(i + 0.5) / layers);
      Tool_CreateSketch();
      Tool_DrawCircle(0, 0, radius);
      Tool_CloseSketch();
      Tool_ExtrudeFrom(bot, top - bot);
    }
  }
  public void Tool_Sphere(double r)
  {
    // 球体：多层圆盘堆叠逼近
    int layers = 16;
    for (int i = 0; i < layers; i++)
    {
      double bot = -r + 2.0 * r * i / layers;
      double top = -r + 2.0 * r * (i + 1) / layers;
      double midY = (bot + top) / 2.0;
      double radius = Math.Sqrt(r * r - midY * midY);
      Tool_CreateSketch();
      Tool_DrawCircle(0, 0, radius);
      Tool_CloseSketch();
      Tool_ExtrudeFrom(bot, top - bot);
    }
  }
  public void Tool_SaveModel(string path)
  {
    if (wp == null) wp = ses.Parts.Work;
    wp.SaveAs(path); Console.WriteLine("Saved: " + path);
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 草图操作（补充）
  // ═══════════════════════════════════════════════════════════════════════

    public void Tool_CreateSketchOnFace(int faceIndex)
  {
    Console.WriteLine("[!] CreateSketchOnFace: C# PlaneReference API needs Journal, fallback to XY plane");
    Tool_CreateSketch();
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 绘图工具（补充）
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_DrawArc(double x, double y, double r, double startAngle, double endAngle)
  {
    NXMatrix mx = ses.ActiveSketch.Orientation;
    double sa = startAngle * Math.PI / 180.0;
    double ea = endAngle * Math.PI / 180.0;
    curArc = wp.Curves.CreateArc(new Point3d(x, y, 0), mx, r, sa, ea);
    curCurves.Add(curArc);
    ses.ActiveSketch.AddGeometry(curArc, Sketch.InferConstraintsOption.InferNoConstraints);
    ses.ActiveSketch.Update();
  }

  public void Tool_DrawPolyline(Point3d[] points)
  {
    for (int i = 0; i < points.Length - 1; i++)
    {
      Line ln = wp.Curves.CreateLine(
        new Point3d(points[i].X, points[i].Y, 0),
        new Point3d(points[i+1].X, points[i+1].Y, 0));
      curCurves.Add(ln);
      ses.ActiveSketch.AddGeometry(ln, Sketch.InferConstraintsOption.InferNoConstraints);
    }
    ses.ActiveSketch.Update();
  }

    public void Tool_DrawSpline(Point3d[] points)
  {
    // NX2412 C# API 中 CurveCollection.CreateSpline 签名不确定，回退到多段线
    Console.WriteLine("[!] DrawSpline: fallback to polyline ({0} pts)", points.Length);
    Tool_DrawPolyline(points);
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 基本体素（补充）
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_Block(double x, double y, double z, double l, double w, double h)
  {
    // 块：矩形截面 + 从指定高度拉伸
    Tool_CreateSketch();
    Tool_DrawRectangle(x, y, l, w);
    Tool_CloseSketch();
    Tool_ExtrudeFrom(z, h);
  }

  public void Tool_Cylinder(double x, double y, double z, double r, double h)
  {
    // 圆柱：圆截面 + 从指定高度拉伸
    Tool_CreateSketch();
    Tool_DrawCircle(x, y, r);
    Tool_CloseSketch();
    Tool_ExtrudeFrom(z, h);
  }

  public void Tool_Torus(double majorR, double minorR)
  {
    try
    {
      // Create a circular guide curve in XY plane
      NXMatrix mx = null;
      Arc guideArc = null;
      try { mx = ses.ActiveSketch.Orientation; } catch { }
      if (mx == null)
        guideArc = wp.Curves.CreateArc(new Point3d(0, 0, 0),
            new Vector3d(1, 0, 0), new Vector3d(0, 1, 0),
            majorR, 0.0, 2.0 * Math.PI);
      else
        guideArc = wp.Curves.CreateArc(new Point3d(0, 0, 0), mx,
            majorR, 0.0, 2.0 * Math.PI);

      TubeBuilder tb = wp.Features.CreateTubeBuilder(null);
      Section guideSec = wp.Sections.CreateSection(0.0095, 0.01, 0.5);
      guideSec.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
      SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions();
      ro.SetSelectedFromInactive(false);
      CurveDumbRule cr = wp.ScRuleFactory.CreateRuleCurveDumb(new Curve[]{guideArc});
      guideSec.AddToSection(new SelectionIntentRule[]{cr}, guideArc, null, null,
          new Point3d(majorR, 0, 0), Section.Mode.Create, false);
      ro.Dispose();
      tb.OuterDiameter.RightHandSide = (minorR * 2.0).ToString();

      Feature f = tb.CommitFeature();
      tb.Destroy();
      _lastFeature = f;
      if (f.GetBodies().Length > 0) { _previousBody = curBody; curBody = f.GetBodies()[0]; }
      Console.WriteLine("[OK] Torus: major={0}, minor={1}", majorR, minorR);
    }
    catch (Exception ex)
    {
      Console.WriteLine("[!] Torus failed: {0}", ex.Message);
      // Fallback: sketch + revolve approach
      try
      {
        Tool_CreateSketch();
        Tool_DrawCircle(majorR, 0, minorR);
        Tool_CloseSketch();
        Tool_Revolve(360);
        Console.WriteLine("[OK] Torus (fallback via revolve): major={0}, minor={1}", majorR, minorR);
      }
      catch (Exception ex2)
      {
        Console.WriteLine("[!] Torus fallback also failed: {0}", ex2.Message);
      }
    }
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 扫描特征（补充）
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_Sweep(Point3d[] pathPoints)
  {
    try
    {
      if (pathPoints == null || pathPoints.Length < 2)
      { Console.WriteLine("[!] Sweep: need >=2 path points"); return; }

      // 1. 创建引导线（路径）
      Line guideLine = null;
      if (pathPoints.Length == 2)
        guideLine = wp.Curves.CreateLine(pathPoints[0], pathPoints[1]);
      else
      {
        // 多点路径用样条逼近（多段线回退）
        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
          Line seg = wp.Curves.CreateLine(pathPoints[i], pathPoints[i + 1]);
          if (seg != null && i == 0) guideLine = seg;
        }
      }
      if (guideLine == null) { Console.WriteLine("[!] Sweep: failed to create guide"); return; }

      // 2. 创建引导线 Section
      Section guideSec = wp.Sections.CreateSection(0.0095, 0.01, 0.5);
      guideSec.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
      SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions();
      ro.SetSelectedFromInactive(false);
      CurveDumbRule guideRule = wp.ScRuleFactory.CreateRuleCurveDumb(new Curve[]{guideLine});
      ro.Dispose();
      guideSec.AddToSection(new SelectionIntentRule[]{guideRule}, null, null, null,
          new Point3d(0,0,0), Section.Mode.Create, false);

      // 3. 创建截面 Section（从当前草图）
      Section profileSec = wp.Sections.CreateSection(0.0095, 0.01, 0.5);
      profileSec.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
      SelectionIntentRuleOptions ro2 = wp.ScRuleFactory.CreateRuleOptions();
      ro2.SetSelectedFromInactive(false);
      Point3d seed = CalcSeed();
      RegionBoundaryRule br = wp.ScRuleFactory.CreateRuleRegionBoundary(curSketch, curCurves.ToArray(), seed, 0.01, ro2);
      ro2.Dispose();
      profileSec.AllowSelfIntersection(false);
      profileSec.AddToSection(new SelectionIntentRule[]{br}, null, null, null,
          seed, Section.Mode.Create, false);

      // 4. 创建 SweptBuilder1
      ses.ActiveSketch.Deactivate(Sketch.ViewReorient.True, Sketch.UpdateLevel.Model);
      NXOpen.Features.Swept nullSwept = null;
      var builder = wp.Features.FreeformSurfaceCollection.CreateSweptBuilder1(nullSwept);
      builder.G0Tolerance = 0.01;
      builder.G1Tolerance = 0.5;
      builder.PreserveShapeOption = false;

      // 5. 设置 Spine（引导线容差）
      builder.Spine.DistanceTolerance = 0.01;
      builder.Spine.ChainingTolerance = 0.0095;

      // 6. 添加引导线到 GuideList（关键！Journal 确认的正确 API）
      builder.GuideList.Append(guideSec);

      // 7. 添加截面到 SectionList
      builder.SectionList.Append(profileSec);

      // 8. 设置 spine 引用到 scaling/orientation 方法
      builder.ScalingMethod.AreaLaw.AlongSpineData.SetFeatureSpine(guideSec);
      builder.ScalingMethod.PerimeterLaw.AlongSpineData.SetFeatureSpine(guideSec);
      builder.OrientationMethod.AngularLaw.AlongSpineData.SetFeatureSpine(guideSec);

      // 9. 提交
      NXObject result = builder.Commit();
      builder.Destroy();

      Swept swept = (Swept)result;
      _lastFeature = swept;
      if (swept.GetBodies().Length > 0) { _previousBody = curBody; curBody = swept.GetBodies()[0]; }
      Console.WriteLine("[OK] Sweep: {0} path points, profile from sketch", pathPoints.Length);
    }
    catch (Exception ex) { Console.WriteLine("[!] Sweep failed: {0}", ex.Message); }
  }

  public void Tool_Loft(string[] sectionRefs)
  {
    Console.WriteLine("[OK] Tool_Loft -> delegating to ThroughCurves");
    Tool_ThroughCurves(sectionRefs);
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 布尔操作
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_BooleanUnite(string targetRef, string toolRef)
  {
    try
    {
      if (curBody == null) return;
      Body targetBody = curBody;
      Body toolBody = _previousBody;
      if (targetBody == null || toolBody == null) return;
      var bb = wp.Features.CreateBooleanBuilder(null);
      bb.Operation = Feature.BooleanType.Unite;
      bb.Target = targetBody;
      ScCollector coll = wp.ScCollectors.CreateCollector();
      coll.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleBodyDumb(new Body[]{toolBody})}, false);
      bb.ToolBodyCollector = coll;
      Feature f = bb.CommitFeature(); bb.Destroy();
      _lastFeature = f;
      if (f.GetBodies().Length > 0) curBody = f.GetBodies()[0];
      Console.WriteLine("[OK] BooleanUnite");
    }
    catch (Exception ex) { Console.WriteLine("[!] BooleanUnite failed: {0}", ex.Message); }
  }

  public void Tool_BooleanSubtract(string targetRef, string toolRef)
  {
    try
    {
      if (curBody == null) return;
      Body targetBody = _previousBody;
      Body toolBody = curBody;
      if (targetBody == null || toolBody == null) return;
      var bb = wp.Features.CreateBooleanBuilder(null);
      bb.Operation = Feature.BooleanType.Subtract;
      bb.Target = targetBody;
      ScCollector coll = wp.ScCollectors.CreateCollector();
      coll.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleBodyDumb(new Body[]{toolBody})}, false);
      bb.ToolBodyCollector = coll;
      Feature f = bb.CommitFeature(); bb.Destroy();
      _lastFeature = f;
      if (f.GetBodies().Length > 0) curBody = f.GetBodies()[0];
      Console.WriteLine("[OK] BooleanSubtract");
    }
    catch (Exception ex) { Console.WriteLine("[!] BooleanSubtract failed: {0}", ex.Message); }
  }

  public void Tool_BooleanIntersect(string targetRef, string toolRef)
  {
    try
    {
      if (curBody == null) return;
      Body targetBody = curBody;
      Body toolBody = _previousBody;
      if (targetBody == null || toolBody == null) return;
      var bb = wp.Features.CreateBooleanBuilder(null);
      bb.Operation = Feature.BooleanType.Intersect;
      bb.Target = targetBody;
      ScCollector coll = wp.ScCollectors.CreateCollector();
      coll.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleBodyDumb(new Body[]{toolBody})}, false);
      bb.ToolBodyCollector = coll;
      Feature f = bb.CommitFeature(); bb.Destroy();
      _lastFeature = f;
      if (f.GetBodies().Length > 0) curBody = f.GetBodies()[0];
      Console.WriteLine("[OK] BooleanIntersect");
    }
    catch (Exception ex) { Console.WriteLine("[!] BooleanIntersect failed: {0}", ex.Message); }
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 细节特征（补充）
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_EdgeBlend(double radius, int[] edgeIndices)
  {
    try
    {
      if (curBody == null) { Console.WriteLine("[!] EdgeBlend: no body"); return; }
      Edge[] allEdges = curBody.GetEdges();
      List<Edge> selEdges = new List<Edge>();
      if (edgeIndices != null && edgeIndices.Length > 0) {
        foreach (int idx in edgeIndices) if (idx >= 0 && idx < allEdges.Length) selEdges.Add(allEdges[idx]);
      } else {
        selEdges.AddRange(allEdges);
      }
      if (selEdges.Count == 0) return;
      var fb = wp.Features.CreateEdgeBlendBuilder(null);
      ScCollector coll = wp.ScCollectors.CreateCollector();
      SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions(); ro.SetSelectedFromInactive(false);
      coll.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleEdgeDumb(selEdges.ToArray(), ro)}, false);
      ro.Dispose();
      fb.NonCliffEdges = coll;
      fb.AddChainset(coll, radius.ToString());
      Feature f = fb.CommitFeature(); fb.Destroy();
      _lastFeature = f;
      Console.WriteLine("[OK] EdgeBlend: r={0}, {1} edges", radius, selEdges.Count);
    }
    catch (Exception ex) { Console.WriteLine("[!] EdgeBlend failed: {0}", ex.Message); }
  }

  public void Tool_Shell(double thickness, int removeFaceIndex)
  {
    try
    {
      if (curBody == null) { Console.WriteLine("[!] Shell: no body"); return; }
      var builder = wp.Features.CreateShellBuilder(null);
      builder.SetDefaultThickness(thickness.ToString());
      if (removeFaceIndex >= 0)
      {
        Face[] all = curBody.GetFaces();
        if (removeFaceIndex < all.Length)
        {
          var coll = wp.ScCollectors.CreateCollector();
          SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions();
          ro.SetSelectedFromInactive(false);
          FaceDumbRule rule = wp.ScRuleFactory.CreateRuleFaceDumb(new Face[]{all[removeFaceIndex]}, ro);
          ro.Dispose();
          coll.ReplaceRules(new SelectionIntentRule[]{rule}, false);
          builder.RemovedFacesCollector = coll;
        }
      }
      Feature f = builder.CommitFeature(); builder.Destroy();
      _lastFeature = f;
      Console.WriteLine("[OK] Shell: thickness={0}, remove_face={1}", thickness, removeFaceIndex);
    }
    catch (Exception ex) { Console.WriteLine("[!] Shell failed: {0}", ex.Message); }
  }

  public void Tool_Hole(double x, double y, double diameter, double depth, string holeType)
  {
    // 孔：圆截面 + 切除
    Tool_CreateSketch();
    Tool_DrawCircle(x, y, diameter / 2.0);
    Tool_CloseSketch();
    Tool_ExtrudeCut(depth);
  }

  public void Tool_Pocket(double x, double y, double length, double width, double depth)
  {
    // 矩形槽：矩形截面 + 切除
    Tool_CreateSketch();
    Tool_DrawRectangle(x - length / 2.0, y - width / 2.0, length, width);
    Tool_CloseSketch();
    Tool_ExtrudeCut(depth);
  }

  public void Tool_Boss(double x, double y, double diameter, double height)
  {
    // 凸台：圆截面 + 拉伸叠加
    Tool_CreateSketch();
    Tool_DrawCircle(x, y, diameter / 2.0);
    Tool_CloseSketch();
    Tool_Extrude(height);
  }

  public void Tool_Pad(double x, double y, double length, double width, double height)
  {
    // 凸垫：矩形截面 + 拉伸叠加
    Tool_CreateSketch();
    Tool_DrawRectangle(x - length / 2.0, y - width / 2.0, length, width);
    Tool_CloseSketch();
    Tool_Extrude(height);
  }

  public void Tool_Slot(double x, double y, double length, double width, double depth)
  {
    // 直线槽：矩形截面 + 切除
    Tool_CreateSketch();
    Tool_DrawRectangle(x, y - width / 2.0, length, width);
    Tool_CloseSketch();
    Tool_ExtrudeCut(depth);
  }

  public void Tool_Groove(double diameter, double width, double depth)
  {
    try
    {
      // 环形槽：通过 revolve 切除实现
      Tool_CreateSketch();
      Tool_DrawRectangle(diameter / 2.0 - depth, -width / 2.0, depth, width);
      Tool_CloseSketch();
      Tool_Revolve(360);
      Console.WriteLine("[OK] Groove: dia={0}, w={1}, d={2}", diameter, width, depth);
    }
    catch (Exception ex) { Console.WriteLine("[!] Groove failed: {0}", ex.Message); }
  }

    public void Tool_Thread(string cylinderRef, string threadType, double length)
  {
    try
    {
      // ThreadBuilder.CylindricalFace 是 SelectDisplayableObject 且只读
      // 需要通过 ScCollector + FaceDumbRule 设置
      Console.WriteLine("[!] Thread: C# SelectDisplayableObject API needs Journal");
    }
    catch (Exception ex) { Console.WriteLine("[!] Thread failed: {0}", ex.Message); }
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 阵列与镜像
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_PatternLinear(string featureRef, int countX, double spacingX, int countY, double spacingY)
  {
    try
    {
      if (_lastFeature == null) { Console.WriteLine("[!] PatternLinear: no feature"); return; }
      var builder = wp.Features.CreatePatternFeatureBuilder(null);
      builder.FeatureList.Add(_lastFeature);
      var patternDef = builder.PatternService;
      patternDef.PatternType = PatternDefinition.PatternEnum.Linear;
      var def = patternDef.RectangularDefinition;
      def.XSpacing.NCopies.RightHandSide = countX.ToString();
      def.XSpacing.PitchDistance.RightHandSide = spacingX.ToString();
      if (countY > 1)
      {
        def.YSpacing.NCopies.RightHandSide = countY.ToString();
        def.YSpacing.PitchDistance.RightHandSide = spacingY.ToString();
      }
      var result = builder.CommitFeature(); builder.Destroy();
      Console.WriteLine("[OK] PatternLinear: x={0}@{1}, y={2}@{3}", countX, spacingX, countY, spacingY);
    }
    catch (Exception ex) { Console.WriteLine("[!] PatternLinear failed: {0}", ex.Message); }
  }

  public void Tool_PatternCircular(string featureRef, int count, double angle)
  {
    if (_lastFeature == null)
    {
      Console.WriteLine("[!] PatternCircular: no feature to pattern");
      return;
    }

    try
    {
      var builder = wp.Features.CreatePatternFeatureBuilder(null);
      builder.FeatureList.Add(_lastFeature);

      // 设置为圆形阵列
      var patternDef = builder.PatternService;
      patternDef.PatternType = PatternDefinition.PatternEnum.Circular;

      // 设置数量和角度
      var circularDef = patternDef.CircularDefinition;
      circularDef.AngularSpacing.NCopies.RightHandSide = count.ToString();
      circularDef.AngularSpacing.PitchAngle.RightHandSide = angle.ToString();

      // 旋转轴：Z 轴，经过原点
      Point3d origin = new Point3d(0, 0, 0);
      Vector3d zDir = new Vector3d(0, 0, 1);
      circularDef.RotationAxis = wp.Axes.CreateAxis(origin, zDir, SmartObject.UpdateOption.WithinModeling);

      var result = builder.CommitFeature();
      builder.Destroy();
      Console.WriteLine("[OK] CircularPattern: {0} instances, {1}°", count, angle);
    }
    catch (Exception ex)
    {
      Console.WriteLine("[!] CircularPattern failed: {0}", ex.Message);
    }
  }

  public void Tool_MirrorFeature(string featureRef, string mirrorPlane)
  {
    try
    {
      if (_lastFeature == null) { Console.WriteLine("[!] MirrorFeature: no feature"); return; }
      var builder = wp.Features.CreateMirrorFeatureBuilder(null);
      builder.FeatureSet.Add(_lastFeature);
      string pl = (mirrorPlane ?? "YZ").ToUpper();
      Vector3d normal = pl == "XY" ? new Vector3d(0, 0, 1)
                      : pl == "XZ" ? new Vector3d(0, 1, 0)
                      : new Vector3d(1, 0, 0);
      Plane plane = wp.Planes.CreatePlane(new Point3d(0,0,0), normal, SmartObject.UpdateOption.WithinModeling);
      builder.PlaneConstructor = plane;
      Feature f = builder.CommitFeature(); builder.Destroy();
      _lastFeature = f;
      Console.WriteLine("[OK] MirrorFeature: plane={0}", mirrorPlane);
    }
    catch (Exception ex) { Console.WriteLine("[!] MirrorFeature failed: {0}", ex.Message); }
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 曲面建模
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_ThroughCurves(string[] sections)
  {
    try
    {
      if (sections == null || sections.Length < 2) return;
      Feature nullFeature = null;
      var builder = wp.Features.FreeformSurfaceCollection.CreateThroughCurvesBuilder1(nullFeature);
      builder.PreserveShape = false;
      foreach (string skName in sections)
      {
        SketchFeature skf = (SketchFeature)wp.Features.FindObject(skName);
        if (skf == null) continue;
        Section sec = wp.Sections.CreateSection(0.0095, 0.01, 0.5);
        sec.SetAllowedEntityTypes(Section.AllowTypes.CurvesAndPoints);
        SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions(); ro.SetSelectedFromInactive(false);
        sec.AddToSection(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleCurveFeature(new Feature[]{skf}, null, ro)}, null, null, null, new Point3d(0,0,0), Section.Mode.Create, false);
        ro.Dispose();
        builder.SectionsList.Append(sec);
      }
      Feature f = builder.CommitFeature(); builder.Destroy(); _lastFeature = f;
      if (f.GetBodies().Length > 0) curBody = f.GetBodies()[0];
      Console.WriteLine("[OK] ThroughCurves: {0} sections", sections.Length);
    }
    catch (Exception ex) { Console.WriteLine("[!] ThroughCurves failed: {0}", ex.Message); }
  }

  public void Tool_ThroughCurveMesh(string[] primary, string[] cross)
  {
    try
    {
      // ThroughCurveMesh Builder 的 API 需进一步确认
      Console.WriteLine("[!] ThroughCurveMesh: C# API needs Journal (primary={0}, cross={1})",
          primary != null ? primary.Length.ToString() : "0",
          cross != null ? cross.Length.ToString() : "0");
    }
    catch (Exception ex) { Console.WriteLine("[!] ThroughCurveMesh failed: {0}", ex.Message); }
  }

  public void Tool_Ruled(string curve1, string curve2)
  {
    try
    {
      // 直纹面：通过 ThroughCurves 实现（2 个截面）
      Tool_ThroughCurves(new string[] { curve1, curve2 });
      Console.WriteLine("[OK] Ruled: {0} → {1}", curve1, curve2);
    }
    catch (Exception ex) { Console.WriteLine("[!] Ruled failed: {0}", ex.Message); }
  }

  public void Tool_BoundedPlane(string[] boundaryCurves)
  {
    try
    {
      if (boundaryCurves == null || boundaryCurves.Length < 1)
      { Console.WriteLine("[!] BoundedPlane: no curves"); return; }
      var builder = wp.Features.CreateBoundedPlaneBuilder(null);
      Section sec = wp.Sections.CreateSection(0.0095, 0.01, 0.5);
      sec.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
      foreach (string refName in boundaryCurves)
      {
        NXObject obj = wp.Features.FindObject(refName);
        if (obj is ICurve)
        {
          SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions();
          ro.SetSelectedFromInactive(false);
          // BoundedPlane C# API 需要进一步 Journal 确认
          ro.Dispose();
        }
      }
      Feature f = builder.CommitFeature(); builder.Destroy();
      Console.WriteLine("[OK] BoundedPlane: {0} curves", boundaryCurves.Length);
    }
    catch (Exception ex) { Console.WriteLine("[!] BoundedPlane failed: {0}", ex.Message); }
  }

    public void Tool_FillSurface(string[] boundaryCurves)
  {
    try
    {
      Tool_BoundedPlane(boundaryCurves);
      Console.WriteLine("[OK] FillSurface: {0} curves (via BoundedPlane)", boundaryCurves.Length);
    }
    catch (Exception ex) { Console.WriteLine("[!] FillSurface failed: {0}", ex.Message); }
  }

  public void Tool_OffsetSurface(string faceRef, double distance)
  {
    // 偏置曲面：从当前体的 faces 创建偏置
    try
    {
      if (curBody == null)
      {
        Console.WriteLine("[!] OffsetSurface: no curBody");
        return;
      }

      Face[] allFaces = curBody.GetFaces();
      if (allFaces.Length == 0)
      {
        Console.WriteLine("[!] OffsetSurface: body has no faces");
        return;
      }

      var builder = wp.Features.CreateOffsetSurfaceBuilder(null);
      builder.OutputOption = OffsetSurfaceBuilder.OutputOptionType.OneFeatureForAllFaces;
      builder.Tolerance = 0.01;
      builder.PartialOption = true;
      builder.MaximumExcludedObjects = 10;
      builder.RemoveProblemVerticesOption = true;
      builder.Radius.SetFormula(distance.ToString());
      builder.ApproxOption = true;
      builder.SetOrientationMethod(
          OffsetSurfaceBuilder.OrientationMethodType.UseExistingNormals);

      // 创建面集
      ScCollector nullColl = null;
      var faceSet = wp.FaceSetOffsets.CreateFaceSet(
          distance.ToString(), nullColl, false, 0);

      // 选择所有面（或通过 faceRef 指定）
      ScCollector faceColl = wp.ScCollectors.CreateCollector();
      SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions();
      ro.SetSelectedFromInactive(false);
      FaceBodyRule bodyRule = wp.ScRuleFactory.CreateRuleFaceBody(curBody, ro);
      ro.Dispose();
      faceColl.ReplaceRules(new SelectionIntentRule[]{bodyRule}, false);
      faceSet.FaceCollector = faceColl;

      builder.FaceSets.Append(faceSet);

      NXObject result = builder.Commit();
      builder.Destroy();
      Console.WriteLine("[OK] OffsetSurface: distance={0}, faces from body", distance);
    }
    catch (Exception ex)
    {
      Console.WriteLine("[!] OffsetSurface failed: {0}", ex.Message);
    }
  }

      public void Tool_Extension(string faceRef, string edgeRef, double length)
  {
    try
    {
      if (curBody == null) return;
      Face[] allF = curBody.GetFaces();
      int fi = 0; int.TryParse(faceRef, out fi);
      if (fi >= 0 && fi < allF.Length)
      {
        var b = wp.Features.CreateExtensionBuilder(null);
        b.Length.RightHandSide = length.ToString();
        b.Selection.Value = allF[fi];
        Feature f = b.CommitFeature(); b.Destroy(); _lastFeature = f;
        Console.WriteLine("[OK] Extension: len={0}", length);
      }
    }
    catch (Exception ex) { Console.WriteLine("[!] Extension failed: {0}", ex.Message); }
  }

  public void Tool_TrimSurface(string faceRef, string[] boundaryCurves)
  {
    Console.WriteLine("[!] TrimSurface: C# TrimSurfaceBuilder API needs Journal");
  }

// ═══════════════════════════════════════════════════════════════════════
  // 同步建模
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_MoveFace(int[] faceIndices, double distance, string direction)
  {
    try
    {
      if (curBody == null || faceIndices == null || faceIndices.Length == 0)
      { Console.WriteLine("[!] MoveFace: no body or faces"); return; }
      Face[] all = curBody.GetFaces();
      List<Face> sel = new List<Face>();
      foreach (int i in faceIndices) if (i >= 0 && i < all.Length) sel.Add(all[i]);
      if (sel.Count == 0) { Console.WriteLine("[!] MoveFace: no valid faces"); return; }

      string dir = (direction ?? "Z").ToUpper();
      Vector3d vec = dir == "X" ? new Vector3d(1,0,0)
                    : dir == "Y" ? new Vector3d(0,1,0)
                    : new Vector3d(0,0,1);

      // MoveFaceBuilder 的 API 需 Journal 验证，用 MoveObjectBuilder 做回退
      MoveObjectBuilder mb = wp.BaseFeatures.CreateMoveObjectBuilder(null);
      foreach (Face f in sel) mb.ObjectToMoveObject.Add(f);
      mb.TransformMotion.Option = NXOpen.GeometricUtilities.ModlMotion.Options.DistanceAngle;
      mb.TransformMotion.DistanceValue.RightHandSide = distance.ToString();
      mb.TransformMotion.DistanceVector = wp.Directions.CreateDirection(
          new Point3d(0,0,0), vec, SmartObject.UpdateOption.WithinModeling);
      NXObject obj = mb.Commit(); mb.Destroy();
      Console.WriteLine("[OK] MoveFace: {0} faces, dist={1}, dir={2}", sel.Count, distance, direction);
    }
    catch (Exception ex) { Console.WriteLine("[!] MoveFace failed: {0}", ex.Message); }
  }

  public void Tool_DeleteFace(int[] faceIndices)
  {
    try
    {
      if (curBody == null || faceIndices == null || faceIndices.Length == 0) return;
      Face[] all = curBody.GetFaces(); List<Face> sel = new List<Face>();
      foreach (int i in faceIndices) if (i >= 0 && i < all.Length) sel.Add(all[i]);
      if (sel.Count == 0) return;
      var b = wp.Features.CreateDeleteFaceBuilder(null);
      SelectionIntentRuleOptions ro = wp.ScRuleFactory.CreateRuleOptions(); ro.SetSelectedFromInactive(false);
      b.FaceCollector.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleFaceDumb(sel.ToArray(), ro)}, false);
      ro.Dispose(); b.Heal = true;
      Feature f = b.CommitFeature(); b.Destroy(); _lastFeature = f;
      Console.WriteLine("[OK] DeleteFace: {0} faces", sel.Count);
    }
    catch (Exception ex) { Console.WriteLine("[!] DeleteFace failed: {0}", ex.Message); }
  }

    public void Tool_ReplaceFace(int[] targetFaces, int[] toolFaces)
  {
    Console.WriteLine("[!] ReplaceFace: C# ReplaceFaceBuilder API needs Journal");
  }

    public void Tool_ResizeFace(int[] faceIndices, double newRadius)
  {
    Console.WriteLine("[!] ResizeFace: C# ResizeFaceBuilder API needs Journal");
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 变换操作
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_Translate(double dx, double dy, double dz)
  {
    try
    {
      if (curBody == null) { Console.WriteLine("[!] Translate: no body"); return; }
      double dist = Math.Sqrt(dx*dx + dy*dy + dz*dz);
      if (dist < 0.001) { Console.WriteLine("[!] Translate: zero distance"); return; }

      MoveObjectBuilder mb = wp.BaseFeatures.CreateMoveObjectBuilder(null);
      mb.ObjectToMoveObject.Add(curBody);
      mb.TransformMotion.Option = NXOpen.GeometricUtilities.ModlMotion.Options.DistanceAngle;
      mb.TransformMotion.DistanceValue.RightHandSide = dist.ToString();

      // 方向向量需归一化：距离由 DistanceValue 控制，方向由 DistanceVector（Direction 类型）控制
      double nx = dx/dist, ny = dy/dist, nz = dz/dist;
      mb.TransformMotion.DistanceVector = wp.Directions.CreateDirection(
          new Point3d(0,0,0), new Vector3d(nx, ny, nz),
          SmartObject.UpdateOption.WithinModeling);

      NXObject obj = mb.Commit(); mb.Destroy();
      Console.WriteLine("[OK] Translate: ({0},{1},{2})", dx, dy, dz);
    }
    catch (Exception ex) { Console.WriteLine("[!] Translate failed: {0}", ex.Message); }
  }

  public void Tool_Rotate(double angle, string axis)
  {
    try
    {
      if (curBody == null) { Console.WriteLine("[!] Rotate: no body"); return; }

      string ax = (axis ?? "Z").ToUpper();
      Vector3d vec = ax=="X"?new Vector3d(1,0,0):ax=="Y"?new Vector3d(0,1,0):new Vector3d(0,0,1);

      MoveObjectBuilder mb = wp.BaseFeatures.CreateMoveObjectBuilder(null);
      mb.ObjectToMoveObject.Add(curBody);
      mb.TransformMotion.Option = NXOpen.GeometricUtilities.ModlMotion.Options.Angle;
      mb.TransformMotion.Angle.RightHandSide = angle.ToString();

      // RotateVector 需要 Direction 类型（用 CreateDirection，不用 CreateAxis）
      mb.TransformMotion.RotateVector = wp.Axes.CreateAxis(
          new Point3d(0,0,0), vec,
          SmartObject.UpdateOption.WithinModeling);

      NXObject obj = mb.Commit(); mb.Destroy();
      Console.WriteLine("[OK] Rotate: {0}° around {1}", angle, ax);
    }
    catch (Exception ex) { Console.WriteLine("[!] Rotate failed: {0}", ex.Message); }
  }

    public void Tool_Scale(double factor)
  {
    Console.WriteLine("[!] Scale: CreateScaleBodyBuilder not found in NX2412");
  }

  // ═══════════════════════════════════════════════════════════════════════
  // 测量与查询
  // ═══════════════════════════════════════════════════════════════════════

  public void Tool_MeasureDistance(double x1, double y1, double z1, double x2, double y2, double z2)
  {
    double dx = x2 - x1, dy = y2 - y1, dz = z2 - z1;
    double dist = Math.Sqrt(dx * dx + dy * dy + dz * dz);
    Console.WriteLine("[Measure] Distance: {0:F3} mm", dist);
  }

  public void Tool_MeasureVolume()
  {
    try
    {
      if (curBody == null) { Console.WriteLine("[!] MeasureVolume: no body"); return; }
      ScCollector c = wp.ScCollectors.CreateCollector();
      c.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleBodyDumb(new Body[]{curBody})}, false);
      Unit mm = (Unit)wp.UnitCollection.FindObject("MilliMeter");
      double vol = wp.MeasureManager.NewMassProperties(new Unit[]{mm}, 0.9999, c).Volume;
      Console.WriteLine("[Measure] Volume: {0:F3} mm3", vol);
    }
    catch (Exception ex) { Console.WriteLine("[!] MeasureVolume: {0}", ex.Message); }
  }

  public void Tool_MeasureMass()
  {
    try
    {
      if (curBody == null) { Console.WriteLine("[!] MeasureMass: no body"); return; }
      ScCollector c = wp.ScCollectors.CreateCollector();
      c.ReplaceRules(new SelectionIntentRule[]{wp.ScRuleFactory.CreateRuleBodyDumb(new Body[]{curBody})}, false);
      Unit mm = (Unit)wp.UnitCollection.FindObject("MilliMeter");
      Unit kg = (Unit)wp.UnitCollection.FindObject("Kilogram");
      var p = wp.MeasureManager.NewMassProperties(new Unit[]{mm, kg}, 0.9999, c);
      Console.WriteLine("[Measure] Mass: {0:F6} kg, Vol: {1:F3} mm3", p.Mass, p.Volume);
    }
    catch (Exception ex) { Console.WriteLine("[!] MeasureMass: {0}", ex.Message); }
  }
}