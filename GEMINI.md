# Project Preferences & Architecture Guidelines: WindowTextInjector

## 1. .NET & Build Standards
- **Target Framework**: Always use `.NET 8 (LTS)` (`net8.0-windows`) for maximum enterprise and legacy desktop compatibility.
- **RollForward**: Use `<RollForward>LatestMajor</RollForward>` to seamlessly run on .NET 8, .NET 9, and future .NET versions.
- **Embedded PDBs**: Always set `<DebugType>embedded</DebugType>` so that debug symbols and stack trace line numbers are embedded directly into the binary without generating external `.pdb` files.
- **Single-File Publishing**:
  ```powershell
  dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:EnableCompressionInSingleFile=true -o Publish
  ```

## 2. Remote Desktop & Input Automation Architecture
- **No Clipboard / No UIA Dependency**: For Remote Desktop (RDP, Citrix, VMware, VNC), input must rely strictly on physical mouse coordinate clicks and low-level `SendInput` keyboard simulation (`KEYEVENTF_UNICODE`).
- **Coordinate Precision & DPI**: Always capture screen coordinates directly from physical `Cursor.Position` (not WinForms scaled client coords) to prevent any DPI scaling drift.
- **Topmost Overlay & Window Detection**: Use `EnumWindows` in Z-order filtering out `Environment.ProcessId` to reliably detect the underlying target application (e.g. `mstsc.exe`, `notepad.exe`) beneath full-screen overlays.
- **Multi-Line Modes**:
  - Default: `SingleFieldWithEnter` (Normal text box typing into single center point).
  - Optional: `AutoRowClick` (slices rectangle into $N$ vertical rows for multi-field forms/tables).

## 3. Git & Repository
- **GitHub Account**: `Daweki`
- **Repository URL**: `https://github.com/Daweki/WindowTextInjector.git`
- **Branch**: `main`
