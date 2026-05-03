namespace USB_TrafficLightControl
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTrafficLight = new System.Windows.Forms.Panel();
            this.panelRed = new System.Windows.Forms.Panel();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.panelGreen = new System.Windows.Forms.Panel();
            this.lblRedText = new System.Windows.Forms.Label();
            this.lblYellowText = new System.Windows.Forms.Label();
            this.lblGreenText = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSectionClock = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSectionCount = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.lblCountdownUnit = new System.Windows.Forms.Label();
            this.lblSectionStatus = new System.Windows.Forms.Label();
            this.lblCurrentMode = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSectionControl = new System.Windows.Forms.Label();
            this.chkGUI = new System.Windows.Forms.CheckBox();
            this.lblControlMode = new System.Windows.Forms.Label();
            this.lblSectionMode = new System.Windows.Forms.Label();
            this.btnMode1 = new System.Windows.Forms.Button();
            this.btnMode2 = new System.Windows.Forms.Button();
            this.btnMode3 = new System.Windows.Forms.Button();
            this.lblSectionTime = new System.Windows.Forms.Label();
            this.lblRedCaption = new System.Windows.Forms.Label();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.lblRedUnit = new System.Windows.Forms.Label();
            this.lblYellowCaption = new System.Windows.Forms.Label();
            this.txtYellow = new System.Windows.Forms.TextBox();
            this.lblYellowUnit = new System.Windows.Forms.Label();
            this.lblGreenCaption = new System.Windows.Forms.Label();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.lblGreenUnit = new System.Windows.Forms.Label();
            this.btnApplyTime = new System.Windows.Forms.Button();
            this.panelTrafficLight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTrafficLight
            // 
            this.panelTrafficLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.panelTrafficLight.Controls.Add(this.panelRed);
            this.panelTrafficLight.Controls.Add(this.panelYellow);
            this.panelTrafficLight.Controls.Add(this.panelGreen);
            this.panelTrafficLight.Controls.Add(this.lblRedText);
            this.panelTrafficLight.Controls.Add(this.lblYellowText);
            this.panelTrafficLight.Controls.Add(this.lblGreenText);
            this.panelTrafficLight.Location = new System.Drawing.Point(15, 55);
            this.panelTrafficLight.Name = "panelTrafficLight";
            this.panelTrafficLight.Size = new System.Drawing.Size(150, 478);
            this.panelTrafficLight.TabIndex = 0;
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
            this.panelYellow.Location = new System.Drawing.Point(25, 176);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(100, 120);
            this.panelYellow.TabIndex = 1;
            this.panelYellow.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLight_Paint);
            // 
            // panelGreen
            // 
            this.panelGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.panelGreen.Location = new System.Drawing.Point(25, 321);
            this.panelGreen.Name = "panelGreen";
            this.panelGreen.Size = new System.Drawing.Size(100, 120);
            this.panelGreen.TabIndex = 2;
            this.panelGreen.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLight_Paint);
            // 
            // lblRedText
            // 
            this.lblRedText.AutoSize = true;
            this.lblRedText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRedText.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblRedText.Location = new System.Drawing.Point(43, 153);
            this.lblRedText.Name = "lblRedText";
            this.lblRedText.Size = new System.Drawing.Size(31, 20);
            this.lblRedText.TabIndex = 3;
            this.lblRedText.Text = "ĐỎ";
            // 
            // lblYellowText
            // 
            this.lblYellowText.AutoSize = true;
            this.lblYellowText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYellowText.ForeColor = System.Drawing.Color.Gold;
            this.lblYellowText.Location = new System.Drawing.Point(35, 298);
            this.lblYellowText.Name = "lblYellowText";
            this.lblYellowText.Size = new System.Drawing.Size(52, 20);
            this.lblYellowText.TabIndex = 4;
            this.lblYellowText.Text = "VÀNG";
            // 
            // lblGreenText
            // 
            this.lblGreenText.AutoSize = true;
            this.lblGreenText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGreenText.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblGreenText.Location = new System.Drawing.Point(34, 449);
            this.lblGreenText.Name = "lblGreenText";
            this.lblGreenText.Size = new System.Drawing.Size(53, 20);
            this.lblGreenText.TabIndex = 5;
            this.lblGreenText.Text = "XANH";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Olive;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Lime;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(610, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "🚦  HỆ THỐNG ĐIỀU KHIỂN ĐÈN GIAO THÔNG – USB HID";
            // 
            // lblSectionClock
            // 
            this.lblSectionClock.AutoSize = true;
            this.lblSectionClock.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionClock.ForeColor = System.Drawing.Color.Lime;
            this.lblSectionClock.Location = new System.Drawing.Point(185, 55);
            this.lblSectionClock.Name = "lblSectionClock";
            this.lblSectionClock.Size = new System.Drawing.Size(110, 20);
            this.lblSectionClock.TabIndex = 10;
            this.lblSectionClock.Text = "🕐  ĐỒNG HỒ";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.BackColor = System.Drawing.Color.Olive;
            this.lblClock.Font = new System.Drawing.Font("Consolas", 26F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.Lime;
            this.lblClock.Location = new System.Drawing.Point(185, 75);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(214, 51);
            this.lblClock.TabIndex = 11;
            this.lblClock.Text = "00:00:00";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.LightGray;
            this.lblDate.Location = new System.Drawing.Point(190, 126);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(94, 21);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "01/01/2025";
            // 
            // lblSectionCount
            // 
            this.lblSectionCount.AutoSize = true;
            this.lblSectionCount.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.lblSectionCount.Location = new System.Drawing.Point(185, 150);
            this.lblSectionCount.Name = "lblSectionCount";
            this.lblSectionCount.Size = new System.Drawing.Size(132, 20);
            this.lblSectionCount.TabIndex = 13;
            this.lblSectionCount.Text = "🔢  ĐẾM NGƯỢC";
            // 
            // lblCountdown
            // 
            this.lblCountdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.lblCountdown.Font = new System.Drawing.Font("Consolas", 52F, System.Drawing.FontStyle.Bold);
            this.lblCountdown.ForeColor = System.Drawing.Color.Gray;
            this.lblCountdown.Location = new System.Drawing.Point(195, 170);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(120, 95);
            this.lblCountdown.TabIndex = 14;
            this.lblCountdown.Text = "--";
            this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountdownUnit
            // 
            this.lblCountdownUnit.AutoSize = true;
            this.lblCountdownUnit.ForeColor = System.Drawing.Color.LightGray;
            this.lblCountdownUnit.Location = new System.Drawing.Point(207, 270);
            this.lblCountdownUnit.Name = "lblCountdownUnit";
            this.lblCountdownUnit.Size = new System.Drawing.Size(88, 21);
            this.lblCountdownUnit.TabIndex = 15;
            this.lblCountdownUnit.Text = "giây còn lại";
            // 
            // lblSectionStatus
            // 
            this.lblSectionStatus.AutoSize = true;
            this.lblSectionStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.lblSectionStatus.Location = new System.Drawing.Point(185, 300);
            this.lblSectionStatus.Name = "lblSectionStatus";
            this.lblSectionStatus.Size = new System.Drawing.Size(132, 20);
            this.lblSectionStatus.TabIndex = 16;
            this.lblSectionStatus.Text = "📡  TRẠNG THÁI";
            // 
            // lblCurrentMode
            // 
            this.lblCurrentMode.AutoSize = true;
            this.lblCurrentMode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentMode.ForeColor = System.Drawing.Color.LightGray;
            this.lblCurrentMode.Location = new System.Drawing.Point(185, 320);
            this.lblCurrentMode.Name = "lblCurrentMode";
            this.lblCurrentMode.Size = new System.Drawing.Size(203, 25);
            this.lblCurrentMode.TabIndex = 17;
            this.lblCurrentMode.Text = "Chờ kết nối Proteus...";
            this.lblCurrentMode.Click += new System.EventHandler(this.lblCurrentMode_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location = new System.Drawing.Point(185, 355);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(123, 20);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "✖ Chưa kết nối";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // lblSectionControl
            // 
            this.lblSectionControl.AutoSize = true;
            this.lblSectionControl.BackColor = System.Drawing.Color.Olive;
            this.lblSectionControl.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionControl.ForeColor = System.Drawing.Color.Lime;
            this.lblSectionControl.Location = new System.Drawing.Point(415, 55);
            this.lblSectionControl.Name = "lblSectionControl";
            this.lblSectionControl.Size = new System.Drawing.Size(182, 20);
            this.lblSectionControl.TabIndex = 30;
            this.lblSectionControl.Text = "🎛  CHẾ ĐỘ ĐIỀU KHIỂN";
            // 
            // chkGUI
            // 
            this.chkGUI.AutoSize = true;
            this.chkGUI.Enabled = false;
            this.chkGUI.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkGUI.ForeColor = System.Drawing.Color.White;
            this.chkGUI.Location = new System.Drawing.Point(415, 78);
            this.chkGUI.Name = "chkGUI";
            this.chkGUI.Size = new System.Drawing.Size(230, 27);
            this.chkGUI.TabIndex = 31;
            this.chkGUI.Text = "Bật chế độ GUI (Máy tính)";
            this.chkGUI.UseVisualStyleBackColor = true;
            this.chkGUI.CheckedChanged += new System.EventHandler(this.chkGUI_CheckedChanged);
            // 
            // lblControlMode
            // 
            this.lblControlMode.AutoSize = true;
            this.lblControlMode.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblControlMode.ForeColor = System.Drawing.Color.Orange;
            this.lblControlMode.Location = new System.Drawing.Point(415, 104);
            this.lblControlMode.Name = "lblControlMode";
            this.lblControlMode.Size = new System.Drawing.Size(175, 20);
            this.lblControlMode.TabIndex = 32;
            this.lblControlMode.Text = "Chế độ: MANUAL (Tại trụ)";
            // 
            // lblSectionMode
            // 
            this.lblSectionMode.AutoSize = true;
            this.lblSectionMode.BackColor = System.Drawing.Color.Olive;
            this.lblSectionMode.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionMode.ForeColor = System.Drawing.Color.Lime;
            this.lblSectionMode.Location = new System.Drawing.Point(415, 130);
            this.lblSectionMode.Name = "lblSectionMode";
            this.lblSectionMode.Size = new System.Drawing.Size(274, 20);
            this.lblSectionMode.TabIndex = 33;
            this.lblSectionMode.Text = "🔘  CHỌN MODE  (cần bật GUI trước)";
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
            this.btnMode1.Location = new System.Drawing.Point(415, 155);
            this.btnMode1.Name = "btnMode1";
            this.btnMode1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMode1.Size = new System.Drawing.Size(390, 48);
            this.btnMode1.TabIndex = 34;
            this.btnMode1.Text = "1   MODE 1 – Đèn ĐỎ liên tục";
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
            this.btnMode2.Location = new System.Drawing.Point(415, 210);
            this.btnMode2.Name = "btnMode2";
            this.btnMode2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMode2.Size = new System.Drawing.Size(390, 48);
            this.btnMode2.TabIndex = 35;
            this.btnMode2.Text = "2   MODE 2 – Vàng nhấp nháy";
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
            this.btnMode3.Location = new System.Drawing.Point(415, 265);
            this.btnMode3.Name = "btnMode3";
            this.btnMode3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMode3.Size = new System.Drawing.Size(390, 48);
            this.btnMode3.TabIndex = 36;
            this.btnMode3.Text = "3   MODE 3 – Theo giờ (5h–22h AUTO)";
            this.btnMode3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMode3.UseVisualStyleBackColor = false;
            this.btnMode3.Click += new System.EventHandler(this.btnMode3_Click);
            // 
            // lblSectionTime
            // 
            this.lblSectionTime.AutoSize = true;
            this.lblSectionTime.BackColor = System.Drawing.Color.Olive;
            this.lblSectionTime.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionTime.ForeColor = System.Drawing.Color.Lime;
            this.lblSectionTime.Location = new System.Drawing.Point(415, 348);
            this.lblSectionTime.Name = "lblSectionTime";
            this.lblSectionTime.Size = new System.Drawing.Size(274, 20);
            this.lblSectionTime.TabIndex = 40;
            this.lblSectionTime.Text = "⏱  THỜI GIAN ĐÈN AUTO (1–9 giây)";
            // 
            // lblRedCaption
            // 
            this.lblRedCaption.AutoSize = true;
            this.lblRedCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRedCaption.ForeColor = System.Drawing.Color.LightGray;
            this.lblRedCaption.Location = new System.Drawing.Point(415, 376);
            this.lblRedCaption.Name = "lblRedCaption";
            this.lblRedCaption.Size = new System.Drawing.Size(71, 21);
            this.lblRedCaption.TabIndex = 41;
            this.lblRedCaption.Text = "🔴  Đỏ  :";
            // 
            // txtRed
            // 
            this.txtRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRed.Enabled = false;
            this.txtRed.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.txtRed.ForeColor = System.Drawing.Color.White;
            this.txtRed.Location = new System.Drawing.Point(495, 373);
            this.txtRed.MaxLength = 1;
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(48, 33);
            this.txtRed.TabIndex = 42;
            this.txtRed.Text = "5";
            this.txtRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRed.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            this.txtRed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // lblRedUnit
            // 
            this.lblRedUnit.AutoSize = true;
            this.lblRedUnit.ForeColor = System.Drawing.Color.LightGray;
            this.lblRedUnit.Location = new System.Drawing.Point(551, 376);
            this.lblRedUnit.Name = "lblRedUnit";
            this.lblRedUnit.Size = new System.Drawing.Size(39, 21);
            this.lblRedUnit.TabIndex = 43;
            this.lblRedUnit.Text = "giây";
            // 
            // lblYellowCaption
            // 
            this.lblYellowCaption.AutoSize = true;
            this.lblYellowCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblYellowCaption.ForeColor = System.Drawing.Color.LightGray;
            this.lblYellowCaption.Location = new System.Drawing.Point(415, 413);
            this.lblYellowCaption.Name = "lblYellowCaption";
            this.lblYellowCaption.Size = new System.Drawing.Size(78, 21);
            this.lblYellowCaption.TabIndex = 44;
            this.lblYellowCaption.Text = "🟡  Vàng:";
            // 
            // txtYellow
            // 
            this.txtYellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtYellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYellow.Enabled = false;
            this.txtYellow.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.txtYellow.ForeColor = System.Drawing.Color.White;
            this.txtYellow.Location = new System.Drawing.Point(495, 410);
            this.txtYellow.MaxLength = 1;
            this.txtYellow.Name = "txtYellow";
            this.txtYellow.Size = new System.Drawing.Size(48, 33);
            this.txtYellow.TabIndex = 45;
            this.txtYellow.Text = "3";
            this.txtYellow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYellow.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            this.txtYellow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // lblYellowUnit
            // 
            this.lblYellowUnit.AutoSize = true;
            this.lblYellowUnit.ForeColor = System.Drawing.Color.LightGray;
            this.lblYellowUnit.Location = new System.Drawing.Point(551, 413);
            this.lblYellowUnit.Name = "lblYellowUnit";
            this.lblYellowUnit.Size = new System.Drawing.Size(39, 21);
            this.lblYellowUnit.TabIndex = 46;
            this.lblYellowUnit.Text = "giây";
            // 
            // lblGreenCaption
            // 
            this.lblGreenCaption.AutoSize = true;
            this.lblGreenCaption.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGreenCaption.ForeColor = System.Drawing.Color.LightGray;
            this.lblGreenCaption.Location = new System.Drawing.Point(415, 450);
            this.lblGreenCaption.Name = "lblGreenCaption";
            this.lblGreenCaption.Size = new System.Drawing.Size(78, 21);
            this.lblGreenCaption.TabIndex = 47;
            this.lblGreenCaption.Text = "🟢  Xanh:";
            // 
            // txtGreen
            // 
            this.txtGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.txtGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGreen.Enabled = false;
            this.txtGreen.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold);
            this.txtGreen.ForeColor = System.Drawing.Color.White;
            this.txtGreen.Location = new System.Drawing.Point(495, 447);
            this.txtGreen.MaxLength = 1;
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(48, 33);
            this.txtGreen.TabIndex = 48;
            this.txtGreen.Text = "8";
            this.txtGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGreen.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            this.txtGreen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // lblGreenUnit
            // 
            this.lblGreenUnit.AutoSize = true;
            this.lblGreenUnit.ForeColor = System.Drawing.Color.LightGray;
            this.lblGreenUnit.Location = new System.Drawing.Point(551, 450);
            this.lblGreenUnit.Name = "lblGreenUnit";
            this.lblGreenUnit.Size = new System.Drawing.Size(39, 21);
            this.lblGreenUnit.TabIndex = 49;
            this.lblGreenUnit.Text = "giây";
            // 
            // btnApplyTime
            // 
            this.btnApplyTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(100)))));
            this.btnApplyTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyTime.Enabled = false;
            this.btnApplyTime.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.btnApplyTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyTime.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnApplyTime.ForeColor = System.Drawing.Color.White;
            this.btnApplyTime.Location = new System.Drawing.Point(670, 490);
            this.btnApplyTime.Name = "btnApplyTime";
            this.btnApplyTime.Size = new System.Drawing.Size(135, 34);
            this.btnApplyTime.TabIndex = 50;
            this.btnApplyTime.Text = "✔  Áp Dụng";
            this.btnApplyTime.UseVisualStyleBackColor = false;
            this.btnApplyTime.Click += new System.EventHandler(this.btnApplyTime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(820, 560);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelTrafficLight);
            this.Controls.Add(this.lblSectionClock);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSectionCount);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.lblCountdownUnit);
            this.Controls.Add(this.lblSectionStatus);
            this.Controls.Add(this.lblCurrentMode);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSectionControl);
            this.Controls.Add(this.chkGUI);
            this.Controls.Add(this.lblControlMode);
            this.Controls.Add(this.lblSectionMode);
            this.Controls.Add(this.btnMode1);
            this.Controls.Add(this.btnMode2);
            this.Controls.Add(this.btnMode3);
            this.Controls.Add(this.lblSectionTime);
            this.Controls.Add(this.lblRedCaption);
            this.Controls.Add(this.txtRed);
            this.Controls.Add(this.lblRedUnit);
            this.Controls.Add(this.lblYellowCaption);
            this.Controls.Add(this.txtYellow);
            this.Controls.Add(this.lblYellowUnit);
            this.Controls.Add(this.lblGreenCaption);
            this.Controls.Add(this.txtGreen);
            this.Controls.Add(this.lblGreenUnit);
            this.Controls.Add(this.btnApplyTime);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều Khiển Đèn Giao Thông – USB HID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTrafficLight.ResumeLayout(false);
            this.panelTrafficLight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel    panelTrafficLight;
        private System.Windows.Forms.Panel    panelRed;
        private System.Windows.Forms.Panel    panelYellow;
        private System.Windows.Forms.Panel    panelGreen;
        private System.Windows.Forms.Label    lblRedText;
        private System.Windows.Forms.Label    lblYellowText;
        private System.Windows.Forms.Label    lblGreenText;
        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Label    lblSectionClock;
        private System.Windows.Forms.Label    lblClock;
        private System.Windows.Forms.Label    lblDate;
        private System.Windows.Forms.Label    lblSectionCount;
        private System.Windows.Forms.Label    lblCountdown;
        private System.Windows.Forms.Label    lblCountdownUnit;
        private System.Windows.Forms.Label    lblSectionStatus;
        private System.Windows.Forms.Label    lblCurrentMode;
        private System.Windows.Forms.Label    lblStatus;
        private System.Windows.Forms.Label    lblSectionControl;
        private System.Windows.Forms.CheckBox chkGUI;
        private System.Windows.Forms.Label    lblControlMode;
        private System.Windows.Forms.Label    lblSectionMode;
        private System.Windows.Forms.Button   btnMode1;
        private System.Windows.Forms.Button   btnMode2;
        private System.Windows.Forms.Button   btnMode3;
        private System.Windows.Forms.Label    lblSectionTime;
        private System.Windows.Forms.Label    lblRedCaption;
        private System.Windows.Forms.TextBox  txtRed;
        private System.Windows.Forms.Label    lblRedUnit;
        private System.Windows.Forms.Label    lblYellowCaption;
        private System.Windows.Forms.TextBox  txtYellow;
        private System.Windows.Forms.Label    lblYellowUnit;
        private System.Windows.Forms.Label    lblGreenCaption;
        private System.Windows.Forms.TextBox  txtGreen;
        private System.Windows.Forms.Label    lblGreenUnit;
        private System.Windows.Forms.Button   btnApplyTime;
    }
}
