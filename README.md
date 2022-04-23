# DancingLine-Fanmade-Template

使用 Unity 与 C# 编写的 Dancing Line 饭制模板

## 适用 Unity 版本

Unity: 2021.2.3f1c1

## 更新日志

### Beta 0.2.1

2022.4.23

- 有关 Camera Bind 的类、方法、变量与对象更名为 Camera Arm
- 修改 CameraArmChanger：ToPosition 的补间时间不再由 MainLine.CameraArmPositon 控制，而与 CameraArmRotation 等一样受 Needtime 控制
- CameraArmChanger 新增 ToNeedtime 与 EasingFunction：前者可更改 MainLine.FollowNeedtime，后者可选择补间时的缓动函数
- 修改 TaperAutoCreater：不再受 AFF 文件内 Timing() 语句的干扰

### Beta 0.2.0

2022.4.17

- 新增脚本 TaperAutoCreater：通过 .aff 文件中的地面 Tap 自动生成 Taper
- 新增脚本 GenerateLTBTrigger：通过手动输入 Beat 列表来生成 Taper

### Beta 0.1.1

2022.3.24

- 新增 Wall 及撞墙判定
- 修复了 Main Line 出发及落地时生成的第一条线尾在此后首次转弯时突起的问题

### Beta 0.1.0

2022.3.23

- 项目创建，新增 Main Line 的操控及摄像机平滑跟随
