using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowTextInjector.Models;
using WindowTextInjector.Native;
using WindowTextInjector.Services;

namespace WindowTextInjector.Forms;

public partial class MainForm : Form
{
    private const int HOTKEY_ID_F8 = 1001;
    private const int HOTKEY_ID_F9 = 1002;
    private const int VK_F8 = 0x77;
    private const int VK_F9 = 0x78;

    private TargetArea? _currentTarget;
    private readonly KeyboardTypingService _typingService = new();
    private CancellationTokenSource? _typingCts;
    private bool _isTyping = false;

    public MainForm()
    {
        InitializeComponent();

        PopulateDropdowns();
        WireEvents();
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        RegisterGlobalHotkeys();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        UnregisterGlobalHotkeys();
        _currentTarget?.Dispose();
        _typingCts?.Cancel();
        base.OnFormClosing(e);
    }

    private void RegisterGlobalHotkeys()
    {
        bool regF8 = Win32Input.RegisterHotKey(Handle, HOTKEY_ID_F8, Win32Input.MOD_NOREPEAT, VK_F8);
        bool regF9 = Win32Input.RegisterHotKey(Handle, HOTKEY_ID_F9, Win32Input.MOD_NOREPEAT, VK_F9);

        if (!regF8 || !regF9)
        {
            lblStatus.Text = "Hinweis: Globale Hotkeys (F8/F9) konnten nicht vollständig registriert werden.";
        }
    }

    private void UnregisterGlobalHotkeys()
    {
        Win32Input.UnregisterHotKey(Handle, HOTKEY_ID_F8);
        Win32Input.UnregisterHotKey(Handle, HOTKEY_ID_F9);
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        if (m.Msg == Win32Input.WM_HOTKEY)
        {
            int hotkeyId = m.WParam.ToInt32();
            if (hotkeyId == HOTKEY_ID_F8)
            {
                if (!_isTyping)
                {
                    StartCaptureOverlay();
                }
            }
            else if (hotkeyId == HOTKEY_ID_F9)
            {
                if (!_isTyping)
                {
                    _ = StartTypingAsync();
                }
            }
        }
    }

    private void PopulateDropdowns()
    {
        cmbMultiLine.Items.Clear();
        cmbMultiLine.Items.Add(new MultiLineItem("📝 Normal (In ausgewähltes Feld tippen)", MultiLineMode.SingleFieldWithEnter));
        cmbMultiLine.Items.Add(new MultiLineItem("🎯 Zeilenweise aufteilen (Klick in jede Zeile)", MultiLineMode.AutoRowClick));
        cmbMultiLine.Items.Add(new MultiLineItem("⌨️ Tab-Wechsel (Zeile ➔ [Tab] ➔ nächste Zeile)", MultiLineMode.TabBetweenLines));
        cmbMultiLine.Items.Add(new MultiLineItem("⬇️ Pfeiltaste Runter (Zeile ➔ [Runter] ➔ nächste Zeile)", MultiLineMode.DownArrowBetweenLines));
        cmbMultiLine.SelectedIndex = 0; // Default: Single field (Normal)

        cmbSpeed.Items.Clear();
        cmbSpeed.Items.Add(new SpeedItem("0 ms (Sofort / Max. Geschwindigkeit)", 0));
        cmbSpeed.Items.Add(new SpeedItem("10 ms (Standard)", 10));
        cmbSpeed.Items.Add(new SpeedItem("25 ms (Empfohlen für Remote Desktop)", 25));
        cmbSpeed.Items.Add(new SpeedItem("50 ms (Hohe RDP-Latenz / Sehr sicher)", 50));
        cmbSpeed.Items.Add(new SpeedItem("100 ms (Schrittweise / Debugging)", 100));
        cmbSpeed.SelectedIndex = 2; // 25ms default

        cmbDelay.Items.Clear();
        cmbDelay.Items.Add(new DelayItem("100 ms (Minimal)", 100));
        cmbDelay.Items.Add(new DelayItem("250 ms (Empfohlen)", 250));
        cmbDelay.Items.Add(new DelayItem("500 ms (Halbe Sekunde)", 500));
        cmbDelay.Items.Add(new DelayItem("1000 ms (1 Sekunde)", 1000));
        cmbDelay.SelectedIndex = 1; // 250ms default
    }

