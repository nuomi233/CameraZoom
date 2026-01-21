# CameraZoom v1.0

为IL2CPP Unity游戏制作的摄影机控制插件。

支持自由视角、时间暂停功能。

目前适用于《少女与学院城》，理论上可以支持其他IL2CPP Unity制作的、带视角跟随的3D固定视角类银游戏。

## 如何安装
1. 安装 [**BepInEx 6.0 (IL2CPP)**](https://builds.bepinex.dev/projects/bepinex_be)。
2. 下载 [`CameraZoom.dll`](https://github.com/nuomi233/CameraZoom/releases/download/v1.0/CameraZoom.dll)。
3. 放入游戏目录：`BepInEx/plugins`。

## 按键说明
自由视角默认锁定。

按 **0** 切换相机是否跟随人物，按 **9** 解锁鼠标操作。

如果视角移动混乱，按\重置视角即可。

| 按键 | 功能描述 |
| :--- | :--- |
| **0** | 自由相机开关 |
| **9** | 鼠标控制锁定/解锁 |
| **Backspace** | 时间暂停/继续 |
| **右键** | 目标点环绕旋转 |
| **左键** | 按住前后移动相机 |
| **中键** | 整体平面平移 |
| **滚轮** | 调整视角距离 |
| **\\** | 视角重置归零 |

## 🗑 如何卸载
删除 `BepInEx/plugins/CameraZoom.dll` 即可。
