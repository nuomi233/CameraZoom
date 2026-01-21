# CameraZoom v1.0

为IL2CPP Unity游戏制作的摄影机控制插件。

支持自由视角、时间暂停功能。

目前适用于《少女与学院城》，理论上可能支持其他IL2CPP Unity制作的、带视角跟随的3D固定视角横版游戏，但未经测试。

## 如何安装
1. 确保游戏已安装 [BepInEx 6.0 (IL2CPP)](https://builds.bepinex.dev/projects/bepinex_be) 环境，安装最新的`BepInEx-Unity.IL2CPP-win-x64`版本（注意不是Mono版本）。初次安装后需启动一次游戏生成Plugins文件夹。
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
| **鼠标右键** | 目标点环绕旋转 |
| **鼠标左键** | 按住前后移动相机 |
| **鼠标中键** | 整体平面平移 |
| **鼠标滚轮** | 调整视角距离 |
| **\\** | 视角重置归零 |

## 如何卸载
删除 `BepInEx/plugins/CameraZoom.dll` 即可。

## 备注

本工具仅供学习研究使用。

本项目为开源且免费，不用于任何商业牟利行为。
