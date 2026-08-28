namespace WindowTextInjector.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblAppTitle;
    private System.Windows.Forms.Label lblAppSubtitle;
    private System.Windows.Forms.Label lblHotkeysBadge;

    private System.Windows.Forms.Panel pnlTarget;
    private System.Windows.Forms.Label lblTargetHeader;
    private System.Windows.Forms.PictureBox picThumbnail;
    private System.Windows.Forms.Label lblTargetCoord;
    private System.Windows.Forms.Label lblTargetWindow;
    private System.Windows.Forms.Label lblTargetProcess;
    private System.Windows.Forms.Button btnCaptureTarget;
    private System.Windows.Forms.Button btnTestClick;

    private System.Windows.Forms.Panel pnlInput;
    private System.Windows.Forms.Label lblInputHeader;
    private System.Windows.Forms.TextBox txtInput;
    private System.Windows.Forms.Label lblStats;
    private System.Windows.Forms.Button btnPasteClipboard;
    private System.Windows.Forms.Button btnClearInput;
    private System.Windows.Forms.Button btnInsertSample;

    private System.Windows.Forms.Panel pnlOptions;
    private System.Windows.Forms.Label lblOptionsHeader;
    private System.Windows.Forms.Label lblMultiLine;
    private System.Windows.Forms.ComboBox cmbMultiLine;
    private System.Windows.Forms.Label lblSpeed;
    private System.Windows.Forms.ComboBox cmbSpeed;
    private System.Windows.Forms.Label lblDelay;
    private System.Windows.Forms.ComboBox cmbDelay;
    private System.Windows.Forms.CheckBox chkPerformClick;
    private System.Windows.Forms.CheckBox chkPressEnter;
    private System.Windows.Forms.CheckBox chkPressTab;
    private System.Windows.Forms.CheckBox chkClearFirst;
    private System.Windows.Forms.CheckBox chkClearAfterSend;
    private System.Windows.Forms.CheckBox chkBringToFront;

    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Button btnStartTyping;
    private System.Windows.Forms.Button btnStopTyping;
    private System.Windows.Forms.ProgressBar prgTyping;
    private System.Windows.Forms.Label lblStatus;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlHeader = new System.Windows.Forms.Panel();
        lblHotkeysBadge = new System.Windows.Forms.Label();
        lblAppSubtitle = new System.Windows.Forms.Label();
        lblAppTitle = new System.Windows.Forms.Label();

        pnlTarget = new System.Windows.Forms.Panel();
        btnTestClick = new System.Windows.Forms.Button();
        btnCaptureTarget = new System.Windows.Forms.Button();
        lblTargetProcess = new System.Windows.Forms.Label();
        lblTargetWindow = new System.Windows.Forms.Label();
        lblTargetCoord = new System.Windows.Forms.Label();
        picThumbnail = new System.Windows.Forms.PictureBox();
        lblTargetHeader = new System.Windows.Forms.Label();

        pnlInput = new System.Windows.Forms.Panel();
        btnInsertSample = new System.Windows.Forms.Button();
        btnClearInput = new System.Windows.Forms.Button();
        btnPasteClipboard = new System.Windows.Forms.Button();
        lblStats = new System.Windows.Forms.Label();
        txtInput = new System.Windows.Forms.TextBox();
        lblInputHeader = new System.Windows.Forms.Label();

        pnlOptions = new System.Windows.Forms.Panel();
        lblMultiLine = new System.Windows.Forms.Label();
        cmbMultiLine = new System.Windows.Forms.ComboBox();
        chkBringToFront = new System.Windows.Forms.CheckBox();
        chkClearAfterSend = new System.Windows.Forms.CheckBox();
        chkClearFirst = new System.Windows.Forms.CheckBox();
        chkPressTab = new System.Windows.Forms.CheckBox();
        chkPressEnter = new System.Windows.Forms.CheckBox();
        chkPerformClick = new System.Windows.Forms.CheckBox();
        cmbDelay = new System.Windows.Forms.ComboBox();
        lblDelay = new System.Windows.Forms.Label();
        cmbSpeed = new System.Windows.Forms.ComboBox();
        lblSpeed = new System.Windows.Forms.Label();
        lblOptionsHeader = new System.Windows.Forms.Label();

        pnlBottom = new System.Windows.Forms.Panel();
        lblStatus = new System.Windows.Forms.Label();
        prgTyping = new System.Windows.Forms.ProgressBar();
        btnStopTyping = new System.Windows.Forms.Button();
        btnStartTyping = new System.Windows.Forms.Button();

        pnlHeader.SuspendLayout();
        pnlTarget.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
        pnlInput.SuspendLayout();
        pnlOptions.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();

        // 
        // pnlHeader (Dark Tech #0F151D)
        // 
        pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
        pnlHeader.Controls.Add(lblHotkeysBadge);
        pnlHeader.Controls.Add(lblAppSubtitle);
        pnlHeader.Controls.Add(lblAppTitle);
        pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        pnlHeader.Location = new System.Drawing.Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new System.Drawing.Size(870, 68);
        pnlHeader.TabIndex = 0;

        // lblAppTitle (#E8EEF2)
        lblAppTitle.AutoSize = true;
        lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        lblAppTitle.Location = new System.Drawing.Point(16, 10);
        lblAppTitle.Name = "lblAppTitle";
        lblAppTitle.Size = new System.Drawing.Size(260, 28);
        lblAppTitle.Text = "⚡ Window Text Typer";

        // lblAppSubtitle (#8B9AA8)
        lblAppSubtitle.AutoSize = true;
        lblAppSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        lblAppSubtitle.ForeColor = System.Drawing.Color.FromArgb(139, 154, 168);
        lblAppSubtitle.Location = new System.Drawing.Point(18, 38);
        lblAppSubtitle.Name = "lblAppSubtitle";
        lblAppSubtitle.Size = new System.Drawing.Size(430, 17);
        lblAppSubtitle.Text = "Tastatur-Simulation für Remote Desktop (RDP), VMs & Apps";

        // lblHotkeysBadge (Cyan #00BCD4 on Panel #1B2530)
        lblHotkeysBadge.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        lblHotkeysBadge.AutoSize = true;
        lblHotkeysBadge.BackColor = System.Drawing.Color.FromArgb(27, 37, 48);
        lblHotkeysBadge.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
        lblHotkeysBadge.ForeColor = System.Drawing.Color.FromArgb(0, 188, 212);
        lblHotkeysBadge.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
        lblHotkeysBadge.Location = new System.Drawing.Point(595, 20);
        lblHotkeysBadge.Name = "lblHotkeysBadge";
        lblHotkeysBadge.Size = new System.Drawing.Size(255, 23);
        lblHotkeysBadge.Text = "⌨️ Hotkeys: [F8] Markieren  |  [F9] Senden";

        // 
        // pnlTarget (Dark Tech Panel #1B2530)
        // 
        pnlTarget.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        pnlTarget.BackColor = System.Drawing.Color.FromArgb(27, 37, 48);
        pnlTarget.Controls.Add(btnTestClick);
        pnlTarget.Controls.Add(btnCaptureTarget);
        pnlTarget.Controls.Add(lblTargetProcess);
        pnlTarget.Controls.Add(lblTargetWindow);
        pnlTarget.Controls.Add(lblTargetCoord);
        pnlTarget.Controls.Add(picThumbnail);
        pnlTarget.Controls.Add(lblTargetHeader);
        pnlTarget.Location = new System.Drawing.Point(16, 76);
        pnlTarget.Name = "pnlTarget";
        pnlTarget.Size = new System.Drawing.Size(838, 125);
        pnlTarget.TabIndex = 1;

        // lblTargetHeader (#00BCD4 Cyan)
        lblTargetHeader.AutoSize = true;
        lblTargetHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
        lblTargetHeader.ForeColor = System.Drawing.Color.FromArgb(0, 188, 212);
        lblTargetHeader.Location = new System.Drawing.Point(12, 10);
        lblTargetHeader.Name = "lblTargetHeader";
        lblTargetHeader.Size = new System.Drawing.Size(195, 19);
        lblTargetHeader.Text = "🎯 1. Ziel-Bereich / Textfeld";

        // picThumbnail
        picThumbnail.BackColor = System.Drawing.Color.FromArgb(16, 22, 30);
        picThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        picThumbnail.Location = new System.Drawing.Point(16, 36);
        picThumbnail.Name = "picThumbnail";
        picThumbnail.Size = new System.Drawing.Size(150, 75);
        picThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        picThumbnail.TabIndex = 1;
        picThumbnail.TabStop = false;

        // lblTargetCoord (#00BCD4 Cyan)
        lblTargetCoord.AutoSize = true;
        lblTargetCoord.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        lblTargetCoord.ForeColor = System.Drawing.Color.FromArgb(0, 188, 212);
        lblTargetCoord.Location = new System.Drawing.Point(180, 36);
        lblTargetCoord.Name = "lblTargetCoord";
        lblTargetCoord.Size = new System.Drawing.Size(320, 17);
        lblTargetCoord.Text = "Koordinate: Kein Ziel ausgewählt (Bitte markieren)";

        // lblTargetWindow (#E8EEF2 Text)
        lblTargetWindow.AutoSize = true;
        lblTargetWindow.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblTargetWindow.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        lblTargetWindow.Location = new System.Drawing.Point(180, 60);
        lblTargetWindow.Name = "lblTargetWindow";
        lblTargetWindow.Size = new System.Drawing.Size(56, 15);
        lblTargetWindow.Text = "Fenster: -";

        // lblTargetProcess (#8B9AA8 Secondary)
        lblTargetProcess.AutoSize = true;
        lblTargetProcess.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblTargetProcess.ForeColor = System.Drawing.Color.FromArgb(139, 154, 168);
        lblTargetProcess.Location = new System.Drawing.Point(180, 82);
        lblTargetProcess.Name = "lblTargetProcess";
        lblTargetProcess.Size = new System.Drawing.Size(57, 15);
        lblTargetProcess.Text = "Prozess: -";

        // btnCaptureTarget (Hauptfarbe Blau #1976D2)
        btnCaptureTarget.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnCaptureTarget.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
        btnCaptureTarget.Cursor = System.Windows.Forms.Cursors.Hand;
        btnCaptureTarget.FlatAppearance.BorderSize = 0;
        btnCaptureTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnCaptureTarget.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        btnCaptureTarget.ForeColor = System.Drawing.Color.White;
        btnCaptureTarget.Location = new System.Drawing.Point(605, 36);
        btnCaptureTarget.Name = "btnCaptureTarget";
        btnCaptureTarget.Size = new System.Drawing.Size(218, 36);
        btnCaptureTarget.TabIndex = 2;
        btnCaptureTarget.Text = "🎯 Bereich markieren (F8)";
        btnCaptureTarget.UseVisualStyleBackColor = false;

        // btnTestClick (Sekundär #253342)
        btnTestClick.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnTestClick.BackColor = System.Drawing.Color.FromArgb(37, 51, 66);
        btnTestClick.Cursor = System.Windows.Forms.Cursors.Hand;
        btnTestClick.Enabled = false;
        btnTestClick.FlatAppearance.BorderSize = 0;
        btnTestClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnTestClick.Font = new System.Drawing.Font("Segoe UI", 9F);
        btnTestClick.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        btnTestClick.Location = new System.Drawing.Point(605, 78);
        btnTestClick.Name = "btnTestClick";
        btnTestClick.Size = new System.Drawing.Size(218, 32);
        btnTestClick.TabIndex = 3;
        btnTestClick.Text = "⚡ Test-Klick (Fokus prüfen)";
        btnTestClick.UseVisualStyleBackColor = false;

        // 
        // pnlInput (Dark Tech Panel #1B2530)
        // 
        pnlInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        pnlInput.BackColor = System.Drawing.Color.FromArgb(27, 37, 48);
        pnlInput.Controls.Add(btnInsertSample);
        pnlInput.Controls.Add(btnClearInput);
        pnlInput.Controls.Add(btnPasteClipboard);
        pnlInput.Controls.Add(lblStats);
        pnlInput.Controls.Add(txtInput);
        pnlInput.Controls.Add(lblInputHeader);
        pnlInput.Location = new System.Drawing.Point(16, 209);
        pnlInput.Name = "pnlInput";
        pnlInput.Size = new System.Drawing.Size(838, 165);
        pnlInput.TabIndex = 2;

        // lblInputHeader (#E8EEF2 Text)
        lblInputHeader.AutoSize = true;
        lblInputHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
        lblInputHeader.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        lblInputHeader.Location = new System.Drawing.Point(12, 10);
        lblInputHeader.Name = "lblInputHeader";
        lblInputHeader.Size = new System.Drawing.Size(225, 19);
        lblInputHeader.Text = "📝 2. Eingehender Text (Tippgut)";

        // btnPasteClipboard (#253342)
        btnPasteClipboard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnPasteClipboard.BackColor = System.Drawing.Color.FromArgb(37, 51, 66);
        btnPasteClipboard.Cursor = System.Windows.Forms.Cursors.Hand;
        btnPasteClipboard.FlatAppearance.BorderSize = 0;
        btnPasteClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnPasteClipboard.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        btnPasteClipboard.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        btnPasteClipboard.Location = new System.Drawing.Point(555, 6);
        btnPasteClipboard.Name = "btnPasteClipboard";
        btnPasteClipboard.Size = new System.Drawing.Size(140, 26);
        btnPasteClipboard.TabIndex = 4;
        btnPasteClipboard.Text = "📋 Aus Clipboard";
        btnPasteClipboard.UseVisualStyleBackColor = false;

        // btnInsertSample (#253342)
        btnInsertSample.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnInsertSample.BackColor = System.Drawing.Color.FromArgb(37, 51, 66);
        btnInsertSample.Cursor = System.Windows.Forms.Cursors.Hand;
        btnInsertSample.FlatAppearance.BorderSize = 0;
        btnInsertSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnInsertSample.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        btnInsertSample.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        btnInsertSample.Location = new System.Drawing.Point(702, 6);
        btnInsertSample.Name = "btnInsertSample";
        btnInsertSample.Size = new System.Drawing.Size(65, 26);
        btnInsertSample.TabIndex = 5;
        btnInsertSample.Text = "✨ Demo";
        btnInsertSample.UseVisualStyleBackColor = false;

        // btnClearInput (#253342)
        btnClearInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnClearInput.BackColor = System.Drawing.Color.FromArgb(37, 51, 66);
        btnClearInput.Cursor = System.Windows.Forms.Cursors.Hand;
        btnClearInput.FlatAppearance.BorderSize = 0;
        btnClearInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnClearInput.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        btnClearInput.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        btnClearInput.Location = new System.Drawing.Point(774, 6);
        btnClearInput.Name = "btnClearInput";
        btnClearInput.Size = new System.Drawing.Size(50, 26);
        btnClearInput.TabIndex = 6;
        btnClearInput.Text = "🗑";
        btnClearInput.UseVisualStyleBackColor = false;

        // txtInput (Dark Background #10161E)
        txtInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtInput.BackColor = System.Drawing.Color.FromArgb(16, 22, 30);
        txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        txtInput.Font = new System.Drawing.Font("Cascadia Code", 10F);
        txtInput.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        txtInput.Location = new System.Drawing.Point(16, 36);
        txtInput.Multiline = true;
        txtInput.Name = "txtInput";
        txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        txtInput.Size = new System.Drawing.Size(807, 98);
        txtInput.TabIndex = 0;

        // lblStats (#8B9AA8)
        lblStats.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        lblStats.AutoSize = true;
        lblStats.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        lblStats.ForeColor = System.Drawing.Color.FromArgb(139, 154, 168);
        lblStats.Location = new System.Drawing.Point(16, 140);
        lblStats.Name = "lblStats";
        lblStats.Size = new System.Drawing.Size(120, 15);
        lblStats.Text = "Zeichen: 0  |  Zeilen: 0";

        // 
        // pnlOptions (Dark Tech Panel #1B2530)
        // 
        pnlOptions.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        pnlOptions.BackColor = System.Drawing.Color.FromArgb(27, 37, 48);
        pnlOptions.Controls.Add(lblMultiLine);
        pnlOptions.Controls.Add(cmbMultiLine);
        pnlOptions.Controls.Add(chkBringToFront);
        pnlOptions.Controls.Add(chkClearAfterSend);
        pnlOptions.Controls.Add(chkClearFirst);
        pnlOptions.Controls.Add(chkPressTab);
        pnlOptions.Controls.Add(chkPressEnter);
        pnlOptions.Controls.Add(chkPerformClick);
        pnlOptions.Controls.Add(cmbDelay);
        pnlOptions.Controls.Add(lblDelay);
        pnlOptions.Controls.Add(cmbSpeed);
        pnlOptions.Controls.Add(lblSpeed);
        pnlOptions.Controls.Add(lblOptionsHeader);
        pnlOptions.Location = new System.Drawing.Point(16, 382);
        pnlOptions.Name = "pnlOptions";
        pnlOptions.Size = new System.Drawing.Size(838, 132);
        pnlOptions.TabIndex = 3;

        // lblOptionsHeader (#E8EEF2)
        lblOptionsHeader.AutoSize = true;
        lblOptionsHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
        lblOptionsHeader.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        lblOptionsHeader.Location = new System.Drawing.Point(12, 8);
        lblOptionsHeader.Name = "lblOptionsHeader";
        lblOptionsHeader.Size = new System.Drawing.Size(265, 19);
        lblOptionsHeader.Text = "⚙️ 3. RDP- & Tastatur-Einstellungen";

        // lblMultiLine (#00BCD4 Cyan)
        lblMultiLine.AutoSize = true;
        lblMultiLine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        lblMultiLine.ForeColor = System.Drawing.Color.FromArgb(0, 188, 212);
        lblMultiLine.Location = new System.Drawing.Point(16, 36);
        lblMultiLine.Name = "lblMultiLine";
        lblMultiLine.Size = new System.Drawing.Size(115, 15);
        lblMultiLine.Text = "Mehrzeilen-Modus:";

        // cmbMultiLine (#10161E)
        cmbMultiLine.BackColor = System.Drawing.Color.FromArgb(16, 22, 30);
        cmbMultiLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbMultiLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cmbMultiLine.Font = new System.Drawing.Font("Segoe UI", 9F);
        cmbMultiLine.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        cmbMultiLine.FormattingEnabled = true;
        cmbMultiLine.Location = new System.Drawing.Point(145, 33);
        cmbMultiLine.Name = "cmbMultiLine";
        cmbMultiLine.Size = new System.Drawing.Size(280, 23);
        cmbMultiLine.TabIndex = 0;

        // lblSpeed (#8B9AA8)
        lblSpeed.AutoSize = true;
        lblSpeed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        lblSpeed.ForeColor = System.Drawing.Color.FromArgb(139, 154, 168);
        lblSpeed.Location = new System.Drawing.Point(16, 68);
        lblSpeed.Name = "lblSpeed";
        lblSpeed.Size = new System.Drawing.Size(125, 15);
        lblSpeed.Text = "Tipp-Geschwindigkeit:";

        // cmbSpeed (#10161E)
        cmbSpeed.BackColor = System.Drawing.Color.FromArgb(16, 22, 30);
        cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cmbSpeed.Font = new System.Drawing.Font("Segoe UI", 9F);
        cmbSpeed.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        cmbSpeed.FormattingEnabled = true;
        cmbSpeed.Location = new System.Drawing.Point(145, 65);
        cmbSpeed.Name = "cmbSpeed";
        cmbSpeed.Size = new System.Drawing.Size(280, 23);
        cmbSpeed.TabIndex = 1;

        // lblDelay (#8B9AA8)
        lblDelay.AutoSize = true;
        lblDelay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        lblDelay.ForeColor = System.Drawing.Color.FromArgb(139, 154, 168);
        lblDelay.Location = new System.Drawing.Point(16, 100);
        lblDelay.Name = "lblDelay";
        lblDelay.Size = new System.Drawing.Size(125, 15);
        lblDelay.Text = "Fokus-Verzögerung:";

        // cmbDelay (#10161E)
        cmbDelay.BackColor = System.Drawing.Color.FromArgb(16, 22, 30);
        cmbDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        cmbDelay.Font = new System.Drawing.Font("Segoe UI", 9F);
        cmbDelay.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        cmbDelay.FormattingEnabled = true;
        cmbDelay.Location = new System.Drawing.Point(145, 97);
        cmbDelay.Name = "cmbDelay";
        cmbDelay.Size = new System.Drawing.Size(280, 23);
        cmbDelay.TabIndex = 2;

        // chkPerformClick
        chkPerformClick.AutoSize = true;
        chkPerformClick.Checked = true;
        chkPerformClick.CheckState = System.Windows.Forms.CheckState.Checked;
        chkPerformClick.Font = new System.Drawing.Font("Segoe UI", 9F);
        chkPerformClick.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        chkPerformClick.Location = new System.Drawing.Point(445, 35);
        chkPerformClick.Name = "chkPerformClick";
        chkPerformClick.Size = new System.Drawing.Size(185, 19);
        chkPerformClick.Text = "Klick auf Ziel (Fokus setzen)";
        chkPerformClick.UseVisualStyleBackColor = true;

        // chkBringToFront
        chkBringToFront.AutoSize = true;
        chkBringToFront.Checked = true;
        chkBringToFront.CheckState = System.Windows.Forms.CheckState.Checked;
        chkBringToFront.Font = new System.Drawing.Font("Segoe UI", 9F);
        chkBringToFront.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        chkBringToFront.Location = new System.Drawing.Point(445, 65);
        chkBringToFront.Name = "chkBringToFront";
        chkBringToFront.Size = new System.Drawing.Size(165, 19);
        chkBringToFront.Text = "Zielfenster aktivieren";
        chkBringToFront.UseVisualStyleBackColor = true;

        // chkClearFirst
        chkClearFirst.AutoSize = true;
        chkClearFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
        chkClearFirst.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        chkClearFirst.Location = new System.Drawing.Point(445, 95);
        chkClearFirst.Name = "chkClearFirst";
        chkClearFirst.Size = new System.Drawing.Size(185, 19);
        chkClearFirst.Text = "Vorherigen Text leeren (Strg+A)";
        chkClearFirst.UseVisualStyleBackColor = true;

        // chkPressEnter
        chkPressEnter.AutoSize = true;
        chkPressEnter.Font = new System.Drawing.Font("Segoe UI", 9F);
        chkPressEnter.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        chkPressEnter.Location = new System.Drawing.Point(645, 35);
        chkPressEnter.Name = "chkPressEnter";
        chkPressEnter.Size = new System.Drawing.Size(155, 19);
        chkPressEnter.Text = "Am Ende [Enter] drücken";
        chkPressEnter.UseVisualStyleBackColor = true;

        // chkPressTab
        chkPressTab.AutoSize = true;
        chkPressTab.Font = new System.Drawing.Font("Segoe UI", 9F);
        chkPressTab.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        chkPressTab.Location = new System.Drawing.Point(645, 65);
        chkPressTab.Name = "chkPressTab";
        chkPressTab.Size = new System.Drawing.Size(150, 19);
        chkPressTab.Text = "Am Ende [Tab] drücken";
        chkPressTab.UseVisualStyleBackColor = true;

        // chkClearAfterSend
        chkClearAfterSend.AutoSize = true;
        chkClearAfterSend.Font = new System.Drawing.Font("Segoe UI", 9F);
        chkClearAfterSend.ForeColor = System.Drawing.Color.FromArgb(232, 238, 242);
        chkClearAfterSend.Location = new System.Drawing.Point(645, 95);
        chkClearAfterSend.Name = "chkClearAfterSend";
        chkClearAfterSend.Size = new System.Drawing.Size(160, 19);
        chkClearAfterSend.Text = "Eingabefeld danach leeren";
        chkClearAfterSend.UseVisualStyleBackColor = true;

        // 
        // pnlBottom (Dark Tech #0F151D)
        // 
        pnlBottom.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
        pnlBottom.Controls.Add(lblStatus);
        pnlBottom.Controls.Add(prgTyping);
        pnlBottom.Controls.Add(btnStopTyping);
        pnlBottom.Controls.Add(btnStartTyping);
        pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        pnlBottom.Location = new System.Drawing.Point(0, 524);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new System.Drawing.Size(870, 92);
        pnlBottom.TabIndex = 4;

        // btnStartTyping (Erfolg Grün #4CAF50)
        btnStartTyping.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
        btnStartTyping.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
        btnStartTyping.Cursor = System.Windows.Forms.Cursors.Hand;
        btnStartTyping.FlatAppearance.BorderSize = 0;
        btnStartTyping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnStartTyping.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        btnStartTyping.ForeColor = System.Drawing.Color.White;
        btnStartTyping.Location = new System.Drawing.Point(16, 12);
        btnStartTyping.Name = "btnStartTyping";
        btnStartTyping.Size = new System.Drawing.Size(260, 42);
        btnStartTyping.TabIndex = 0;
        btnStartTyping.Text = "🚀 Text jetzt eintippen (F9)";
        btnStartTyping.UseVisualStyleBackColor = false;

        // btnStopTyping (Fehler / Abbrechen Rot #EF5350)
        btnStopTyping.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
        btnStopTyping.BackColor = System.Drawing.Color.FromArgb(239, 83, 80);
        btnStopTyping.Cursor = System.Windows.Forms.Cursors.Hand;
        btnStopTyping.Enabled = false;
        btnStopTyping.FlatAppearance.BorderSize = 0;
        btnStopTyping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnStopTyping.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        btnStopTyping.ForeColor = System.Drawing.Color.White;
        btnStopTyping.Location = new System.Drawing.Point(286, 12);
        btnStopTyping.Name = "btnStopTyping";
        btnStopTyping.Size = new System.Drawing.Size(140, 42);
        btnStopTyping.TabIndex = 1;
        btnStopTyping.Text = "⏹ Abbrechen";
        btnStopTyping.UseVisualStyleBackColor = false;

        // prgTyping
        prgTyping.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        prgTyping.Location = new System.Drawing.Point(440, 20);
        prgTyping.Name = "prgTyping";
        prgTyping.Size = new System.Drawing.Size(414, 26);
        prgTyping.TabIndex = 2;

        // lblStatus (#8B9AA8)
        lblStatus.AutoSize = true;
        lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
        lblStatus.ForeColor = System.Drawing.Color.FromArgb(139, 154, 168);
        lblStatus.Location = new System.Drawing.Point(18, 62);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new System.Drawing.Size(350, 15);
        lblStatus.Text = "Bereit. Markiere ein Ziel mit [F8] und tippe Text mit [F9] ein.";

        // 
        // MainForm (Dark Tech Background #121820)
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(18, 24, 32);
        ClientSize = new System.Drawing.Size(870, 616);
        Controls.Add(pnlBottom);
        Controls.Add(pnlOptions);
        Controls.Add(pnlInput);
        Controls.Add(pnlTarget);
        Controls.Add(pnlHeader);
        MinimumSize = new System.Drawing.Size(780, 580);
        Name = "MainForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Window Text Typer - Hardwarenahe Tastatur-Simulation";

        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlTarget.ResumeLayout(false);
        pnlTarget.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
        pnlInput.ResumeLayout(false);
        pnlInput.PerformLayout();
        pnlOptions.ResumeLayout(false);
        pnlOptions.PerformLayout();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }
}
