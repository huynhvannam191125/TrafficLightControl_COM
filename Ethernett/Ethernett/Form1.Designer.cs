using System.Drawing;
using System.Windows.Forms;

namespace Ethernet_TrafficLight
{
    partial class Form1
    {
        private Panel    panelTrafficLight;
        private Panel    panelRed;
        private Panel    panelYellow;
        private Panel    panelGreen;
        private Label    lblTrafficRedText;
        private Label    lblTrafficYellowText;
        private Label    lblTrafficGreenText;
        private Label    lblHdrClock;
        private Label    lblClock;
        private Label    lblDate;
        private Label    lblHdrCountdown;
        private Label    lblCountdown;
        private Label    lblGiayConLai;
        private Label    lblHdrStatus;
        private Label    lblCurrentMode;
        private GroupBox grpServer;
        private Label    lblIPCaption;
        private TextBox  txtServerIP;
        private Label    lblPortCaption;
        private TextBox  txtServerPort;
        private Button   btnStartServer;
        private Label    lblStatus;
        private GroupBox grpControlSource;
        private CheckBox chkGUI;
        private Label    lblControlMode;
        private GroupBox grpTrafficKind;
        private Button   btnMode1;
        private Button   btnMode2;
        private Button   btnMode3;
        private GroupBox grpTiming;
        private Label    lblTimeRedCap;
        private TextBox  txtRed;
        private Label    lblTimeRedS;
        private Label    lblTimeYellowCap;
        private TextBox  txtYellow;
        private Label    lblTimeYellowS;
        private Label    lblTimeGreenCap;
        private TextBox  txtGreen;
        private Label    lblTimeGreenS;
        private Button   btnApplyTime;