    private void WireEvents()
    {
        btnCaptureTarget.Click += (s, e) => StartCaptureOverlay();
        btnTestClick.Click += async (s, e) => await PerformTestClickAsync();
        btnStartTyping.Click += async (s, e) => await StartTypingAsync();
        btnStopTyping.Click += (s, e) => CancelTyping();

        btnPasteClipboard.Click += (s, e) =>
        {
            if (Clipboard.ContainsText())
            {
                txtInput.Text = Clipboard.GetText();
            }
        };

        btnClearInput.Click += (s, e) => txtInput.Clear();

        btnInsertSample.Click += (s, e) =>
        {
            txtInput.Text = "Hello Remote Desktop!\r\nDieser Text wird direkt als Tastatur-Eingabe simuliert (auch ohne Zwischenablage).";
        };

        cmbMultiLine.SelectedIndexChanged += (s, e) => UpdateStats();
        txtInput.TextChanged += (s, e) => UpdateStats();
        UpdateStats();
    }

    private int GetNormalizedLineCount()
    {
        string text = txtInput.Text.Replace("\r\n", "\n").Replace('\r', '\n');
        if (string.IsNullOrEmpty(text)) return 1;
        string[] lines = text.Split('\n');
        return Math.Max(1, lines.Length);
    }

    private void UpdateStats()
    {
        int charCount = txtInput.Text.Length;
        int lineCount = GetNormalizedLineCount();
        lblStats.Text = $"Zeichen: {charCount}  |  Zeilen: {lineCount}";

        if (_currentTarget != null)
        {
            Point center = _currentTarget.CenterPoint;
            var mode = cmbMultiLine.SelectedItem is MultiLineItem mi ? mi.Mode : MultiLineMode.SingleFieldWithEnter;
            string rowInfo = (mode == MultiLineMode.AutoRowClick && lineCount > 1) ? $" ({lineCount} Zeilen-Slots)" : "";
            lblTargetCoord.Text = $"Koordinate: ({center.X}, {center.Y})  |  Größe: {_currentTarget.Bounds.Width} × {_currentTarget.Bounds.Height} px{rowInfo}";
        }
    }

    private void StartCaptureOverlay()
    {
        WindowState = FormWindowState.Minimized;
        Thread.Sleep(200);

        int lineCount = GetNormalizedLineCount();
        var mode = cmbMultiLine.SelectedItem is MultiLineItem mi ? mi.Mode : MultiLineMode.SingleFieldWithEnter;
        bool showDividers = mode == MultiLineMode.AutoRowClick;

        using ScreenOverlayForm overlay = new(lineCount, showDividers);
        DialogResult dr = overlay.ShowDialog(this);

        WindowState = FormWindowState.Normal;
        BringToFront();
        Activate();

        if (dr == DialogResult.OK && overlay.SelectedTarget != null)
        {
            _currentTarget?.Dispose();
            _currentTarget = overlay.SelectedTarget;

            Point center = _currentTarget.CenterPoint;
            string rowInfo = (mode == MultiLineMode.AutoRowClick && lineCount > 1) ? $" ({lineCount} Zeilen-Slots)" : "";
            lblTargetCoord.Text = $"Koordinate: ({center.X}, {center.Y})  |  Größe: {_currentTarget.Bounds.Width} × {_currentTarget.Bounds.Height} px{rowInfo}";
            lblTargetWindow.Text = $"Fenster: {_currentTarget.WindowTitle}";
            lblTargetProcess.Text = $"Prozess: {_currentTarget.ProcessName}";

            picThumbnail.Image?.Dispose();
            picThumbnail.Image = _currentTarget.ThumbnailPreview != null ? new Bitmap(_currentTarget.ThumbnailPreview) : null;

            btnTestClick.Enabled = true;
            lblStatus.Text = $"Ziel erfolgreich markiert ({center.X}, {center.Y}). Bereit zum Eintippen!";
        }
        else
        {
            lblStatus.Text = "Bereichsauswahl abgebrochen.";
        }
    }

