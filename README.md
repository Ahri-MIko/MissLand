# MissLand · 迷岛

> 一款点触式解谜冒险游戏。在一座静默的小岛上，帮老奶奶找到信箱钥匙，取出远方寄来的船票。
>
> Unity 2022.3 · URP · 2D 点触解谜

[![Unity](https://img.shields.io/badge/Unity-2022.3.62f1c1-57B9E7?logo=unity)](https://unity.com/)
[![URP](https://img.shields.io/badge/Render%20Pipeline-URP-8B5CF6)](https://unity.com/srp/universal-render-pipeline)
[![Genre](https://img.shields.io/badge/Genre-Point--%26--Click%20Puzzle-FF6B6B)]()

---

## 🎮 游戏简介

在一座被时间遗忘的小岛上，住着一位老奶奶。她的老头子一辈子都在折腾——要么躲在楼上捣鼓时间机器，要么出海寻找什么东西。最近他说要寄一张船票回来，叫她一起出去看看……

> "老了才明白，万物静默如迷。"

你需要在五个场景中探索、拾取道具、解开机关，最终找到信箱钥匙、打开信箱、取出船票，把它交到老奶奶手中。

---

## 🕹️ 玩法说明

### 基本操作

- **鼠标点击 / 触摸屏点触**：与场景中的物品和角色交互
- **场景切换**：点击场景中的箭头、门、楼梯等元素切换区域
- **道具栏**：屏幕右下角，拾取的道具会出现在这里，左右箭头切换
- **使用道具**：点击道具栏中的道具选中（鼠标变为"抓着道具的手"），再点击场景中的目标物体使用
- **菜单按钮**：右上角，点击返回主界面

### 游戏流程

```
H1（起点）
  │
  ▼
H2（主厅 · 老奶奶）◄──────┐
  │  拾取「信箱钥匙」      │
  │  门被锁住              │
  ▼                        │
H2A（齿轮机关小游戏）──────┘  完成小游戏后门打开
  │
  ▼
H3（楼上）
  │
  ▼
H4（信箱）
  │  用钥匙打开信箱 → 拾取「船票」
  ▼
H2（返回主厅）
  │  把船票交给老奶奶 → 结局
```

### 场景介绍

| 场景 | 说明 |
|:---:|------|
| **H1** | 游戏起点，玩家从这里进入小岛 |
| **H2** | 主厅，老奶奶在此处。可拾取信箱钥匙；门需完成小游戏后才能打开通往 H3 |
| **H2A** | 齿轮机关小游戏——圆圈滑块谜题，将图标移到正确位置即可通关 |
| **H3** | 楼上区域，老头子曾在此捣鼓时间机器 |
| **H4** | 信箱所在地，使用信箱钥匙打开信箱获取船票 |

### H2A 小游戏规则

- 场景中有若干圆圈格子，部分格子内有图标
- 点击圆圈内的图标，它会移动到相邻的空格子中
- 将所有图标移动到与目标图案一致的位置即可通关（正确位置的图标会变绿）
- 点击齿轮按钮可以重新开始小游戏

---

## 🗂️ 项目结构

```
MissLand/
└── Puzzle/Puzzlegame/          # Unity 项目根目录
    ├── Assets/
    │   ├── Scripts/
    │   │   ├── Common/
    │   │   │   └── patterns/
    │   │   │       ├── Singleton/            # 单例基类（Mono & 非Mono）
    │   │   │       └── DevelopmentTool/      # 调试日志工具
    │   │   ├── Managers/
    │   │   │   ├── EventManager/             # 事件中心（发布-订阅，支持泛型参数）
    │   │   │   ├── SceneManager/             # 场景切换管理器（淡入淡出+缩放过渡）
    │   │   │   └── PropItemManager/          # 道具栏管理器
    │   │   ├── Game/
    │   │   │   ├── Scenes/
    │   │   │   │   ├── Scenebase.cs          # 场景基类（交互UI→目标场景映射）
    │   │   │   │   ├── TransPair.cs          # 交互UI与场景的映射对
    │   │   │   │   ├── H1/SceneH1.cs         # 起点场景
    │   │   │   │   ├── H2/SceneH2.cs         # 主厅场景
    │   │   │   │   ├── H2A/SceneH2A.cs       # 小游戏场景
    │   │   │   │   ├── H3/SceneH3.cs         # 楼上场景
    │   │   │   │   └── H4/SceneH4.cs         # 信箱场景
    │   │   │   └── Interactable/
    │   │   │       ├── InteractableUIBase.cs # 可交互UI基类（点击/悬停事件）
    │   │   │       ├── PropItem.cs           # 道具基类
    │   │   │       ├── H2/                   # 主厅交互物（门、钥匙、楼梯、箭头）
    │   │   │       ├── H2A/                  # 小游戏交互物（箭头）
    │   │   │       ├── H3/                   # 楼上交互物（下楼）
    │   │   │       ├── H4/                   # 信箱交互物（门）
    │   │   │       └── CommonUI/PropUI/      # 道具栏UI组件
    │   │   └── ScriptObject/
    │   │       └── PropItemTable.cs          # 道具配置表（ScriptableObject）
    │   ├── Scenes/
    │   │   └── SampleScene.unity             # 主场景（包含全部5个子场景）
    │   ├── CottonPuzzle4/                    # 游戏美术与设计素材
    │   │   └── 游戏素材/
    │   │       ├── UI/                       # UI素材（菜单、道具栏、对话框等）
    │   │       ├── 场景素材/                  # 各场景背景与交互元素
    │   │       │   ├── H1/ ~ H4/             # 五个场景的美术资源
    │   │       │   └── H2A/游戏素材/          # 小游戏专属素材（齿轮、圆圈等）
    │   │       └── 音乐/                      # BGM（PaperWings / OpenRoad）
    │   └── Settings/                         # URP 渲染设置
    ├── Packages/manifest.json                # 依赖包清单
    └── ProjectSettings/                      # Unity 项目设置
```

---

## 🏗️ 技术架构

### 引擎与工具

- **引擎**：Unity 2022.3.62f1c1
- **渲染管线**：Universal Render Pipeline (URP) 14.0.12
- **UI 系统**：UGUI
- **文本**：TextMeshPro 3.0.7
- **可视化脚本**：Unity Visual Scripting 1.9.4

### 核心设计

**1. 单场景多区域切换**

五个游戏区域（H1-H4）并非独立的 Unity 场景，而是同一个 `SampleScene` 中的多个 GameObject。`SceneManager` 通过 SetActive 切换显示，配合淡入淡出 + 缩放动画实现丝滑过渡：

```csharp
// 场景切换流程
// 1. 背景渐显（0.5s）→ 2. 切换激活对象 → 3. 背景渐隐 + 新场景从1.1倍缩放到1.0（0.5s）
```

**2. 数据驱动的场景跳转**

每个场景继承 `Scenebase`，在 Inspector 中通过 `TransPair` 列表配置「可交互UI → 目标场景」的映射。点击交互物时，通过事件中心触发全局场景切换：

```
InteractableUIBase.OnPointerClick()
  → EventManager.CallBack(Hx.SceneChange.Clicked, this)
  → Scenebase.OnSceneChangeIconClicked() 查字典
  → EventManager.CallBack(Global.SceneChange, targetScene)
  → SceneManager.ChangeSceneWithTransition()
```

**3. 事件中心（EventManager）**

基于字典的发布-订阅模式，支持无参、单参、双参三种泛型回调：

| 事件 | 参数 | 说明 |
|------|------|------|
| `Global.SceneChange` | `Scenebase` | 全局场景切换 |
| `H1/H2/H2A/H3/H4.SceneChange.Clicked` | `InteractableUIBase` | 各场景的交互点击 |
| `H2.Prop.Clicked` | `PropItem` | 道具被点击 |

**4. 道具系统**

- `PropItem`：场景中可拾取的道具，继承 `InteractableUIBase`
- `PropItemTable`：ScriptableObject 配置表，存储道具 key、场景图标、道具栏图标
- `PropItemManager`：管理已拾取道具，响应道具点击事件
- `PropUIController`：道具栏 UI，左右箭头切换，选中后显示"抓手"光标

**5. 单例模式**

提供 `Singleton`（MonoBehaviour）和 `SingletonNoMono`（纯 C#）两种基类，`EventManager` 使用非 Mono 单例。

---

## 🚀 快速开始

### 环境要求

- Unity Hub
- Unity **2022.3.62f1c1**（Unity Hub 打开项目时自动提示安装）
- Windows / macOS

### 运行步骤

1. **克隆仓库**
   ```bash
   git clone https://github.com/Ahri-MIko/MissLand.git
   ```

2. **用 Unity Hub 打开项目**
   - Unity Hub → Add → 选择 `MissLand/Puzzle/Puzzlegame` 文件夹
   - 等待资源导入和脚本编译完成

3. **打开主场景**
   - Project 窗口 → `Assets/Scenes/SampleScene.unity`
   - 双击打开，点击 ▶️ Play 开始游戏

### 扩展新场景

1. 在 `SampleScene` 中创建新的 GameObject，添加 `Scenebase` 子类（如 `SceneH5`）
2. 在脚本中注册对应事件监听：
   ```csharp
   EventManager.Instance.AddEventListening<InteractableUIBase>(
       GameEvent.H5.SceneChange.Clicked, OnSceneChangeIconClicked);
   ```
3. 在 `GameEvent` 中添加新场景的事件常量
4. 在 Inspector 中配置 `TransPair`，将交互 UI 映射到目标场景
5. 将新场景对象加入 `SceneManager` 的 `scenes` 列表（通过 `GetComponentsInChildren` 自动收集）

---

## 🎵 音频

| 音乐 | 使用场景 |
|------|----------|
| `PaperWings.mp3` | H1、H2、H3、H4 场景背景音乐 |
| `OpenRoad.mp3` | H2A 小游戏场景背景音乐 |

---

## 👤 开发者

- **你的zrcheng** — 程序开发

> 本项目为一周内完成的解谜游戏开发练习，基于 CottonPuzzle4 设计规范实现。

---

## 📄 许可证

本项目仅供学习和交流使用。美术、音乐等资源版权归原作者所有，未经许可请勿用于商业用途。