        private void InitializeComponent()
        {
            this.panelTrafficLight = new System.Windows.Forms.Panel();
            this.panelRed = new System.Windows.Forms.Panel();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.panelGreen = new System.Windows.Forms.Panel();
            this.lblTrafficRedText = new System.Windows.Forms.Label();
            this.lblTrafficYellowText = new System.Windows.Forms.Label();
            this.lblTrafficGreenText = new System.Windows.Forms.Label();
            this.lblHdrClock = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHdrCountdown = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblGiayConLai = new System.Windows.Forms.Label();
            this.lblHdrStatus = new System.Windows.Forms.Label();
            this.lblCurrentMode = new System.Windows.Forms.Label();
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.lblIPCaption = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblPortCaption = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpControlSource = new System.Windows.Forms.GroupBox();
            this.chkGUI = new System.Windows.Forms.CheckBox();
            this.lblControlMode = new System.Windows.Forms.Label();
            this.grpTrafficKind = new System.Windows.Forms.GroupBox();
            this.btnMode1 = new System.Windows.Forms.Button();
            this.btnMode2 = new System.Windows.Forms.Button();
            this.btnMode3 = new System.Windows.Forms.Button();
            this.grpTiming = new System.Windows.Forms.GroupBox();
            this.lblTimeRedCap = new System.Windows.Forms.Label();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.lblTimeRedS = new System.Windows.Forms.Label();
            this.lblTimeYellowCap = new System.Windows.Forms.Label();
            this.txtYellow = new System.Windows.Forms.TextBox();
            this.lblTimeYellowS = new System.Windows.Forms.Label();
            this.lblTimeGreenCap = new System.Windows.Forms.Label();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.lblTimeGreenS = new System.Windows.Forms.Label();
            this.btnApplyTime = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button888_click = new System.Windows.Forms.Button();
            this.button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn5_click = new System.Windows.Forms.Button();
            this.panelTrafficLight.SuspendLayout();
            this.grpServer.SuspendLayout();
            this.grpControlSource.SuspendLayout();
            this.grpTrafficKind.SuspendLayout();
            this.grpTiming.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTrafficLight
            // 
            this.panelTrafficLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panelTrafficLight.Controls.Add(this.panelRed);
            this.panelTrafficLight.Controls.Add(this.panelYellow);
            this.panelTrafficLight.Controls.Add(this.panelGreen);
            this.panelTrafficLight.Controls.Add(this.lblTrafficRedText);
            this.panelTrafficLight.Controls.Add(this.lblTrafficYellowText);
            this.panelTrafficLight.Controls.Add(this.lblTrafficGreenText);
            this.panelTrafficLight.Location = new System.Drawing.Point(12, 44);
            this.panelTrafficLight.Name = "panelTrafficLight";
            this.panelTrafficLight.Size = new System.Drawing.Size(150, 500);
            this.panelTrafficLight.TabIndex = 1;
            this.panelTrafficLight.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTrafficLight_Paint);
            // 
            // panelRed
            // 
            this.panelRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelRed.Location = new System.Drawing.Point(25, 25);
            this.panelRed.Name = "panelRed";
            this.panelRed.Size = new System.Drawing.Size(100, 120);
            this.panelRed.TabIndex = 0;
            this.panelRed.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLight_Paint);
            // 
            // panelYellow
            // 
            this.panelYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.panelYellow.Location = new System.Drawing.Point(25, 175);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(100, 120);
            this.panelYellow.TabIndex = 1;
            this.panelYellow.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLight_Paint);
            // 
            // panelGreen
            // 
            this.panelGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.panelGreen.Location = new System.Drawing.Point(25, 325);
            this.panelGreen.Name = "panelGreen";
            this.panelGreen.Size = new System.Drawing.Size(100, 120);
            this.panelGreen.TabIndex = 2;
            this.panelGreen.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLight_Paint);
            // 
            // lblTrafficRedText
            // 
            this.lblTrafficRedText.AutoSize = true;
            this.lblTrafficRedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrafficRedText.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTrafficRedText.Location = new System.Drawing.Point(38, 148);
            this.lblTrafficRedText.Name = "lblTrafficRedText";
            this.lblTrafficRedText.Size = new System.Drawing.Size(31, 20);
            this.lblTrafficRedText.TabIndex = 3;
            this.lblTrafficRedText.Text = "DO";
            // 
            // lblTrafficYellowText
            // 
            this.lblTrafficYellowText.AutoSize = true;
            this.lblTrafficYellowText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrafficYellowText.ForeColor = System.Drawing.Color.Gold;
            this.lblTrafficYellowText.Location = new System.Drawing.Point(30, 298);
            this.lblTrafficYellowText.Name = "lblTrafficYellowText";
            this.lblTrafficYellowText.Size = new System.Drawing.Size(52, 20);
            this.lblTrafficYellowText.TabIndex = 4;
            this.lblTrafficYellowText.Text = "VANG";
            // 
            // lblTrafficGreenText
            // 
            this.lblTrafficGreenText.AutoSize = true;
            this.lblTrafficGreenText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrafficGreenText.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTrafficGreenText.Location = new System.Drawing.Point(30, 448);
            this.lblTrafficGreenText.Name = "lblTrafficGreenText";
            this.lblTrafficGreenText.Size = new System.Drawing.Size(53, 20);
            this.lblTrafficGreenText.TabIndex = 5;
            this.lblTrafficGreenText.Text = "XANH";
            // 
            // lblHdrClock
            // 
            this.lblHdrClock.AutoSize = true;
            this.lblHdrClock.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHdrClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHdrClock.Location = new System.Drawing.Point(180, 52);
            this.lblHdrClock.Name = "lblHdrClock";
            this.lblHdrClock.Size = new System.Drawing.Size(80, 20);
            this.lblHdrClock.TabIndex = 2;
            this.lblHdrClock.Text = "DONG HO";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Consolas", 26F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.Red;
            this.lblClock.Location = new System.Drawing.Point(180, 72);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(214, 51);
            this.lblClock.TabIndex = 3;
            this.lblClock.Text = "00:00:00";
            this.lblClock.Click += new System.EventHandler(this.lblClock_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.LightGray;
            this.lblDate.Location = new System.Drawing.Point(188, 118);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 21);
            this.lblDate.TabIndex = 4;
            // 
            // lblHdrCountdown
            // 
            this.lblHdrCountdown.AutoSize = true;
            this.lblHdrCountdown.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHdrCountdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHdrCountdown.Location = new System.Drawing.Point(180, 148);
            this.lblHdrCountdown.Name = "lblHdrCountdown";
            this.lblHdrCountdown.Size = new System.Drawing.Size(100, 20);
            this.lblHdrCountdown.TabIndex = 5;
            this.lblHdrCountdown.Text = "DEM NGUOC";
            // 
            // lblCountdown
            // 
            this.lblCountdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.lblCountdown.Font = new System.Drawing.Font("Consolas", 52F, System.Drawing.FontStyle.Bold);
            this.lblCountdown.ForeColor = System.Drawing.Color.Gray;
            this.lblCountdown.Location = new System.Drawing.Point(190, 170);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(120, 95);
            this.lblCountdown.TabIndex = 6;
            this.lblCountdown.Text = "--";
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCountdown.Click += new System.EventHandler(this.lblCountdown_Click);
            // 
            // lblGiayConLai
            // 
            this.lblGiayConLai.AutoSize = true;
            this.lblGiayConLai.ForeColor = System.Drawing.Color.LightGray;
            this.lblGiayConLai.Location = new System.Drawing.Point(205, 270);
            this.lblGiayConLai.Name = "lblGiayConLai";
            this.lblGiayConLai.Size = new System.Drawing.Size(88, 21);
            this.lblGiayConLai.TabIndex = 7;
            this.lblGiayConLai.Text = "giay con lai";
            // 
            // lblHdrStatus
            // 
            this.lblHdrStatus.AutoSize = true;
            this.lblHdrStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHdrStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHdrStatus.Location = new System.Drawing.Point(180, 298);
            this.lblHdrStatus.Name = "lblHdrStatus";
            this.lblHdrStatus.Size = new System.Drawing.Size(102, 20);
            this.lblHdrStatus.TabIndex = 8;
            this.lblHdrStatus.Text = "TRANG THAI";
            // 
            // lblCurrentMode
            // 
            this.lblCurrentMode.AutoSize = true;
            this.lblCurrentMode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentMode.ForeColor = System.Drawing.Color.LightGray;
            this.lblCurrentMode.Location = new System.Drawing.Point(180, 320);
            this.lblCurrentMode.MaximumSize = new System.Drawing.Size(210, 0);
            this.lblCurrentMode.Name = "lblCurrentMode";
            this.lblCurrentMode.Size = new System.Drawing.Size(129, 25);
            this.lblCurrentMode.TabIndex = 9;
            this.lblCurrentMode.Text = "Cho ket noi...";
            // 
            // grpServer
            // 
            this.grpServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.grpServer.Controls.Add(this.lblIPCaption);
            this.grpServer.Controls.Add(this.txtServerIP);
            this.grpServer.Controls.Add(this.lblPortCaption);
            this.grpServer.Controls.Add(this.txtServerPort);
            this.grpServer.Controls.Add(this.btnStartServer);
            this.grpServer.Controls.Add(this.lblStatus);
            this.grpServer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpServer.ForeColor = System.Drawing.Color.Cyan;
            this.grpServer.Location = new System.Drawing.Point(410, 52);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(465, 120);
            this.grpServer.TabIndex = 10;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "SETUP";
            this.grpServer.Enter += new System.EventHandler(this.grpServer_Enter);
            // 
            // lblIPCaption
            // 
            this.lblIPCaption.AutoSize = true;
            this.lblIPCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIPCaption.ForeColor = System.Drawing.Color.LightGray;
            this.lblIPCaption.Location = new System.Drawing.Point(14, 32);
            this.lblIPCaption.Name = "lblIPCaption";
            this.lblIPCaption.Size = new System.Drawing.Size(69, 20);
            this.lblIPCaption.TabIndex = 0;
            this.lblIPCaption.Text = "IP Server:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtServerIP.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtServerIP.ForeColor = System.Drawing.Color.White;
            this.txtServerIP.Location = new System.Drawing.Point(90, 28);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(130, 27);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.Text = "192.168.1.10";
            this.txtServerIP.TextChanged += new System.EventHandler(this.txtServerIP_TextChanged);
            // 
            // lblPortCaption
            // 
            this.lblPortCaption.AutoSize = true;
            this.lblPortCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPortCaption.ForeColor = System.Drawing.Color.LightGray;
            this.lblPortCaption.Location = new System.Drawing.Point(232, 32);
            this.lblPortCaption.Name = "lblPortCaption";
            this.lblPortCaption.Size = new System.Drawing.Size(38, 20);
            this.lblPortCaption.TabIndex = 2;
            this.lblPortCaption.Text = "Port:";
            // 
            // txtServerPort
            // 
            this.txtServerPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtServerPort.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtServerPort.ForeColor = System.Drawing.Color.White;
            this.txtServerPort.Location = new System.Drawing.Point(270, 28);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(65, 27);
            this.txtServerPort.TabIndex = 3;
            this.txtServerPort.Text = "5000";
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnStartServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartServer.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnStartServer.ForeColor = System.Drawing.Color.White;
            this.btnStartServer.Location = new System.Drawing.Point(350, 25);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(100, 32);
            this.btnStartServer.TabIndex = 4;
            this.btnStartServer.Text = "Khoi dong";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location = new System.Drawing.Point(14, 70);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(179, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "X Server chua khoi dong";
            // 
            // grpControlSource
            // 
            this.grpControlSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.grpControlSource.Controls.Add(this.chkGUI);
            this.grpControlSource.Controls.Add(this.lblControlMode);
            this.grpControlSource.Enabled = false;
            this.grpControlSource.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpControlSource.ForeColor = System.Drawing.Color.Cyan;
            this.grpControlSource.Location = new System.Drawing.Point(410, 184);
            this.grpControlSource.Name = "grpControlSource";
            this.grpControlSource.Size = new System.Drawing.Size(465, 88);
            this.grpControlSource.TabIndex = 11;
            this.grpControlSource.TabStop = false;
            this.grpControlSource.Text = "Che do dieu khien";
            // 
            // chkGUI
            // 
            this.chkGUI.AutoSize = true;
            this.chkGUI.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkGUI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chkGUI.Location = new System.Drawing.Point(14, 30);
            this.chkGUI.Name = "chkGUI";
            this.chkGUI.Size = new System.Drawing.Size(285, 25);
            this.chkGUI.TabIndex = 0;
            this.chkGUI.Text = "Bat che do GUI (May tinh dieu khien)";
            this.chkGUI.CheckedChanged += new System.EventHandler(this.chkGUI_CheckedChanged);
            // 
            // lblControlMode
            // 
            this.lblControlMode.AutoSize = true;
            this.lblControlMode.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblControlMode.ForeColor = System.Drawing.Color.Cyan;
            this.lblControlMode.Location = new System.Drawing.Point(14, 58);
            this.lblControlMode.Name = "lblControlMode";
            this.lblControlMode.Size = new System.Drawing.Size(175, 20);
            this.lblControlMode.TabIndex = 1;
            this.lblControlMode.Text = "Che do: MANUAL (Tai tru)";
            // 
            // grpTrafficKind
            // 
            this.grpTrafficKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.grpTrafficKind.Controls.Add(this.btnMode1);
            this.grpTrafficKind.Controls.Add(this.btnMode2);
            this.grpTrafficKind.Controls.Add(this.btnMode3);
            this.grpTrafficKind.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpTrafficKind.ForeColor = System.Drawing.Color.Cyan;
            this.grpTrafficKind.Location = new System.Drawing.Point(410, 284);
            this.grpTrafficKind.Name = "grpTrafficKind";
            this.grpTrafficKind.Size = new System.Drawing.Size(465, 196);
            this.grpTrafficKind.TabIndex = 12;
            this.grpTrafficKind.TabStop = false;
            this.grpTrafficKind.Text = "Chon kieu den (can bat GUI truoc)";
            // 
            // btnMode1
            // 
            this.btnMode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.btnMode1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMode1.Enabled = false;
            this.btnMode1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btnMode1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMode1.ForeColor = System.Drawing.Color.White;
            this.btnMode1.Location = new System.Drawing.Point(14, 28);
            this.btnMode1.Name = "btnMode1";
            this.btnMode1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMode1.Size = new System.Drawing.Size(436, 44);
            this.btnMode1.TabIndex = 0;
            this.btnMode1.Text = "1   MODE 1 - Den DO lien tuc";
            this.btnMode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMode1.UseVisualStyleBackColor = false;
            this.btnMode1.Click += new System.EventHandler(this.btnMode1_Click);
            // 
            // btnMode2
            // 
            this.btnMode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            this.btnMode2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMode2.Enabled = false;
            this.btnMode2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btnMode2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMode2.ForeColor = System.Drawing.Color.White;
            this.btnMode2.Location = new System.Drawing.Point(14, 80);
            this.btnMode2.Name = "btnMode2";
            this.btnMode2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMode2.Size = new System.Drawing.Size(436, 44);
            this.btnMode2.TabIndex = 1;
            this.btnMode2.Text = "2   MODE 2 - Vang nhap nhay";
            this.btnMode2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMode2.UseVisualStyleBackColor = false;
            this.btnMode2.Click += new System.EventHandler(this.btnMode2_Click);
            // 
            // btnMode3
            // 
            this.btnMode3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(120)))));
            this.btnMode3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMode3.Enabled = false;
            this.btnMode3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btnMode3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnMode3.ForeColor = System.Drawing.Color.White;
            this.btnMode3.Location = new System.Drawing.Point(14, 132);
            this.btnMode3.Name = "btnMode3";
            this.btnMode3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMode3.Size = new System.Drawing.Size(436, 44);
            this.btnMode3.TabIndex = 2;
            this.btnMode3.Text = "3   MODE 3 - Theo gio (5h-22h AUTO)";
            this.btnMode3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMode3.UseVisualStyleBackColor = false;
            this.btnMode3.Click += new System.EventHandler(this.btnMode3_Click);
            // 
            // grpTiming
            // 
            this.grpTiming.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.grpTiming.Controls.Add(this.lblTimeRedCap);
            this.grpTiming.Controls.Add(this.txtRed);
            this.grpTiming.Controls.Add(this.lblTimeRedS);
            this.grpTiming.Controls.Add(this.lblTimeYellowCap);
            this.grpTiming.Controls.Add(this.txtYellow);
            this.grpTiming.Controls.Add(this.lblTimeYellowS);
            this.grpTiming.Controls.Add(this.lblTimeGreenCap);
            this.grpTiming.Controls.Add(this.txtGreen);
            this.grpTiming.Controls.Add(this.lblTimeGreenS);
            this.grpTiming.Controls.Add(this.btnApplyTime);
            this.grpTiming.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpTiming.ForeColor = System.Drawing.Color.Cyan;
            this.grpTiming.Location = new System.Drawing.Point(410, 492);
            this.grpTiming.Name = "grpTiming";
            this.grpTiming.Size = new System.Drawing.Size(465, 77);
            this.grpTiming.TabIndex = 13;
            this.grpTiming.TabStop = false;
            this.grpTiming.Text = "Thoi gian AUTO (1-9 giay)";
            // 
            // lblTimeRedCap
            // 
            this.lblTimeRedCap.AutoSize = true;
            this.lblTimeRedCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimeRedCap.ForeColor = System.Drawing.Color.LightGray;
            this.lblTimeRedCap.Location = new System.Drawing.Point(3, 32);
            this.lblTimeRedCap.Name = "lblTimeRedCap";
            this.lblTimeRedCap.Size = new System.Drawing.Size(32, 20);
            this.lblTimeRedCap.TabIndex = 0;
            this.lblTimeRedCap.Text = "Do:";
            // 
            // txtRed
            // 
            this.txtRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtRed.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txtRed.ForeColor = System.Drawing.Color.White;
            this.txtRed.Location = new System.Drawing.Point(35, 28);
            this.txtRed.MaxLength = 1;
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(40, 31);
            this.txtRed.TabIndex = 1;
            this.txtRed.Text = "5";
            this.txtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRed.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            this.txtRed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // lblTimeRedS
            // 
            this.lblTimeRedS.AutoSize = true;
            this.lblTimeRedS.ForeColor = System.Drawing.Color.LightGray;
            this.lblTimeRedS.Location = new System.Drawing.Point(80, 32);
            this.lblTimeRedS.Name = "lblTimeRedS";
            this.lblTimeRedS.Size = new System.Drawing.Size(17, 21);
            this.lblTimeRedS.TabIndex = 2;
            this.lblTimeRedS.Text = "s";
            // 
            // lblTimeYellowCap
            // 
            this.lblTimeYellowCap.AutoSize = true;
            this.lblTimeYellowCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimeYellowCap.ForeColor = System.Drawing.Color.LightGray;
            this.lblTimeYellowCap.Location = new System.Drawing.Point(100, 32);
            this.lblTimeYellowCap.Name = "lblTimeYellowCap";
            this.lblTimeYellowCap.Size = new System.Drawing.Size(45, 20);
            this.lblTimeYellowCap.TabIndex = 3;
            this.lblTimeYellowCap.Text = "Vang:";
            // 
            // txtYellow
            // 
            this.txtYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtYellow.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txtYellow.ForeColor = System.Drawing.Color.White;
            this.txtYellow.Location = new System.Drawing.Point(148, 28);
            this.txtYellow.MaxLength = 1;
            this.txtYellow.Name = "txtYellow";
            this.txtYellow.Size = new System.Drawing.Size(40, 31);
            this.txtYellow.TabIndex = 4;
            this.txtYellow.Text = "3";
            this.txtYellow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYellow.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            this.txtYellow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // lblTimeYellowS
            // 
            this.lblTimeYellowS.AutoSize = true;
            this.lblTimeYellowS.ForeColor = System.Drawing.Color.LightGray;
            this.lblTimeYellowS.Location = new System.Drawing.Point(193, 32);
            this.lblTimeYellowS.Name = "lblTimeYellowS";
            this.lblTimeYellowS.Size = new System.Drawing.Size(17, 21);
            this.lblTimeYellowS.TabIndex = 5;
            this.lblTimeYellowS.Text = "s";
            // 
            // lblTimeGreenCap
            // 
            this.lblTimeGreenCap.AutoSize = true;
            this.lblTimeGreenCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTimeGreenCap.ForeColor = System.Drawing.Color.LightGray;
            this.lblTimeGreenCap.Location = new System.Drawing.Point(210, 32);
            this.lblTimeGreenCap.Name = "lblTimeGreenCap";
            this.lblTimeGreenCap.Size = new System.Drawing.Size(45, 20);
            this.lblTimeGreenCap.TabIndex = 6;
            this.lblTimeGreenCap.Text = "Xanh:";
            // 
            // txtGreen
            // 
            this.txtGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtGreen.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txtGreen.ForeColor = System.Drawing.Color.White;
            this.txtGreen.Location = new System.Drawing.Point(260, 28);
            this.txtGreen.MaxLength = 1;
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(40, 31);
            this.txtGreen.TabIndex = 7;
            this.txtGreen.Text = "8";
            this.txtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGreen.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            this.txtGreen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // lblTimeGreenS
            // 
            this.lblTimeGreenS.AutoSize = true;
            this.lblTimeGreenS.ForeColor = System.Drawing.Color.LightGray;
            this.lblTimeGreenS.Location = new System.Drawing.Point(305, 32);
            this.lblTimeGreenS.Name = "lblTimeGreenS";
            this.lblTimeGreenS.Size = new System.Drawing.Size(17, 21);
            this.lblTimeGreenS.TabIndex = 8;
            this.lblTimeGreenS.Text = "s";
            // 
            // btnApplyTime
            // 
            this.btnApplyTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(100)))));
            this.btnApplyTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btnApplyTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyTime.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnApplyTime.ForeColor = System.Drawing.Color.White;
            this.btnApplyTime.Location = new System.Drawing.Point(365, 26);
            this.btnApplyTime.Name = "btnApplyTime";
            this.btnApplyTime.Size = new System.Drawing.Size(85, 30);
            this.btnApplyTime.TabIndex = 9;
            this.btnApplyTime.Text = "Ap Dung";
            this.btnApplyTime.UseVisualStyleBackColor = false;
            this.btnApplyTime.Click += new System.EventHandler(this.btnApplyTime_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(189, 399);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(184, 29);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "HUỲNH VĂN NAM";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox2.Location = new System.Drawing.Point(189, 425);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(184, 29);
            this.textBox2.TabIndex = 15;
            this.textBox2.Text = "23647071";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button888_click
            // 
            this.button888_click.BackColor = System.Drawing.Color.ForestGreen;
            this.button888_click.Location = new System.Drawing.Point(900, 239);
            this.button888_click.Name = "button888_click";
            this.button888_click.Size = new System.Drawing.Size(138, 52);
            this.button888_click.TabIndex = 16;
            this.button888_click.Text = "áp dụng";
            this.button888_click.UseVisualStyleBackColor = false;
            this.button888_click.Click += new System.EventHandler(this.button888_click_Click);
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(100)))));
            this.button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button.ForeColor = System.Drawing.Color.White;
            this.button.Location = new System.Drawing.Point(890, 486);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(85, 30);
            this.button.TabIndex = 9;
            this.button.Text = "Ap Dung";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.btnApplyTime_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(1044, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 500);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTrafficLight_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(25, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 120);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLight_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.panel3.Location = new System.Drawing.Point(25, 175);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 120);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLight_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.panel4.Location = new System.Drawing.Point(25, 325);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 120);
            this.panel4.TabIndex = 2;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLight_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(38, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "DO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(30, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "VANG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(30, 448);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "XANH";
            // 
            // btn5_click
            // 
            this.btn5_click.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(100)))));
            this.btn5_click.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn5_click.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btn5_click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5_click.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btn5_click.ForeColor = System.Drawing.Color.White;
            this.btn5_click.Location = new System.Drawing.Point(245, 511);
            this.btn5_click.Name = "btn5_click";
            this.btn5_click.Size = new System.Drawing.Size(85, 30);
            this.btn5_click.TabIndex = 9;
            this.btn5_click.Text = "Ap Dung";
            this.btn5_click.UseVisualStyleBackColor = false;
            this.btn5_click.Click += new System.EventHandler(this.btnApplyTime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1428, 1055);
            this.Controls.Add(this.button888_click);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTrafficLight);
            this.Controls.Add(this.lblHdrClock);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblHdrCountdown);
            this.Controls.Add(this.btn5_click);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.button);
            this.Controls.Add(this.lblGiayConLai);
            this.Controls.Add(this.lblHdrStatus);
            this.Controls.Add(this.lblCurrentMode);
            this.Controls.Add(this.grpServer);
            this.Controls.Add(this.grpControlSource);
            this.Controls.Add(this.grpTrafficKind);
            this.Controls.Add(this.grpTiming);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Den Giao Thong - Ethernet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTrafficLight.ResumeLayout(false);
            this.panelTrafficLight.PerformLayout();
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            this.grpControlSource.ResumeLayout(false);
            this.grpControlSource.PerformLayout();
            this.grpTrafficKind.ResumeLayout(false);
            this.grpTiming.ResumeLayout(false);
            this.grpTiming.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button888_click;
        private Button button;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btn5_click;
    }
}
