# 🎮 UnityTools  
*A collection of handy Unity Editor tools to streamline your workflow.*

---

## 🚀 How to Install and Use the Tools

1. **Clone or Download this Repository**

2. **Open or Create a Unity Project**

3. **Add the Tools to Your Unity Project**  
   Copy the `Editor` folder from this repository into your Unity project's `Assets/` folder. Your project should look like:
   
   Assets/
   ├── Editor/
   │ ├── EditorMenus.cs
   │ ├── IP_ReplaceObject_Editors.cs
   │ ├── ProjectSetupTool/

Unity automatically detects scripts inside `Editor` folders and compiles them into the Editor assembly.

4. **Access the Tools Inside Unity**  
If your tools use `MenuItem` attributes, you'll find them in the Unity top menu bar, typically under:
- `Tools/YourToolName`
- `Window/YourCustomTool`

---

## 📁 1) Project Setup Tool

*Quickly generate a standardized project folder and scene structure with just a few clicks.*

### 🔧 Features

- Lets you name your project/game.
- Automatically creates a folder structure under `Assets/{GameName}`.
- Generates subfolders for:
- Art (Textures, Materials, Animation)
- Code (Scripts, Shaders)
- Resources (Characters, UI)
- Prefabs (UI, Characters)
- Scenes (GameScene, MainMenu, LoadingScreen)
- Saves three empty scenes with basic default game objects.

🔍 **Find it in Unity:**  
Tools → Project → Project Setup Tool
---

## 🔄 2) Replace Selected Objects Tool

*Quickly replace one or more selected GameObjects in your scene with a new prefab or object.*

### 🔧 Features

- Keeps **position**, **rotation**, **scale**, and **parent** of the original objects.
- Supports **multi-selection**.
- Works with **prefabs** or any GameObject.
- Fully **undoable** via `Ctrl + Z` / `Cmd + Z`.

🔍 **Find it in Unity:** 
MyTools → Project → Replace Selected Objects
