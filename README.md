# ⚡ Window Text Typer (WindowTextInjector)

Ein leistungsfähiges .NET 9 Desktop-Tool zur hardwarenahen Simulation von Tastatur- und Maus-Eingaben für beliebige Zielfelder auf dem Bildschirm.

Speziell konzipiert für **Remote Desktop (RDP)**, **Citrix**, **VMware**, **VNC**, **TeamViewer** und virtuelle Maschinen, bei denen:
- die Windows-Zwischenablage (Clipboard) aus Sicherheitsrichtlinien oder Fehlern **nicht funktioniert / deaktiviert** ist,
- interne UI-Elemente für das Host-Betriebssystem nicht als Steuerelemente greifbar sind (reiner Grafik-Stream).

---

## 🚀 Neue & Wichtige Funktionen

1. **Intelligente Mehrzeilen- & Mehrfeld-Unterstützung (Multi-Row / Formulare)**:
   - Wenn im Eingabefeld mehrere Zeilen eingegeben sind (z.B. `Test` und `Test2`), teilt das Tool das markierte Rechteck automatisch in $N$ vertikale Zeilen-Slots auf.
   - **Ablauf**: Klick in Zeile 1 ➔ tippt `Test` ➔ Klick in Zeile 2 ➔ tippt `Test2`!
   - **Visuelle Hilfslinien im Overlay**: Beim Ziehen des Auswahlrechtecks zeigt das Overlay direkt gestrichelte Trennlinien und Zeilennummern `[1]`, `[2]` an.

2. **Wählbare Mehrzeilen-Modi**:
   - `🎯 Zeilenweise aufteilen (Klick in jede Zeile)`: Klickt vertikal in jede Zeile des markierten Bereichs.
   - `⌨️ Tab-Wechsel (Zeile ➔ Tab ➔ nächste Zeile)`: Tippt Zeile 1, wechselt per `Tab` ins nächste Feld, tippt Zeile 2...
   - `⬇️ Pfeiltaste Runter (Zeile ➔ Runter ➔ nächste Zeile)`: Ideal für Tabellen oder Grid-Eingaben.
   - `📝 Alles in ein einzelnes Feld tippen`: Tippt alles mit Zeilenumbrüchen in ein einziges Feld.

3. **Präzise Zielfenster-Erkennung (Z-Order)**:
   - Erkennt zuverlässig das darunterliegende Fenster und den Prozess (z.B. `mstsc.exe` für Remote Desktop) ohne vom Auswahl-Overlay abgelenkt zu werden.

4. **Visuelle Bereichs- & Textfeld-Markierung (F8)**:
   - Mit Druck auf `F8` oder Klick auf `🎯 Bereich markieren` öffnet sich das Multi-Monitor-Overlay.
   - Erzeugt eine **Live-Thumbnail-Vorschau** mit eingezeichneten Zeilen-Slots.

5. **Hardwarenahe Tastatur-Simulation (F9)**:
   - Low-Level Win32 `SendInput` mit Unicode-Support (`KEYEVENTF_UNICODE`).
   - Einstellbare Zeichenverzögerung (`0ms`, `10ms`, `25ms` für RDP, `50ms` für hohe Latenz).

---

## ⌨️ Globale Hotkeys

| Hotkey | Funktion |
|---|---|
| **`F8`** | Ziel-Bereich / Textbox auf dem Bildschirm markieren |
| **`F9`** | Eingegebenen Text in das/die markierte(n) Feld(er) eintippen |
| **`Esc`** | Bereichsauswahl oder laufenden Tippvorgang abbrechen |

---

## 🛠 Starten & Ausführen

```powershell
cd f:\GoogleAntigravityProjects\WindowTextInjector
dotnet run
```

---

## 🤝 Mitwirken (Contributing)

Beiträge, Fehlerberichte und Verbesserungsvorschläge sind herzlich willkommen!  
Details zum Entwicklungsprozess findest du in der [CONTRIBUTING.md](CONTRIBUTING.md).

---

## 📄 Lizenz & Copyright

Copyright © 2026 Daweki. Alle Rechte vorbehalten.  
Lizenziert unter der [GNU General Public License v3.0 (GPLv3)](LICENSE).
