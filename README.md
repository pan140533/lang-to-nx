<p align="center">
  <img src="https://img.shields.io/badge/status-active-success" alt="Status">
  <img src="https://img.shields.io/badge/NX-2412-blue" alt="NX">
  <img src="https://img.shields.io/badge/python-3.10+-green" alt="Python">
  <img src="https://img.shields.io/badge/C%23-5.0-purple" alt="C#">
  <img src="https://img.shields.io/badge/MCP-1.0-orange" alt="MCP">
</p>

<h1 align="center">Lang-to-NX</h1>
<p align="center"><strong>自然语言驱动 Siemens NX 自动建模</strong></p>
<p align="center">
  <i>"给我一个 17 齿的齿轮"  →  AI 自动规划  →  NX 生成 .prt 文件</i>
</p>

---

## 这是什么？

**Lang-to-NX** 是一个 MCP（Model Context Protocol）服务器，让 Claude 等 AI Agent 能直接操控 Siemens NX 进行 3D 建模。自然语言描述零件 → AI 理解意图、规划步骤 → 生成 C# 脚本 → 驱动 NX 执行 → 输出 `.prt` 模型文件。

```
你说："做个三叶风扇，中心带孔"
     │
     ▼
AI 理解意图 → 识别圆形阵列 → 规划步骤 → 生成 C# → NX 执行 → 风扇.prt
```

---

## 解决什么问题？

Siemens NX 是工业级闭源 CAD 软件，广泛用于航空航天、汽车制造。AI 无法直接操作其内部 3D 几何数据。**唯一入口是 NXOpen API**——NX 官方二次开发接口，本质就是人类 CAD 操作的编程封装。

> 核心思路：**让 AI 扮演一个"会写 NX 二次开发脚本的工程师"。**

---

## 架构

```
┌─────────────────────────────────────────────────────────┐
│  第1层 · AI Agent                                        │
│  Claude / Cursor / 任何支持 MCP 的 AI                    │
│  理解意图、规划建模步骤、调用 MCP 工具                     │
├─────────────────────────────────────────────────────────┤
│  第2层 · MCP 协议层 (Python)                             │
│  工具注册 · 参数校验 · 错误处理                            │
│  53 种建模操作封装为标准化工具                             │
├─────────────────────────────────────────────────────────┤
│  第3层 · C# Journal 生成                                 │
│  generator.py   JSON 步骤 → C# 代码                      │
│  nx_modeler.cs  NXOpen API 封装（58 个方法）              │
├─────────────────────────────────────────────────────────┤
│  第4层 · NX 执行层                                       │
│  run_journal.exe 编译执行 C# 脚本                        │
│  NX 用完即退出，不占用 License                            │
└─────────────────────────────────────────────────────────┘
```

### 为什么用外部进程而不是 Python NXOpen API？

| | Python NXOpen API | **本项目** |
|---|---|---|
| NX 状态 | 必须一直打开 | **用完即退，不占 License** |
| 稳定性 | 进程内逻辑不稳定 | **进程隔离** |
| 批量建模 | 不适合 | **天然适合** |

---

## 能做什么

### 53 种建模操作

| 类别 | 操作 | 数量 |
|------|------|------|
| 📐 草图 | 创建草图、画圆/矩形/线/弧/样条曲线 | 10 |
| 📦 体素 | 方块、圆柱、圆锥、球体、圆环 | 5 |
| 🔧 特征 | 拉伸、旋转、扫掠、放样、抽壳、打孔 | 12 |
| 🧩 布尔 | 求和、求差、求交 | 3 |
| ✨ 细节 | 倒角、圆角、边倒圆 | 3 |
| 🔄 阵列 | 圆形阵列、线性阵列、镜像 | 3 |
| 🏗️ 曲面 | 直纹面、通过曲线组、填充面、修剪面 | 8 |
| 🔀 变换 | 移动、旋转、缩放 | 3 |
| 📏 测量 | 距离、体积、质量 | 3 |
| 📄 文档 | 新建、保存 | 2 |

### 标准件自动识别

- **齿轮**：齿数/模数 → 毛坯 + 齿廓 + 圆形阵列
- **法兰**：孔数 → 底板 + 孔 + 圆形阵列
- **旋转体**：花瓶/杯子/轴 → 截面 + Revolve
- **阵列件**："N个X绕一圈" → 单体 + 圆形阵列

---

## 快速开始

```bash
git clone https://github.com/pan140533/lang-to-nx.git
cd lang-to-nx
pip install -r requirements.txt
cp .env.example .env
```

编辑 `.env`：
```ini
NX_ROOT=C:\Program Files\Siemens\NX
RUN_JOURNAL_EXE=C:\Program Files\Siemens\NX\NXBIN\run_journal.exe
```

```bash
python run.py                    # MCP Server
python run.py --list-tools       # 列出所有工具
```

### 接入 Claude Desktop
```json
{
  "mcpServers": {
    "lang-to-nx": {
      "command": "python",
      "args": ["path/to/lang-to-nx/run.py"]
    }
  }
}
```

---

## 演示

**基础体素：** "直径60高20的圆柱" → `cylinder.prt`

**齿轮：** "17齿模数1.5厚15mm" → 毛坯 → 齿廓 → 阵列×17 → `gear.prt`

**三叶风扇：** "三叶风扇中心带孔" → 轮毂 → 叶片 → 阵列×3 → 孔 → `fan.prt`

---

## 项目结构

```
lang-to-nx/
├── run.py                    # 启动入口
├── CLAUDE.md                 # AI 行为指南（53种工具完整文档）
│
├── backend/
│   ├── config.py             # 配置管理
│   ├── mcp/                  # MCP 协议层
│   │   ├── server.py
│   │   ├── registry.py
│   │   ├── executor.py
│   │   └── tools/
│   │       ├── execute.py    #   nx_execute_plan（核心）
│   │       └── primitives.py #   体素快捷工具
│   └── journal/              # C# 代码生成
│       ├── generator.py      #   JSON → C#（53 方法）
│       └── nx_modeler.cs     #   NXOpen API（58 方法）
│
└── docs/
```

---

## 当前状态

| 模块 | 状态 |
|------|------|
| MCP 协议层 | ✅ 完成 |
| C# NXOpen 封装（58 方法） | ✅ 完成 |
| Journal 生成器（53 方法） | ✅ 完成 |
| P0 Bug 修复（Revolve/Translate/Rotate） | ✅ 完成 |
| NX 实测验证 | 🚧 ~25/58 |
| Agent 管线 | 🔜 下一步 |
| Web 前端 | 🔜 规划中 |

---

## 设计原则

1. **外部进程隔离** — NX 用完即退，不占 License
2. **MCP 标准协议** — 任何 MCP 客户端即插即用
3. **分层解耦** — 协议层不涉及 CAD，执行层不涉及 AI
4. **先分解再执行** — 识别阵列/镜像/旋转体，避免重复建模

---

## License

MIT
