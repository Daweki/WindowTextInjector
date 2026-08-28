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

## 3. UI Design System & Semantic Color Palette (Dark Tech)
For interface, SQL, database and automation tools, always use the serious, technical **Dark Tech** color palette:

| Element | Hex Code | RGB | Verwendung |
|---|---|---|---|
| **Hintergrund** | `#121820` | `18, 24, 32` | Hauptfenster-Hintergrund |
| **Header / Footer** | `#0F151D` | `15, 21, 29` | Kopf- und Fußleisten |
| **Panels / Cards** | `#1B2530` | `27, 37, 48` | Container, Karten, Sektionen |
| **Input Background** | `#10161E` | `16, 22, 30` | Textfelder, Dropdowns |
| **Hauptfarbe (Blau)** | `#1976D2` | `25, 118, 210` | Normale Aktionen, primäre Buttons, Schnittstelle |
| **Akzent (Cyan)** | `#00BCD4` | `0, 188, 212` | Aktive Verbindung, Zielmarkierung, Koordinaten, Datenfluss |
| **Text (Primär)** | `#E8EEF2` | `232, 238, 242` | Überschriften, Haupttext |
| **Sekundärtext / Labels** | `#8B9AA8` | `139, 154, 168` | Beschriftungen, Metadaten, inaktive Elemente |
| **Sekundärbuttons** | `#253342` | `37, 51, 66` | Neutrale Buttons (Demo, Clipboard, Leeren) |
| **Erfolg (Grün)** | `#4CAF50` | `76, 175, 80` | Senden, Erfolg, Synchronisation |
| **Warnung (Orange)** | `#FFB300` | `255, 179, 0` | Warnungen, manueller Eingriff |
| **Fehler / Abbruch (Rot)** | `#EF5350` | `239, 83, 80` | Fehler, Abbrechen / Stop |
| **Konfiguration (Violett)** | `#AB47BC` | `171, 71, 188` | Konfiguration, Administration |

## 4. Git & Repository
- **GitHub Account**: `Daweki`
- **Repository URL**: `https://github.com/Daweki/WindowTextInjector.git`
- **Branch**: `main`
