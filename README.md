# PCL2 快照版可构建源码

此目录从 `../Plain Craft Launcher 2.exe`（SHA-256：`5B64D6D540C376390470CEA3AB99D47661E8BCA81BE2BA647EA83E7D2E9428FA`）反编译而来。程序集版本为 2.99.0.0，快照版版本代码为 414。这里保留了快照 EXE 中的 `ModSecret` 与 `PageOtherTest` 方法体；公开仓库中的对应模块并不完整。

## 构建

环境：Windows、.NET SDK 10.0、.NET Framework 4.8 Targeting Pack、Windows PowerShell。

在此目录运行：

```powershell
dotnet build PCL2-Snapshot.csproj -c Debug -p:EnableWindowsTargeting=true
```

输出：`bin/Debug/net48/Plain Craft Launcher 2.exe`。已执行 `dotnet clean` 后的全量构建，退出码为 0。生成 EXE 的文件版本为 2.99.0.0；内嵌资源名称清单与输入 EXE 一致（131 项）。

## 工程内容

- `PCL/`：165 个从 EXE 还原的 C# 文件，以及 61 个由 BAML 还原的 XAML 文件。
- `embedded/`：提取出的程序集和其他原始资源，供项目引用。
- `PCL.Resources.resx`：原程序集内嵌资源。
- `tools/FixGeneratedWpf.ps1` 与 `Directory.Build.targets`：构建时移除 WPF 自动生成代码中与反编译事件属性重复的字段和方法。

为使反编译结果能通过 C# 编译，修正了依赖路径、XAML 自身程序集引用、VB.NET Module 的静态类表示、验证器基类命名、少量闭包变量与迭代器代码。原始导出保留在 `../snapshot-source/`，可对照检查这些修改。

`ModLoader.LoaderTask<TIn, TOut>` 的输入委托保留为 `Func<TIn>`，修复了值类型输入（如皮肤加载使用的字符串元组）在启动时转换成 `Func<object>` 导致的 `InvalidCastException`。

## 主题

快照构建中，主题页定义的 0–14 号主题及内置的 42 号特殊主题均已解锁。`ModSecret.ThemeCheckOne` 负责主题启用与切换校验；该修改只作用于此重建工程。

## MC 下载

`RestrictMcDownload` 已设为 `false`。由于原 EXE 将该常量折叠进调用路径，快照工程还恢复了版本列表加载、整合包文件选择与格式分派、整合包资源页安装入口。公开 VB 参考工程中的同名常量也已改为 `False`。已验证两种工程可构建；尚未执行完整下载与安装回归。

## 参考与边界

`../reference-open-source/` 检出的是 [Meloong-Git/PCL](https://github.com/Meloong-Git/PCL) 的 `6b9a50df911c9d68b69b24c979efba477fb14b67` 提交。它的 Snapshot 配置也能构建，但 `ModSecret`、`PageOtherTest` 内容明显少于目标 EXE，因此本工程以快照反编译代码为基底。

这是可编译的 C# 重建工程，无法恢复原始 VB.NET 注释和局部变量名，也不保证生成文件与原 EXE 字节相同。已验证编译、程序集资源清单及实际启动：2026-10-21 程序运行 8 秒，主页、头像和初始加载正常，未见异常。其余功能尚未做完整回归测试。
## 独立构建脚本与 CI

在本目录运行：

```powershell
.\build.ps1 -Configuration Release
```

脚本使用工程自带的资源及 .NET 10 SDK 构建 .NET Framework 4.8 程序，生成 `artifacts/PCL2-Snapshot-Release.zip` 和对应的 SHA-256 文件。归档包含 EXE、相邻 DLL、配置文件、PDB 与逐文件校验清单。将本目录作为 GitHub 仓库根目录时，`.github/workflows/build.yml` 会在 Windows 上分别构建 Debug 与 Release。此工作流不使用上游 PCL 的构建文件、PCL2Help、COS 凭据或 GitHub Secrets。

## 默认更新行为

新安装默认将 `SystemSystemUpdate` 设为 3（关闭更新提示），并跳过标记为更新的自动公告，因此不会由这些公告触发更新。手动“检查更新”按钮仍可使用；已有的用户设置保持原值。启动时仍会请求 `notice.cfg`，用于刷新公告及其他服务端配置。