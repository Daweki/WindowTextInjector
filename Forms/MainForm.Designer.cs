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
        pnlHeader = new Panel();
        lblHotkeysBadge = new Label();
        lblAppSubtitle = new Label();
        lblAppTitle = new Label();
        pnlTarget = new Panel();
        btnTestClick = new Button();
        btnCaptureTarget = new Button();
        lblTargetProcess = new Label();
        lblTargetWindow = new Label();
        lblTargetCoord = new Label();
        picThumbnail = new PictureBox();
        lblTargetHeader = new Label();
        pnlInput = new Panel();
        btnInsertSample = new Button();
        btnClearInput = new Button();
        btnPasteClipboard = new Button();
        lblStats = new Label();
        txtInput = new TextBox();
        lblInputHeader = new Label();
        pnlOptions = new Panel();
        lblMultiLine = new Label();
        cmbMultiLine = new ComboBox();
        chkBringToFront = new CheckBox();
        chkClearAfterSend = new CheckBox();
        chkClearFirst = new CheckBox();
        chkPressTab = new CheckBox();
        chkPressEnter = new CheckBox();
        chkPerformClick = new CheckBox();
        cmbDelay = new ComboBox();
        lblDelay = new Label();
        cmbSpeed = new ComboBox();
        lblSpeed = new Label();
        lblOptionsHeader = new Label();
        pnlBottom = new Panel();
        lblStatus = new Label();
        prgTyping = new ProgressBar();
        btnStopTyping = new Button();
        btnStartTyping = new Button();
        pnlHeader.SuspendLayout();
        pnlTarget.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
        pnlInput.SuspendLayout();
        pnlOptions.SuspendLayout();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
        pnlHeader.Controls.Add(lblHotkeysBadge);
        pnlHeader.Controls.Add(lblAppSubtitle);
        pnlHeader.Controls.Add(lblAppTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(870, 68);
        pnlHeader.TabIndex = 0;
        // 
        // lblHotkeysBadge
        // 
        lblHotkeysBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHotkeysBadge.AutoSize = true;
        lblHotkeysBadge.BackColor = Color.FromArgb(30, 41, 59);
        lblHotkeysBadge.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        lblHotkeysBadge.ForeColor = Color.FromArgb(56, 189, 248);
        lblHotkeysBadge.Location = new Point(595, 20);
        lblHotkeysBadge.Name = "lblHotkeysBadge";
        lblHotkeysBadge.Padding = new Padding(8, 4, 8, 4);
        lblHotkeysBadge.Size = new Size(244, 23);
        lblHotkeysBadge.TabIndex = 0;
        lblHotkeysBadge.Text = "⌨️ Hotkeys: [F8] Markieren  |  [F9] Senden";
        // 
        // lblAppSubtitle
        // 
        lblAppSubtitle.AutoSize = true;
        lblAppSubtitle.Font = new Font("Segoe UI", 9.5F);
        lblAppSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
        lblAppSubtitle.Location = new Point(18, 38);
        lblAppSubtitle.Name = "lblAppSubtitle";
        lblAppSubtitle.Size = new Size(347, 17);
        lblAppSubtitle.TabIndex = 1;
        lblAppSubtitle.Text = "Tastatur-Simulation für Remote Desktop (RDP), VMs & Apps";
        // 
        // lblAppTitle
        // 
        lblAppTitle.AutoSize = true;
        lblAppTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblAppTitle.ForeColor = Color.FromArgb(248, 250, 252);
        lblAppTitle.Location = new Point(16, 10);
        lblAppTitle.Name = "lblAppTitle";
        lblAppTitle.Size = new Size(229, 28);
        lblAppTitle.TabIndex = 2;
        lblAppTitle.Text = "⚡ Window Text Typer";
        // 
        // pnlTarget
        // 
        pnlTarget.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlTarget.BackColor = Color.FromArgb(30, 41, 59);
        pnlTarget.Controls.Add(btnTestClick);
        pnlTarget.Controls.Add(btnCaptureTarget);
        pnlTarget.Controls.Add(lblTargetProcess);
        pnlTarget.Controls.Add(lblTargetWindow);
        pnlTarget.Controls.Add(lblTargetCoord);
        pnlTarget.Controls.Add(picThumbnail);
        pnlTarget.Controls.Add(lblTargetHeader);
        pnlTarget.Location = new Point(16, 76);
        pnlTarget.Name = "pnlTarget";
        pnlTarget.Size = new Size(838, 125);
        pnlTarget.TabIndex = 1;
        // 
        // btnTestClick
        // 
        btnTestClick.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnTestClick.BackColor = Color.FromArgb(51, 65, 85);
        btnTestClick.Cursor = Cursors.Hand;
        btnTestClick.Enabled = false;
        btnTestClick.FlatAppearance.BorderSize = 0;
        btnTestClick.FlatStyle = FlatStyle.Flat;
        btnTestClick.Font = new Font("Segoe UI", 9F);
        btnTestClick.ForeColor = Color.FromArgb(241, 245, 249);
        btnTestClick.Location = new Point(605, 78);
        btnTestClick.Name = "btnTestClick";
        btnTestClick.Size = new Size(218, 32);
        btnTestClick.TabIndex = 3;
        btnTestClick.Text = "⚡ Test-Klick (Fokus prüfen)";
        btnTestClick.UseVisualStyleBackColor = false;
        // 
        // btnCaptureTarget
        // 
        btnCaptureTarget.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCaptureTarget.BackColor = Color.FromArgb(2, 132, 199);
        btnCaptureTarget.Cursor = Cursors.Hand;
        btnCaptureTarget.FlatAppearance.BorderSize = 0;
        btnCaptureTarget.FlatStyle = FlatStyle.Flat;
        btnCaptureTarget.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnCaptureTarget.ForeColor = Color.White;
        btnCaptureTarget.Location = new Point(605, 36);
        btnCaptureTarget.Name = "btnCaptureTarget";
        btnCaptureTarget.Size = new Size(218, 36);
        btnCaptureTarget.TabIndex = 2;
        btnCaptureTarget.Text = "🎯 Bereich markieren (F8)";
        btnCaptureTarget.UseVisualStyleBackColor = false;
        // 
        // lblTargetProcess
        // 
        lblTargetProcess.AutoSize = true;
        lblTargetProcess.Font = new Font("Segoe UI", 9F);
        lblTargetProcess.ForeColor = Color.FromArgb(148, 163, 184);
        lblTargetProcess.Location = new Point(180, 82);
        lblTargetProcess.Name = "lblTargetProcess";
        lblTargetProcess.Size = new Size(57, 15);
        lblTargetProcess.TabIndex = 4;
        lblTargetProcess.Text = "Prozess: -";
        // 
        // lblTargetWindow
        // 
        lblTargetWindow.AutoSize = true;
        lblTargetWindow.Font = new Font("Segoe UI", 9F);
        lblTargetWindow.ForeColor = Color.FromArgb(203, 213, 225);
        lblTargetWindow.Location = new Point(180, 60);
        lblTargetWindow.Name = "lblTargetWindow";
        lblTargetWindow.Size = new Size(56, 15);
        lblTargetWindow.TabIndex = 5;
        lblTargetWindow.Text = "Fenster: -";
        // 
        // lblTargetCoord
        // 
        lblTargetCoord.AutoSize = true;
        lblTargetCoord.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTargetCoord.ForeColor = Color.FromArgb(56, 189, 248);
        lblTargetCoord.Location = new Point(180, 36);
        lblTargetCoord.Name = "lblTargetCoord";
        lblTargetCoord.Size = new Size(321, 17);
        lblTargetCoord.TabIndex = 6;
        lblTargetCoord.Text = "Koordinate: Kein Ziel ausgewählt (Bitte markieren)";
        // 
        // picThumbnail
        // 
        picThumbnail.BackColor = Color.FromArgb(15, 23, 42);
        picThumbnail.BorderStyle = BorderStyle.FixedSingle;
        picThumbnail.Location = new Point(16, 36);
        picThumbnail.Name = "picThumbnail";
        picThumbnail.Size = new Size(150, 75);
        picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
        picThumbnail.TabIndex = 1;
        picThumbnail.TabStop = false;
        // 
        // lblTargetHeader
        // 
        lblTargetHeader.AutoSize = true;
        lblTargetHeader.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblTargetHeader.ForeColor = Color.FromArgb(226, 232, 240);
        lblTargetHeader.Location = new Point(12, 10);
        lblTargetHeader.Name = "lblTargetHeader";
        lblTargetHeader.Size = new Size(198, 19);
        lblTargetHeader.TabIndex = 7;
        lblTargetHeader.Text = "🎯 1. Ziel-Bereich / Textfeld";
        // 
        // pnlInput
        // 
        pnlInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlInput.BackColor = Color.FromArgb(30, 41, 59);
        pnlInput.Controls.Add(btnInsertSample);
        pnlInput.Controls.Add(btnClearInput);
        pnlInput.Controls.Add(btnPasteClipboard);
        pnlInput.Controls.Add(lblStats);
        pnlInput.Controls.Add(txtInput);
        pnlInput.Controls.Add(lblInputHeader);
        pnlInput.Location = new Point(16, 209);
        pnlInput.Name = "pnlInput";
        pnlInput.Size = new Size(838, 165);
        pnlInput.TabIndex = 2;
        // 
        // btnInsertSample
        // 
        btnInsertSample.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnInsertSample.BackColor = Color.FromArgb(51, 65, 85);
        btnInsertSample.Cursor = Cursors.Hand;
        btnInsertSample.FlatAppearance.BorderSize = 0;
        btnInsertSample.FlatStyle = FlatStyle.Flat;
        btnInsertSample.Font = new Font("Segoe UI", 8.5F);
        btnInsertSample.ForeColor = Color.FromArgb(241, 245, 249);
        btnInsertSample.Location = new Point(702, 6);
        btnInsertSample.Name = "btnInsertSample";
        btnInsertSample.Size = new Size(65, 26);
        btnInsertSample.TabIndex = 5;
        btnInsertSample.Text = "✨ Demo";
        btnInsertSample.UseVisualStyleBackColor = false;
        // 
        // btnClearInput
        // 
        btnClearInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClearInput.BackColor = Color.FromArgb(51, 65, 85);
        btnClearInput.Cursor = Cursors.Hand;
        btnClearInput.FlatAppearance.BorderSize = 0;
        btnClearInput.FlatStyle = FlatStyle.Flat;
        btnClearInput.Font = new Font("Segoe UI", 8.5F);
        btnClearInput.ForeColor = Color.FromArgb(241, 245, 249);
        btnClearInput.Location = new Point(774, 6);
        btnClearInput.Name = "btnClearInput";
        btnClearInput.Size = new Size(50, 26);
        btnClearInput.TabIndex = 6;
        btnClearInput.Text = "🗑";
        btnClearInput.UseVisualStyleBackColor = false;
        // 
        // btnPasteClipboard
        // 
        btnPasteClipboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnPasteClipboard.BackColor = Color.FromArgb(51, 65, 85);
        btnPasteClipboard.Cursor = Cursors.Hand;
        btnPasteClipboard.FlatAppearance.BorderSize = 0;
        btnPasteClipboard.FlatStyle = FlatStyle.Flat;
        btnPasteClipboard.Font = new Font("Segoe UI", 8.5F);
        btnPasteClipboard.ForeColor = Color.FromArgb(241, 245, 249);
        btnPasteClipboard.Location = new Point(555, 6);
        btnPasteClipboard.Name = "btnPasteClipboard";
        btnPasteClipboard.Size = new Size(140, 26);
        btnPasteClipboard.TabIndex = 4;
        btnPasteClipboard.Text = "📋 Aus Clipboard";
        btnPasteClipboard.UseVisualStyleBackColor = false;
        // 
        // lblStats
        // 
        lblStats.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblStats.AutoSize = true;
        lblStats.Font = new Font("Segoe UI", 8.5F);
        lblStats.ForeColor = Color.FromArgb(148, 163, 184);
        lblStats.Location = new Point(16, 140);
        lblStats.Name = "lblStats";
        lblStats.Size = new Size(120, 15);
        lblStats.TabIndex = 7;
        lblStats.Text = "Zeichen: 0  |  Zeilen: 0";
        // 
        // txtInput
        // 
        txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtInput.BackColor = Color.FromArgb(15, 23, 42);
        txtInput.BorderStyle = BorderStyle.FixedSingle;
        txtInput.Font = new Font("Cascadia Code", 10F);
        txtInput.ForeColor = Color.FromArgb(241, 245, 249);
        txtInput.Location = new Point(16, 36);
        txtInput.Multiline = true;
        txtInput.Name = "txtInput";
        txtInput.ScrollBars = ScrollBars.Both;
        txtInput.Size = new Size(807, 98);
        txtInput.TabIndex = 0;
        // 
        // lblInputHeader
        // 
        lblInputHeader.AutoSize = true;
        lblInputHeader.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblInputHeader.ForeColor = Color.FromArgb(226, 232, 240);
        lblInputHeader.Location = new Point(12, 10);
        lblInputHeader.Name = "lblInputHeader";
        lblInputHeader.Size = new Size(180, 19);
        lblInputHeader.TabIndex = 8;
        lblInputHeader.Text = "📝 2. Einzugebender Text";
        // 
        // pnlOptions
        // 
        pnlOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlOptions.BackColor = Color.FromArgb(30, 41, 59);
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
        pnlOptions.Location = new Point(16, 382);
        pnlOptions.Name = "pnlOptions";
        pnlOptions.Size = new Size(838, 132);
        pnlOptions.TabIndex = 3;
        // 
        // lblMultiLine
        // 
        lblMultiLine.AutoSize = true;
        lblMultiLine.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblMultiLine.ForeColor = Color.FromArgb(56, 189, 248);
        lblMultiLine.Location = new Point(16, 36);
        lblMultiLine.Name = "lblMultiLine";
        lblMultiLine.Size = new Size(113, 15);
        lblMultiLine.TabIndex = 0;
        lblMultiLine.Text = "Mehrzeilen Modus:";
        // 
        // cmbMultiLine
        // 
        cmbMultiLine.BackColor = Color.FromArgb(15, 23, 42);
        cmbMultiLine.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMultiLine.FlatStyle = FlatStyle.Flat;
        cmbMultiLine.Font = new Font("Segoe UI", 9F);
        cmbMultiLine.ForeColor = Color.FromArgb(241, 245, 249);
        cmbMultiLine.FormattingEnabled = true;
        cmbMultiLine.Location = new Point(145, 33);
        cmbMultiLine.Name = "cmbMultiLine";
        cmbMultiLine.Size = new Size(280, 23);
        cmbMultiLine.TabIndex = 0;
        // 
        // chkBringToFront
        // 
        chkBringToFront.AutoSize = true;
        chkBringToFront.Checked = true;
        chkBringToFront.CheckState = CheckState.Checked;
        chkBringToFront.Font = new Font("Segoe UI", 9F);
        chkBringToFront.ForeColor = Color.FromArgb(226, 232, 240);
        chkBringToFront.Location = new Point(445, 65);
        chkBringToFront.Name = "chkBringToFront";
        chkBringToFront.Size = new Size(135, 19);
        chkBringToFront.TabIndex = 1;
        chkBringToFront.Text = "Zielfenster aktivieren";
        chkBringToFront.UseVisualStyleBackColor = true;
        // 
        // chkClearAfterSend
        // 
        chkClearAfterSend.AutoSize = true;
        chkClearAfterSend.Font = new Font("Segoe UI", 9F);
        chkClearAfterSend.ForeColor = Color.FromArgb(226, 232, 240);
        chkClearAfterSend.Location = new Point(645, 95);
        chkClearAfterSend.Name = "chkClearAfterSend";
        chkClearAfterSend.Size = new Size(165, 19);
        chkClearAfterSend.TabIndex = 2;
        chkClearAfterSend.Text = "Eingabefeld danach leeren";
        chkClearAfterSend.UseVisualStyleBackColor = true;
        // 
        // chkClearFirst
        // 
        chkClearFirst.AutoSize = true;
        chkClearFirst.Font = new Font("Segoe UI", 9F);
        chkClearFirst.ForeColor = Color.FromArgb(226, 232, 240);
        chkClearFirst.Location = new Point(445, 95);
        chkClearFirst.Name = "chkClearFirst";
        chkClearFirst.Size = new Size(190, 19);
        chkClearFirst.TabIndex = 3;
        chkClearFirst.Text = "Vorherigen Text leeren (Strg+A)";
        chkClearFirst.UseVisualStyleBackColor = true;
        // 
        // chkPressTab
        // 
        chkPressTab.AutoSize = true;
        chkPressTab.Font = new Font("Segoe UI", 9F);
        chkPressTab.ForeColor = Color.FromArgb(226, 232, 240);
        chkPressTab.Location = new Point(645, 65);
        chkPressTab.Name = "chkPressTab";
        chkPressTab.Size = new Size(150, 19);
        chkPressTab.TabIndex = 4;
        chkPressTab.Text = "Am Ende [Tab] drücken";
        chkPressTab.UseVisualStyleBackColor = true;
        // 
        // chkPressEnter
        // 
        chkPressEnter.AutoSize = true;
        chkPressEnter.Font = new Font("Segoe UI", 9F);
        chkPressEnter.ForeColor = Color.FromArgb(226, 232, 240);
        chkPressEnter.Location = new Point(645, 35);
        chkPressEnter.Name = "chkPressEnter";
        chkPressEnter.Size = new Size(158, 19);
        chkPressEnter.TabIndex = 5;
        chkPressEnter.Text = "Am Ende [Enter] drücken";
        chkPressEnter.UseVisualStyleBackColor = true;
        // 
        // chkPerformClick
        // 
        chkPerformClick.AutoSize = true;
        chkPerformClick.Checked = true;
        chkPerformClick.CheckState = CheckState.Checked;
        chkPerformClick.Font = new Font("Segoe UI", 9F);
        chkPerformClick.ForeColor = Color.FromArgb(226, 232, 240);
        chkPerformClick.Location = new Point(445, 35);
        chkPerformClick.Name = "chkPerformClick";
        chkPerformClick.Size = new Size(171, 19);
        chkPerformClick.TabIndex = 6;
        chkPerformClick.Text = "Klick auf Ziel (Fokus setzen)";
        chkPerformClick.UseVisualStyleBackColor = true;
        // 
        // cmbDelay
        // 
        cmbDelay.BackColor = Color.FromArgb(15, 23, 42);
        cmbDelay.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbDelay.FlatStyle = FlatStyle.Flat;
        cmbDelay.Font = new Font("Segoe UI", 9F);
        cmbDelay.ForeColor = Color.FromArgb(241, 245, 249);
        cmbDelay.FormattingEnabled = true;
        cmbDelay.Location = new Point(145, 97);
        cmbDelay.Name = "cmbDelay";
        cmbDelay.Size = new Size(280, 23);
        cmbDelay.TabIndex = 2;
        // 
        // lblDelay
        // 
        lblDelay.AutoSize = true;
        lblDelay.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDelay.ForeColor = Color.FromArgb(203, 213, 225);
        lblDelay.Location = new Point(16, 100);
        lblDelay.Name = "lblDelay";
        lblDelay.Size = new Size(117, 15);
        lblDelay.TabIndex = 7;
        lblDelay.Text = "Fokus Verzögerung:";
        // 
        // cmbSpeed
        // 
        cmbSpeed.BackColor = Color.FromArgb(15, 23, 42);
        cmbSpeed.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSpeed.FlatStyle = FlatStyle.Flat;
        cmbSpeed.Font = new Font("Segoe UI", 9F);
        cmbSpeed.ForeColor = Color.FromArgb(241, 245, 249);
        cmbSpeed.FormattingEnabled = true;
        cmbSpeed.Location = new Point(145, 65);
        cmbSpeed.Name = "cmbSpeed";
        cmbSpeed.Size = new Size(280, 23);
        cmbSpeed.TabIndex = 1;
        // 
        // lblSpeed
        // 
        lblSpeed.AutoSize = true;
        lblSpeed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSpeed.ForeColor = Color.FromArgb(203, 213, 225);
        lblSpeed.Location = new Point(16, 68);
        lblSpeed.Name = "lblSpeed";
        lblSpeed.Size = new Size(130, 15);
        lblSpeed.TabIndex = 8;
        lblSpeed.Text = "Tipp Geschwindigkeit:";
        // 
        // lblOptionsHeader
        // 
        lblOptionsHeader.AutoSize = true;
        lblOptionsHeader.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblOptionsHeader.ForeColor = Color.FromArgb(226, 232, 240);
        lblOptionsHeader.Location = new Point(12, 8);
        lblOptionsHeader.Name = "lblOptionsHeader";
        lblOptionsHeader.Size = new Size(255, 19);
        lblOptionsHeader.TabIndex = 9;
        lblOptionsHeader.Text = "⚙️ 3. RDP und Tastatur-Einstellungen";
        // 
        // pnlBottom
        // 
        pnlBottom.BackColor = Color.FromArgb(15, 23, 42);
        pnlBottom.Controls.Add(lblStatus);
        pnlBottom.Controls.Add(prgTyping);
        pnlBottom.Controls.Add(btnStopTyping);
        pnlBottom.Controls.Add(btnStartTyping);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 524);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(870, 92);
        pnlBottom.TabIndex = 4;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 9F);
        lblStatus.ForeColor = Color.FromArgb(148, 163, 184);
        lblStatus.Location = new Point(18, 62);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(318, 15);
        lblStatus.TabIndex = 0;
        lblStatus.Text = "Bereit. Markiere ein Ziel mit [F8] und tippe Text mit [F9] ein.";
        // 
        // prgTyping
        // 
        prgTyping.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        prgTyping.Location = new Point(440, 20);
        prgTyping.Name = "prgTyping";
        prgTyping.Size = new Size(414, 26);
        prgTyping.TabIndex = 2;
        // 
        // btnStopTyping
        // 
        btnStopTyping.BackColor = Color.FromArgb(239, 68, 68);
        btnStopTyping.Cursor = Cursors.Hand;
        btnStopTyping.Enabled = false;
        btnStopTyping.FlatAppearance.BorderSize = 0;
        btnStopTyping.FlatStyle = FlatStyle.Flat;
        btnStopTyping.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnStopTyping.ForeColor = Color.White;
        btnStopTyping.Location = new Point(286, 12);
        btnStopTyping.Name = "btnStopTyping";
        btnStopTyping.Size = new Size(140, 42);
        btnStopTyping.TabIndex = 1;
        btnStopTyping.Text = "⏹ Abbrechen";
        btnStopTyping.UseVisualStyleBackColor = false;
        // 
        // btnStartTyping
        // 
        btnStartTyping.BackColor = Color.FromArgb(16, 185, 129);
        btnStartTyping.Cursor = Cursors.Hand;
        btnStartTyping.FlatAppearance.BorderSize = 0;
        btnStartTyping.FlatStyle = FlatStyle.Flat;
        btnStartTyping.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnStartTyping.ForeColor = Color.White;
        btnStartTyping.Location = new Point(16, 12);
        btnStartTyping.Name = "btnStartTyping";
        btnStartTyping.Size = new Size(260, 42);
        btnStartTyping.TabIndex = 0;
        btnStartTyping.Text = "🚀 Text jetzt eintippen (F9)";
        btnStartTyping.UseVisualStyleBackColor = false;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 23, 42);
        ClientSize = new Size(870, 616);
        Controls.Add(pnlBottom);
        Controls.Add(pnlOptions);
        Controls.Add(pnlInput);
        Controls.Add(pnlTarget);
        Controls.Add(pnlHeader);
        MinimumSize = new Size(780, 580);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
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
