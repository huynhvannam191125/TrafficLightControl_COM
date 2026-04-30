using System.Drawing;
using System.Windows.Forms;

namespace TrafficLightControl
{
    partial class Form1
    {
        // ── Traffic light panels ─────────────────────────────────
        private Label    lblTitle             = null!;
        private Panel    panelTrafficLight    = null!;
        private Panel    panelRed             = null!;
        private Panel    panelYellow          = null!;
        private Panel    panelGreen           = null!;
        private Label    lblTrafficRedText    = null!;
        private Label    lblTrafficYellowText = null!;
        private Label    lblTrafficGreenText  = null!;
        // ── Clock / Countdown ────────────────────────────────────
        private Label    lblHdrClock     = null!;
        private Label    lblClock        = null!;
        private Label    lblDate         = null!;
        private Label    lblHdrCountdown = null!;
        private Label    lblCountdown    = null!;
        private Label    lblGiayConLai   = null!;
        private Label    lblHdrStatus    = null!;
        private Label    lblCurrentMode  = null!;
        // ── GroupBox: Serial ─────────────────────────────────────
        private GroupBox grpSerial           = null!;
        private Label    lblSerialComCaption = null!;
        private ComboBox cmbPort             = null!;
        private Button   btnConnect          = null!;
        private Label    lblStatus           = null!;
        // ── GroupBox: Chọn chế độ điều khiển ────────────────────
        private GroupBox grpControlSource = null!;
        private CheckBox chkGUI           = null!;
        private Label    lblControlMode   = null!;
        // ── GroupBox: Chọn kiểu đèn ──────────────────────────────
        private GroupBox grpTrafficKind = null!;
        private Button   btnMode1       = null!;
        private Button   btnMode2       = null!;
        private Button   btnMode3       = null!;
        // ── GroupBox: Thời gian AUTO ─────────────────────────────
        private GroupBox grpTiming        = null!;
        private Label    lblTimeRedCap    = null!;
        private TextBox  txtRed           = null!;
        private Label    lblTimeRedS      = null!;
        private Label    lblTimeYellowCap = null!;
        private TextBox  txtYellow        = null!;
        private Label    lblTimeYellowS   = null!;
        private Label    lblTimeGreenCap  = null!;
        private TextBox  txtGreen         = null!;
        private Label    lblTimeGreenS    = null!;
        private Button   btnApplyTime     = null!;
        // ── Student info ─────────────────────────────────────────
        private TextBox  textBox1 = null!;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            panelTrafficLight = new Panel();
            panelRed = new Panel();
            panelYellow = new Panel();
            panelGreen = new Panel();
            lblTrafficRedText = new Label();
            lblTrafficYellowText = new Label();
            lblTrafficGreenText = new Label();
            lblHdrClock = new Label();
            lblClock = new Label();
            lblDate = new Label();
            lblHdrCountdown = new Label();
            lblCountdown = new Label();
            lblGiayConLai = new Label();
            lblHdrStatus = new Label();
            lblCurrentMode = new Label();
            grpSerial = new GroupBox();
            lblSerialComCaption = new Label();
            cmbPort = new ComboBox();
            btnConnect = new Button();
            lblStatus = new Label();
            grpControlSource = new GroupBox();
            chkGUI = new CheckBox();
            lblControlMode = new Label();
            grpTrafficKind = new GroupBox();
            btnMode1 = new Button();
            btnMode2 = new Button();
            btnMode3 = new Button();
            grpTiming = new GroupBox();
            lblTimeRedCap = new Label();
            txtRed = new TextBox();
            lblTimeRedS = new Label();
            lblTimeYellowCap = new Label();
            txtYellow = new TextBox();
            lblTimeYellowS = new Label();
            lblTimeGreenCap = new Label();
            txtGreen = new TextBox();
            lblTimeGreenS = new Label();
            btnApplyTime = new Button();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            panelTrafficLight.SuspendLayout();
            grpSerial.SuspendLayout();
            grpControlSource.SuspendLayout();
            grpTrafficKind.SuspendLayout();
            grpTiming.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Cyan;
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(499, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HỆ THỐNG ĐIỀU KHIỂN ĐÈN GIAO THÔNG";
            // 
            // panelTrafficLight
            // 
            panelTrafficLight.BackColor = Color.FromArgb(64, 64, 0);
            panelTrafficLight.Controls.Add(panelRed);
            panelTrafficLight.Controls.Add(panelYellow);
            panelTrafficLight.Controls.Add(panelGreen);
            panelTrafficLight.Controls.Add(lblTrafficRedText);
            panelTrafficLight.Controls.Add(lblTrafficYellowText);
            panelTrafficLight.Controls.Add(lblTrafficGreenText);
            panelTrafficLight.Location = new Point(15, 52);
            panelTrafficLight.Name = "panelTrafficLight";
            panelTrafficLight.Size = new Size(150, 500);
            panelTrafficLight.TabIndex = 1;
            panelTrafficLight.Paint += panelTrafficLight_Paint;
            // 
            // panelRed
            // 
            panelRed.BackColor = Color.FromArgb(60, 0, 0);
            panelRed.Location = new Point(25, 25);
            panelRed.Name = "panelRed";
            panelRed.Size = new Size(100, 120);
            panelRed.TabIndex = 0;
            panelRed.Paint += panelLight_Paint;
            // 
            // panelYellow
            // 
            panelYellow.BackColor = Color.FromArgb(60, 60, 0);
            panelYellow.Location = new Point(25, 175);
            panelYellow.Name = "panelYellow";
            panelYellow.Size = new Size(100, 120);
            panelYellow.TabIndex = 1;
            panelYellow.Paint += panelLight_Paint;
            // 
            // panelGreen
            // 
            panelGreen.BackColor = Color.FromArgb(0, 60, 0);
            panelGreen.Location = new Point(25, 325);
            panelGreen.Name = "panelGreen";
            panelGreen.Size = new Size(100, 120);
            panelGreen.TabIndex = 2;
            panelGreen.Paint += panelLight_Paint;
            // 
            // lblTrafficRedText
            // 
            lblTrafficRedText.AutoSize = true;
            lblTrafficRedText.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrafficRedText.ForeColor = Color.OrangeRed;
            lblTrafficRedText.Location = new Point(38, 148);
            lblTrafficRedText.Name = "lblTrafficRedText";
            lblTrafficRedText.Size = new Size(31, 20);
            lblTrafficRedText.TabIndex = 3;
            lblTrafficRedText.Text = "ĐỎ";
            // 
            // lblTrafficYellowText
            // 
            lblTrafficYellowText.AutoSize = true;
            lblTrafficYellowText.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrafficYellowText.ForeColor = Color.Gold;
            lblTrafficYellowText.Location = new Point(30, 298);
            lblTrafficYellowText.Name = "lblTrafficYellowText";
            lblTrafficYellowText.Size = new Size(52, 20);
            lblTrafficYellowText.TabIndex = 4;
            lblTrafficYellowText.Text = "VÀNG";
            // 
            // lblTrafficGreenText
            // 
            lblTrafficGreenText.AutoSize = true;
            lblTrafficGreenText.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrafficGreenText.ForeColor = Color.LimeGreen;
            lblTrafficGreenText.Location = new Point(30, 448);
            lblTrafficGreenText.Name = "lblTrafficGreenText";
            lblTrafficGreenText.Size = new Size(53, 20);
            lblTrafficGreenText.TabIndex = 5;
            lblTrafficGreenText.Text = "XANH";
            // 
            // lblHdrClock
            // 
            lblHdrClock.AutoSize = true;
            lblHdrClock.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblHdrClock.ForeColor = Color.FromArgb(128, 255, 255);
            lblHdrClock.Location = new Point(180, 52);
            lblHdrClock.Name = "lblHdrClock";
            lblHdrClock.Size = new Size(84, 20);
            lblHdrClock.TabIndex = 2;
            lblHdrClock.Text = " ĐỒNG HỒ";
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Consolas", 26F, FontStyle.Bold);
            lblClock.ForeColor = Color.Red;
            lblClock.Location = new Point(180, 72);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(214, 51);
            lblClock.TabIndex = 3;
            lblClock.Text = "00:00:00";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.ForeColor = Color.LightGray;
            lblDate.Location = new Point(188, 118);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(0, 21);
            lblDate.TabIndex = 4;
            // 
            // lblHdrCountdown
            // 
            lblHdrCountdown.AutoSize = true;
            lblHdrCountdown.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblHdrCountdown.ForeColor = Color.FromArgb(128, 255, 255);
            lblHdrCountdown.Location = new Point(180, 148);
            lblHdrCountdown.Name = "lblHdrCountdown";
            lblHdrCountdown.Size = new Size(102, 20);
            lblHdrCountdown.TabIndex = 5;
            lblHdrCountdown.Text = "ĐẾM NGƯỢC";
            // 
            // lblCountdown
            // 
            lblCountdown.BackColor = Color.FromArgb(10, 10, 15);
            lblCountdown.Font = new Font("Consolas", 52F, FontStyle.Bold);
            lblCountdown.ForeColor = Color.Gray;
            lblCountdown.Location = new Point(190, 170);
            lblCountdown.Name = "lblCountdown";
            lblCountdown.Size = new Size(120, 95);
            lblCountdown.TabIndex = 6;
            lblCountdown.Text = "--";
            lblCountdown.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGiayConLai
            // 
            lblGiayConLai.AutoSize = true;
            lblGiayConLai.Font = new Font("Segoe UI", 9F);
            lblGiayConLai.ForeColor = Color.LightGray;
            lblGiayConLai.Location = new Point(205, 270);
            lblGiayConLai.Name = "lblGiayConLai";
            lblGiayConLai.Size = new Size(85, 20);
            lblGiayConLai.TabIndex = 7;
            lblGiayConLai.Text = "giây còn lại";
            // 
            // lblHdrStatus
            // 
            lblHdrStatus.AutoSize = true;
            lblHdrStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblHdrStatus.ForeColor = Color.FromArgb(128, 255, 255);
            lblHdrStatus.Location = new Point(180, 298);
            lblHdrStatus.Name = "lblHdrStatus";
            lblHdrStatus.Size = new Size(102, 20);
            lblHdrStatus.TabIndex = 8;
            lblHdrStatus.Text = "TRẠNG THÁI";
            // 
            // lblCurrentMode
            // 
            lblCurrentMode.AutoSize = true;
            lblCurrentMode.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCurrentMode.ForeColor = Color.LightGray;
            lblCurrentMode.Location = new Point(180, 320);
            lblCurrentMode.MaximumSize = new Size(210, 0);
            lblCurrentMode.Name = "lblCurrentMode";
            lblCurrentMode.Size = new Size(129, 25);
            lblCurrentMode.TabIndex = 9;
            lblCurrentMode.Text = "Chờ kết nối...";
            // 
            // grpSerial
            // 
            grpSerial.BackColor = Color.FromArgb(64, 64, 0);
            grpSerial.Controls.Add(lblSerialComCaption);
            grpSerial.Controls.Add(cmbPort);
            grpSerial.Controls.Add(btnConnect);
            grpSerial.Controls.Add(lblStatus);
            grpSerial.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpSerial.ForeColor = Color.Red;
            grpSerial.Location = new Point(410, 52);
            grpSerial.Name = "grpSerial";
            grpSerial.Size = new Size(465, 108);
            grpSerial.TabIndex = 10;
            grpSerial.TabStop = false;
            grpSerial.Text = "Kết nối Serial (9600)";
            // 
            // lblSerialComCaption
            // 
            lblSerialComCaption.AutoSize = true;
            lblSerialComCaption.Font = new Font("Segoe UI", 9F);
            lblSerialComCaption.ForeColor = Color.LightGray;
            lblSerialComCaption.Location = new Point(14, 30);
            lblSerialComCaption.Name = "lblSerialComCaption";
            lblSerialComCaption.Size = new Size(84, 20);
            lblSerialComCaption.TabIndex = 0;
            lblSerialComCaption.Text = "Cổng COM:";
            // 
            // cmbPort
            // 
            cmbPort.BackColor = Color.FromArgb(35, 35, 50);
            cmbPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPort.FlatStyle = FlatStyle.Flat;
            cmbPort.ForeColor = Color.White;
            cmbPort.Location = new Point(104, 26);
            cmbPort.Name = "cmbPort";
            cmbPort.Size = new Size(120, 29);
            cmbPort.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.MediumSeaGreen;
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 100);
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(240, 24);
            btnConnect.Name = "btnConnect";
            btnConnect.Padding = new Padding(8, 0, 0, 0);
            btnConnect.Size = new Size(210, 30);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Kết nối";
            btnConnect.TextAlign = ContentAlignment.MiddleLeft;
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStatus.ForeColor = Color.OrangeRed;
            lblStatus.Location = new Point(14, 64);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(123, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "✖ Chưa kết nối";
            // 
            // grpControlSource
            // 
            grpControlSource.BackColor = Color.FromArgb(64, 64, 0);
            grpControlSource.Controls.Add(chkGUI);
            grpControlSource.Controls.Add(lblControlMode);
            grpControlSource.Enabled = false;
            grpControlSource.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpControlSource.ForeColor = Color.Red;
            grpControlSource.Location = new Point(410, 172);
            grpControlSource.Name = "grpControlSource";
            grpControlSource.Size = new Size(465, 100);
            grpControlSource.TabIndex = 11;
            grpControlSource.TabStop = false;
            grpControlSource.Text = " Chế độ điều khiển";
            // 
            // chkGUI
            // 
            chkGUI.AutoSize = true;
            chkGUI.Font = new Font("Segoe UI", 9.5F);
            chkGUI.ForeColor = Color.FromArgb(128, 255, 255);
            chkGUI.Location = new Point(14, 30);
            chkGUI.Name = "chkGUI";
            chkGUI.Size = new Size(285, 25);
            chkGUI.TabIndex = 0;
            chkGUI.Text = "Bật chế độ GUI (Máy tính điều khiển)";
            chkGUI.CheckedChanged += chkGUI_CheckedChanged;
            // 
            // lblControlMode
            // 
            lblControlMode.AutoSize = true;
            lblControlMode.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblControlMode.ForeColor = Color.Cyan;
            lblControlMode.Location = new Point(14, 62);
            lblControlMode.Name = "lblControlMode";
            lblControlMode.Size = new Size(175, 20);
            lblControlMode.TabIndex = 1;
            lblControlMode.Text = "Chế độ: MANUAL (Tại trụ)";
            // 
            // grpTrafficKind
            // 
            grpTrafficKind.BackColor = Color.FromArgb(64, 64, 0);
            grpTrafficKind.Controls.Add(btnMode1);
            grpTrafficKind.Controls.Add(btnMode2);
            grpTrafficKind.Controls.Add(btnMode3);
            grpTrafficKind.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpTrafficKind.ForeColor = Color.Red;
            grpTrafficKind.Location = new Point(410, 284);
            grpTrafficKind.Name = "grpTrafficKind";
            grpTrafficKind.Size = new Size(465, 196);
            grpTrafficKind.TabIndex = 12;
            grpTrafficKind.TabStop = false;
            grpTrafficKind.Text = "Chọn kiểu đèn  (cần bật GUI trước)";
            // 
            // btnMode1
            // 
            btnMode1.BackColor = Color.FromArgb(50, 50, 65);
            btnMode1.Cursor = Cursors.Hand;
            btnMode1.Enabled = false;
            btnMode1.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 100);
            btnMode1.FlatStyle = FlatStyle.Flat;
            btnMode1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMode1.ForeColor = Color.White;
            btnMode1.Location = new Point(14, 28);
            btnMode1.Name = "btnMode1";
            btnMode1.Padding = new Padding(10, 0, 0, 0);
            btnMode1.Size = new Size(436, 44);
            btnMode1.TabIndex = 0;
            btnMode1.Text = "1   MODE 1 – Đèn ĐỎ liên tục";
            btnMode1.TextAlign = ContentAlignment.MiddleLeft;
            btnMode1.UseVisualStyleBackColor = false;
            btnMode1.Click += btnMode1_Click;
            // 
            // btnMode2
            // 
            btnMode2.BackColor = Color.FromArgb(50, 50, 65);
            btnMode2.Cursor = Cursors.Hand;
            btnMode2.Enabled = false;
            btnMode2.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 100);
            btnMode2.FlatStyle = FlatStyle.Flat;
            btnMode2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMode2.ForeColor = Color.White;
            btnMode2.Location = new Point(14, 80);
            btnMode2.Name = "btnMode2";
            btnMode2.Padding = new Padding(10, 0, 0, 0);
            btnMode2.Size = new Size(436, 44);
            btnMode2.TabIndex = 1;
            btnMode2.Text = "2   MODE 2 – Vàng nhấp nháy";
            btnMode2.TextAlign = ContentAlignment.MiddleLeft;
            btnMode2.UseVisualStyleBackColor = false;
            btnMode2.Click += btnMode2_Click;
            // 
            // btnMode3
            // 
            btnMode3.BackColor = Color.FromArgb(0, 180, 120);
            btnMode3.Cursor = Cursors.Hand;
            btnMode3.Enabled = false;
            btnMode3.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 100);
            btnMode3.FlatStyle = FlatStyle.Flat;
            btnMode3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnMode3.ForeColor = Color.White;
            btnMode3.Location = new Point(14, 132);
            btnMode3.Name = "btnMode3";
            btnMode3.Padding = new Padding(10, 0, 0, 0);
            btnMode3.Size = new Size(436, 44);
            btnMode3.TabIndex = 2;
            btnMode3.Text = "3   MODE 3 – Theo giờ (5h–22h AUTO)";
            btnMode3.TextAlign = ContentAlignment.MiddleLeft;
            btnMode3.UseVisualStyleBackColor = false;
            btnMode3.Click += btnMode3_Click;
            // 
            // grpTiming
            // 
            grpTiming.BackColor = Color.FromArgb(64, 64, 0);
            grpTiming.Controls.Add(lblTimeRedCap);
            grpTiming.Controls.Add(txtRed);
            grpTiming.Controls.Add(lblTimeRedS);
            grpTiming.Controls.Add(lblTimeYellowCap);
            grpTiming.Controls.Add(txtYellow);
            grpTiming.Controls.Add(lblTimeYellowS);
            grpTiming.Controls.Add(lblTimeGreenCap);
            grpTiming.Controls.Add(txtGreen);
            grpTiming.Controls.Add(lblTimeGreenS);
            grpTiming.Controls.Add(btnApplyTime);
            grpTiming.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpTiming.ForeColor = Color.Red;
            grpTiming.Location = new Point(410, 492);
            grpTiming.Name = "grpTiming";
            grpTiming.Size = new Size(465, 77);
            grpTiming.TabIndex = 13;
            grpTiming.TabStop = false;
            grpTiming.Text = "Thời gian AUTO (1–9 giây)";
            // 
            // lblTimeRedCap
            // 
            lblTimeRedCap.AutoSize = true;
            lblTimeRedCap.Font = new Font("Segoe UI", 9F);
            lblTimeRedCap.ForeColor = Color.LightGray;
            lblTimeRedCap.Location = new Point(3, 32);
            lblTimeRedCap.Name = "lblTimeRedCap";
            lblTimeRedCap.Size = new Size(57, 20);
            lblTimeRedCap.TabIndex = 0;
            lblTimeRedCap.Text = "🔴 Đỏ:";
            // 
            // txtRed
            // 
            txtRed.BackColor = Color.FromArgb(35, 35, 50);
            txtRed.BorderStyle = BorderStyle.FixedSingle;
            txtRed.Font = new Font("Consolas", 12F, FontStyle.Bold);
            txtRed.ForeColor = Color.White;
            txtRed.Location = new Point(55, 28);
            txtRed.MaxLength = 1;
            txtRed.Name = "txtRed";
            txtRed.Size = new Size(40, 31);
            txtRed.TabIndex = 1;
            txtRed.Text = "5";
            txtRed.TextAlign = HorizontalAlignment.Center;
            txtRed.TextChanged += txtTime_TextChanged;
            txtRed.KeyPress += txtTime_KeyPress;
            // 
            // lblTimeRedS
            // 
            lblTimeRedS.AutoSize = true;
            lblTimeRedS.Font = new Font("Segoe UI", 9F);
            lblTimeRedS.ForeColor = Color.LightGray;
            lblTimeRedS.Location = new Point(110, 32);
            lblTimeRedS.Name = "lblTimeRedS";
            lblTimeRedS.Size = new Size(15, 20);
            lblTimeRedS.TabIndex = 2;
            lblTimeRedS.Text = "s";
            // 
            // lblTimeYellowCap
            // 
            lblTimeYellowCap.AutoSize = true;
            lblTimeYellowCap.Font = new Font("Segoe UI", 9F);
            lblTimeYellowCap.ForeColor = Color.LightGray;
            lblTimeYellowCap.Location = new Point(119, 32);
            lblTimeYellowCap.Name = "lblTimeYellowCap";
            lblTimeYellowCap.Size = new Size(70, 20);
            lblTimeYellowCap.TabIndex = 3;
            lblTimeYellowCap.Text = "\U0001f7e1 Vàng:";
            // 
            // txtYellow
            // 
            txtYellow.BackColor = Color.FromArgb(35, 35, 50);
            txtYellow.BorderStyle = BorderStyle.FixedSingle;
            txtYellow.Font = new Font("Consolas", 12F, FontStyle.Bold);
            txtYellow.ForeColor = Color.White;
            txtYellow.Location = new Point(182, 28);
            txtYellow.MaxLength = 1;
            txtYellow.Name = "txtYellow";
            txtYellow.Size = new Size(40, 31);
            txtYellow.TabIndex = 4;
            txtYellow.Text = "3";
            txtYellow.TextAlign = HorizontalAlignment.Center;
            txtYellow.TextChanged += txtTime_TextChanged;
            txtYellow.KeyPress += txtTime_KeyPress;
            // 
            // lblTimeYellowS
            // 
            lblTimeYellowS.AutoSize = true;
            lblTimeYellowS.Font = new Font("Segoe UI", 9F);
            lblTimeYellowS.ForeColor = Color.LightGray;
            lblTimeYellowS.Location = new Point(237, 32);
            lblTimeYellowS.Name = "lblTimeYellowS";
            lblTimeYellowS.Size = new Size(15, 20);
            lblTimeYellowS.TabIndex = 5;
            lblTimeYellowS.Text = "s";
            // 
            // lblTimeGreenCap
            // 
            lblTimeGreenCap.AutoSize = true;
            lblTimeGreenCap.Font = new Font("Segoe UI", 9F);
            lblTimeGreenCap.ForeColor = Color.LightGray;
            lblTimeGreenCap.Location = new Point(246, 32);
            lblTimeGreenCap.Name = "lblTimeGreenCap";
            lblTimeGreenCap.Size = new Size(70, 20);
            lblTimeGreenCap.TabIndex = 6;
            lblTimeGreenCap.Text = "\U0001f7e2 Xanh:";
            // 
            // txtGreen
            // 
            txtGreen.BackColor = Color.FromArgb(35, 35, 50);
            txtGreen.BorderStyle = BorderStyle.FixedSingle;
            txtGreen.Font = new Font("Consolas", 12F, FontStyle.Bold);
            txtGreen.ForeColor = Color.White;
            txtGreen.Location = new Point(309, 28);
            txtGreen.MaxLength = 1;
            txtGreen.Name = "txtGreen";
            txtGreen.Size = new Size(40, 31);
            txtGreen.TabIndex = 7;
            txtGreen.Text = "8";
            txtGreen.TextAlign = HorizontalAlignment.Center;
            txtGreen.TextChanged += txtTime_TextChanged;
            txtGreen.KeyPress += txtTime_KeyPress;
            // 
            // lblTimeGreenS
            // 
            lblTimeGreenS.AutoSize = true;
            lblTimeGreenS.Font = new Font("Segoe UI", 9F);
            lblTimeGreenS.ForeColor = Color.LightGray;
            lblTimeGreenS.Location = new Point(355, 32);
            lblTimeGreenS.Name = "lblTimeGreenS";
            lblTimeGreenS.Size = new Size(15, 20);
            lblTimeGreenS.TabIndex = 8;
            lblTimeGreenS.Text = "s";
            // 
            // btnApplyTime
            // 
            btnApplyTime.BackColor = Color.FromArgb(0, 155, 100);
            btnApplyTime.Cursor = Cursors.Hand;
            btnApplyTime.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 100);
            btnApplyTime.FlatStyle = FlatStyle.Flat;
            btnApplyTime.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApplyTime.ForeColor = Color.White;
            btnApplyTime.Location = new Point(375, 26);
            btnApplyTime.Name = "btnApplyTime";
            btnApplyTime.Padding = new Padding(6, 0, 0, 0);
            btnApplyTime.Size = new Size(75, 30);
            btnApplyTime.TabIndex = 9;
            btnApplyTime.Text = "✔ Áp Dụng";
            btnApplyTime.UseVisualStyleBackColor = false;
            btnApplyTime.Click += btnApplyTime_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveCaptionText;
            textBox1.Font = new Font("Showcard Gothic", 13.8F);
            textBox1.ForeColor = Color.Red;
            textBox1.Location = new Point(180, 395);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(210, 36);
            textBox1.TabIndex = 14;
            textBox1.Text = "Huỳnh Văn Nam";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.InactiveCaptionText;
            textBox3.Font = new Font("Showcard Gothic", 13.8F);
            textBox3.ForeColor = Color.Red;
            textBox3.Location = new Point(180, 437);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(210, 32);
            textBox3.TabIndex = 15;
            textBox3.Text = "23647071";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 0);
            ClientSize = new Size(893, 582);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(lblTitle);
            Controls.Add(panelTrafficLight);
            Controls.Add(lblHdrClock);
            Controls.Add(lblClock);
            Controls.Add(lblDate);
            Controls.Add(lblHdrCountdown);
            Controls.Add(lblCountdown);
            Controls.Add(lblGiayConLai);
            Controls.Add(lblHdrStatus);
            Controls.Add(lblCurrentMode);
            Controls.Add(grpSerial);
            Controls.Add(grpControlSource);
            Controls.Add(grpTrafficKind);
            Controls.Add(grpTiming);
            Font = new Font("Segoe UI", 9.5F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Điều Khiển Đèn Giao Thông";
            Load += Form1_Load;
            panelTrafficLight.ResumeLayout(false);
            panelTrafficLight.PerformLayout();
            grpSerial.ResumeLayout(false);
            grpSerial.PerformLayout();
            grpControlSource.ResumeLayout(false);
            grpControlSource.PerformLayout();
            grpTrafficKind.ResumeLayout(false);
            grpTiming.ResumeLayout(false);
            grpTiming.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox textBox3;
    }
}