    private async Task PerformTestClickAsync()
    {
        if (_currentTarget == null) return;

        if (chkBringToFront.Checked && _currentTarget.WindowHandle != IntPtr.Zero)
        {
            Win32Input.ForceForegroundWindow(_currentTarget.WindowHandle);
            await Task.Delay(150);
        }

        int lineCount = GetNormalizedLineCount();
        var multiLineMode = ((MultiLineItem)cmbMultiLine.SelectedItem!).Mode;

        if (lineCount > 1 && multiLineMode == MultiLineMode.AutoRowClick)
        {
            var rowPoints = _currentTarget.GetRowCenterPoints(lineCount);
            lblStatus.Text = $"Führe Test-Klicks auf {rowPoints.Count} Zeilen aus...";
            for (int i = 0; i < rowPoints.Count; i++)
            {
                lblStatus.Text = $"Test-Klick auf Zeile {i + 1}/{rowPoints.Count}: ({rowPoints[i].X}, {rowPoints[i].Y})...";
                Win32Input.ClickAt(rowPoints[i].X, rowPoints[i].Y);
                await Task.Delay(350);
            }
            lblStatus.Text = $"Test-Klicks auf alle {rowPoints.Count} Zeilen abgeschlossen.";
        }
        else
        {
            Point center = _currentTarget.CenterPoint;
            lblStatus.Text = $"Führe Test-Klick auf ({center.X}, {center.Y}) aus...";
            Win32Input.ClickAt(center.X, center.Y);
            lblStatus.Text = $"Test-Klick auf ({center.X}, {center.Y}) abgeschlossen.";
        }
    }

    private async Task StartTypingAsync()
    {
        if (_isTyping) return;

        if (_currentTarget == null)
        {
            MessageBox.Show(
                "Bitte markiere zuerst mit [F8] oder dem Button 'Bereich markieren' das gewünschte Zielfeld.",
                "Kein Ziel ausgewählt",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return;
        }

        string textToType = txtInput.Text;
        if (string.IsNullOrEmpty(textToType))
        {
            MessageBox.Show(
                "Bitte gib vorher den gewünschten Text in das Textfeld ein.",
                "Kein Text vorhanden",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        _isTyping = true;
        _typingCts = new CancellationTokenSource();

        btnStartTyping.Enabled = false;
        btnCaptureTarget.Enabled = false;
        btnTestClick.Enabled = false;
        btnStopTyping.Enabled = true;
        prgTyping.Value = 0;

        TypingOptions options = new()
        {
            PerformFocusClick = chkPerformClick.Checked,
            BringWindowToFront = chkBringToFront.Checked,
            ClearTargetFirst = chkClearFirst.Checked,
            PressEnterAtEnd = chkPressEnter.Checked,
            PressTabAtEnd = chkPressTab.Checked,
            MultiLineMode = ((MultiLineItem)cmbMultiLine.SelectedItem!).Mode,
            CharDelayMs = ((SpeedItem)cmbSpeed.SelectedItem!).DelayMs,
            PostClickDelayMs = ((DelayItem)cmbDelay.SelectedItem!).DelayMs,
            LineDelayMs = 150
        };

        var progressReporter = new Progress<TypingProgress>(p =>
        {
            lblStatus.Text = p.StatusMessage;
            prgTyping.Value = Math.Clamp(p.Percent, 0, 100);
        });

        try
        {
            await _typingService.TypeTextIntoTargetAsync(
                _currentTarget,
                textToType,
                options,
                progressReporter,
                _typingCts.Token
            );

            if (chkClearAfterSend.Checked)
            {
                txtInput.Clear();
            }

            lblStatus.Text = "Erfolg: Text wurde vollständig in das Zielfeld eingetippt!";
        }
        catch (OperationCanceledException)
        {
            lblStatus.Text = "Eingabe vom Benutzer abgebrochen.";
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Fehler: {ex.Message}";
            MessageBox.Show($"Fehler beim Eintippen: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _isTyping = false;
            btnStartTyping.Enabled = true;
            btnCaptureTarget.Enabled = true;
            btnTestClick.Enabled = true;
            btnStopTyping.Enabled = false;
            _typingCts.Dispose();
            _typingCts = null;
        }
    }

    private void CancelTyping()
    {
        if (_isTyping && _typingCts != null)
        {
            _typingCts.Cancel();
            lblStatus.Text = "Breche Eingabe ab...";
        }
    }

    private record MultiLineItem(string DisplayName, MultiLineMode Mode)
    {
        public override string ToString() => DisplayName;
    }

    private record SpeedItem(string DisplayName, int DelayMs)
    {
        public override string ToString() => DisplayName;
    }

    private record DelayItem(string DisplayName, int DelayMs)
    {
        public override string ToString() => DisplayName;
    }
}
