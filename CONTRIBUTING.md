# Mitwirken an WindowTextInjector (Contributing Guidelines)

Vielen Dank für dein Interesse, zu **WindowTextInjector** beizutragen! 🎉

Wir freuen uns über jede Unterstützung – sei es durch Fehlerberichte, Verbesserungsvorschläge, Dokumentation oder Pull Requests.

---

## 📋 Inhaltsverzeichnis
- [Verhaltenskodex](#verhaltenskodex)
- [Voraussetzungen & Entwicklungsumgebung](#voraussetzungen--entwicklungsumgebung)
- [Entwicklungs-Workflow](#entwicklungs-workflow)
- [Architektur- & Design-Richtlinien](#architektur---design-richtlinien)
  - [1. Low-Level Win32 & RDP-Kompatibilität](#1-low-level-win32--rdp-kompatibilität)
  - [2. UI Design-System (Dark Tech)](#2-ui-design-system-dark-tech)
  - [3. .NET 8 & Single-File Builds](#3-net-8--single-file-builds)
- [Erstellen & Testen](#erstellen--testen)
- [Pull Request Richtlinien](#pull-request-richtlinien)
- [Lizenz](#lizenz)

---

## 🤝 Verhaltenskodex
Wir legen großen Wert auf einen respektvollen, konstruktiven und professionellen Umgang miteinander. Bitte behandle alle Mitwirkenden mit Höflichkeit und Wertschätzung.

---

## 💻 Voraussetzungen & Entwicklungsumgebung

- **Betriebssystem**: Windows 10 / Windows 11 (oder Windows Server)
- **SDK**: [.NET 8.0 SDK (LTS)](https://dotnet.microsoft.com/download/dotnet/8.0) oder höher
- **IDE**: Visual Studio 2022 (ab 17.8), Visual Studio Code (mit C# Dev Kit) oder JetBrains Rider

---

## 🚀 Entwicklungs-Workflow

1. **Repository forken**:
   Erstelle einen Fork des Repositories auf GitHub: `https://github.com/Daweki/WindowTextInjector`
2. **Branch erstellen**:
   Erstelle einen aussagekräftigen Feature- oder Fix-Branch:
   ```bash
   git checkout -b feature/mein-neues-feature
   # oder
   git checkout -b fix/fehler-beschreibung
   ```
3. **Änderungen vornehmen**:
   Implementiere deine Anpassungen und beachte die Architektur-Richtlinien.
4. **Kompilieren & Testen**:
   Stelle sicher, dass das Projekt fehler- und warnungsfrei baut:
   ```powershell
   dotnet build
   dotnet run
   ```
5. **Commit & Push**:
   Nutze prägnante Commit-Nachrichten (z.B. nach [Conventional Commits](https://www.conventionalcommits.org/)):
   ```bash
   git commit -m "feat: Add custom character delay preset"
   git push origin feature/mein-neues-feature
   ```
6. **Pull Request einreichen**:
   Erstelle einen Pull Request auf GitHub gegen den `main`-Branch.

---

## 📐 Architektur- & Design-Richtlinien

### 1. Low-Level Win32 & RDP-Kompatibilität
- **Keine Abhängigkeit von der Zwischenablage (Clipboard)**:
  Das Tool ist speziell für Remote Desktop (RDP, Citrix, VMware, VNC) konzipiert, bei denen die Zwischenablage deaktiviert sein kann. Die Texteingabe muss stets über hardwarenahe Win32 `SendInput` Tastatur-Simulation (`KEYEVENTF_UNICODE`) erfolgen.
- **Präzise Koordinaten & DPI**:
  Verwende für Koordinaten physische Bildschirmkoordinaten (`Cursor.Position`), um DPI-Skalierungsverschiebungen auf Multi-Monitor-Setups zu vermeiden.
- **Fenstererkennung**:
  Nutze `EnumWindows` in Z-Order unter Ausschluss des eigenen Prozesses, damit unterliegende Zielfenster auch unter transparenten Overlays zuverlässig erkannt werden.

### 2. UI Design-System (Dark Tech)
Für alle Dialoge, Steuerelemente und Erweiterungen gilt die verbindliche **Dark Tech** Farbpalette:

| Element / Funktion | Hex Code | RGB | Verwendung |
|---|---|---|---|
| **Hintergrund** | `#121820` | `18, 24, 32` | Hauptfenster-Hintergrund |
| **Kopf- / Fußleiste** | `#0F151D` | `15, 21, 29` | Header & Footer |
| **Karten / Panels** | `#1B2530` | `27, 37, 48` | Container & Sektionen |
| **Input Background** | `#10161E` | `16, 22, 30` | Textfelder, Dropdowns |
| **Hauptfarbe (Blau)** | `#1976D2` | `25, 118, 210` | Normale Aktionen, primäre Buttons |
| **Akzent (Cyan)** | `#00BCD4` | `0, 188, 212` | Aktive Verbindung, Zielmarkierung, Koordinaten |
| **Text (Primär)** | `#E8EEF2` | `232, 238, 242` | Überschriften, Haupttext |
| **Sekundärtext / Labels** | `#8B9AA8` | `139, 154, 168` | Beschriftungen, Metadaten, inaktive Elemente |
| **Sekundärbuttons** | `#253342` | `37, 51, 66` | Neutrale Buttons (Demo, Clipboard, Leeren) |
| **Erfolg (Grün)** | `#4CAF50` | `76, 175, 80` | Senden, Erfolg, Synchronisation |
| **Warnung (Orange)** | `#FFB300` | `255, 179, 0` | Warnungen, manueller Eingriff |
| **Fehler / Abbruch (Rot)** | `#EF5350` | `239, 83, 80` | Fehler, Abbrechen / Stop |
| **Konfiguration (Violett)** | `#AB47BC` | `171, 71, 188` | Konfiguration, Administration |

### 3. .NET 8 & Single-File Builds
- Das Projekt zielt auf **`.NET 8 (LTS)`** (`net8.0-windows`) mit `<RollForward>LatestMajor</RollForward>`.
- Debug-Symbole werden als **`<DebugType>embedded</DebugType>`** eingebunden.

---

## 📦 Erstellen & Testen

### Entwicklung & Lokaler Start
```powershell
dotnet build
dotnet run
```

### Eigenständige Single-File-EXE erstellen (Self-Contained)
```powershell
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:EnableCompressionInSingleFile=true -o Publish
```

Die fertige Datei liegt anschließend unter `Publish/WindowTextInjector.exe`.

---

## 🔍 Pull Request Richtlinien

- Bitte beschreibe im PR kurz:
  - Welches Problem gelöst oder welches Feature hinzugefügt wurde.
  - Wie die Änderungen getestet wurden.
- Achte auf sauberen, gut lesbaren C#-Code.
- Keine temporären Dateien, Binaries (`bin/`, `obj/`, `Publish/`) in den Commit aufnehmen (wird durch `.gitignore` geregelt).

---

## 📄 Lizenz

Durch das Einreichen von Beiträgen erklärst du dich damit einverstanden, dass deine Beiträge unter den Bedingungen der **GNU General Public License v3.0 (GPLv3)** lizenziert werden.

Copyright © 2026 Daweki. Alle Rechte vorbehalten.
