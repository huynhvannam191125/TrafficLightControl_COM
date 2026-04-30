using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TrafficLightControl
{
    public partial class Form1 : Form
    {
        enum TrafficMode { Mode1_Red, Mode2_YellowBlink, Mode3_Time }
        enum LightState { Red, Yellow, Green }

        private TrafficMode currentMode = TrafficMode.Mode3_Time;
        private LightState currentLight = LightState.Red;
        private bool isGUI = false;
        private bool yellowBlink = false;
        private bool redOn = false, yellowOn = false, greenOn = false;

        private int tRed = 5, tYellow = 3, tGreen = 8;
        private int countdown = 0;
        private string serialBuffer = "";
        private bool? lastWasDaytime = null;

        private System.Windows.Forms.Timer blinkTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer();
        private System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort();

        // ══════════════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ══════════════════════════════════════════════════════════════
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            SetLightsGUI(false, false, false);
            SetTimeInputsEnabled(false);
            InitTimers();
            InitSerial();
        }

        private void Form1_Load(object? sender, EventArgs e) { }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            blinkTimer.Stop(); clockTimer.Stop();
            if (serialPort.IsOpen) serialPort.Close();
        }

        // ══════════════════════════════════════════════════════════════
        // TIMERS
        // ══════════════════════════════════════════════════════════════
        private void InitTimers()
        {
            clockTimer.Interval = 1000;
            clockTimer.Tick += (s, e) =>
            {
                var now = DateTime.Now;
                lblClock.Text = now.ToString("HH:mm:ss");
                lblDate.Text = now.ToString("dd/MM/yyyy");
                // Chi kiem tra gio khi GUI mode + Mode 3
                if (currentMode == TrafficMode.Mode3_Time && isGUI)
                    CheckTimeMode3(now);
            };
            clockTimer.Start();

            // blinkTimer CHI dung cho btnMode2 trong GUI mode
            // Khong dung cho ban dem - dong bo theo BLINK: tu PIC
            blinkTimer.Interval = 500;
            blinkTimer.Tick += (s, e) =>
            {
                yellowBlink = !yellowBlink;
                pictureBox2.Image = yellowBlink
                ? Properties.Resources.vang
                : Properties.Resources.den;

            };
        }

        // ══════════════════════════════════════════════════════════════
        // SERIAL
        // ══════════════════════════════════════════════════════════════
        private void InitSerial()
        {
            try
            {
                cmbPort.Items.Clear();
                foreach (string p in System.IO.Ports.SerialPort.GetPortNames())
                    cmbPort.Items.Add(p);
                if (cmbPort.Items.Count > 0) cmbPort.SelectedIndex = 0;

                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.Parity = System.IO.Ports.Parity.None;
                serialPort.StopBits = System.IO.Ports.StopBits.One;
                serialPort.DataReceived += SerialPort_DataReceived;
            }
            catch { }
        }

        private void SendChar(char c)
        {
            try { if (serialPort.IsOpen) serialPort.Write(new char[] { c }, 0, 1); }
            catch { }
        }

        // ══════════════════════════════════════════════════════════════
        // NHAN TU PIC
        //   "BLINK:1\n"       → Dong bo vang sang (tu Yellow_Blink PIC)
        //   "BLINK:0\n"       → Dong bo vang tat  (tu Yellow_Blink PIC)
        //   "AUTO: RED:N\n"   → Mode 3: Den do, N giay con lai
        //   "AUTO: YELLOW:N"  → Den vang, N giay con lai
        //   "AUTO: GREEN:N"   → Den xanh, N giay con lai
        //   "MANUAL: RED_ON"  → RB0 → Mode 1
        //   "MANUAL: YELLOW_BLINK" → RB1 → Mode 2
        //   "MANUAL: AUTO_MODE"    → RB2 → Mode 3
        //   "SYSTEM: GUI_MODE"     → PIC xac nhan GUI
        //   "SYSTEM: MANUAL_MODE"  → PIC xac nhan MANUAL
        // ══════════════════════════════════════════════════════════════
        private void SerialPort_DataReceived(object? sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                serialBuffer += serialPort.ReadExisting();
                while (serialBuffer.Contains("\n"))
                {
                    int idx = serialBuffer.IndexOf("\n");
                    string line = serialBuffer.Substring(0, idx).Trim();
                    serialBuffer = serialBuffer.Substring(idx + 1);
                    this.Invoke((Action)(() => ProcessPicMessage(line)));
                }
            }
            catch { }
        }

        private void ProcessPicMessage(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg)) return;

            // ── DONG BO NHAP NHAY TU PIC ─────────────────────────
            // PIC gui "BLINK:1" hoac "BLINK:0" tu Yellow_Blink()
            // GUI chi hien thi theo PIC, khong tu dem thoi gian
            if (msg.StartsWith("BLINK:"))
            {
                bool picYellowOn = msg.Contains("BLINK:1");
                pictureBox2.Image = picYellowOn
                ? Properties.Resources.vang
                : Properties.Resources.den;

                return;
            }

            // ── AUTO: PIC gui trang thai moi giay ───────────────
            if (msg.StartsWith("AUTO:") || msg.Contains("AUTO:"))
            {
                blinkTimer.Stop();

                // Parse mau den va so giay
                // Format: "AUTO: RED:5" hoac "AUTO: YELLOW:3" hoac "AUTO: GREEN:8"
                char color = ' ';
                int sec = 0;

                if (msg.Contains("RED:"))
                {
                    color = 'R';
                    string[] p = msg.Split(':');
                    if (p.Length >= 3) int.TryParse(p[p.Length - 1].Trim(), out sec);
                }
                else if (msg.Contains("YELLOW:"))
                {
                    color = 'Y';
                    string[] p = msg.Split(':');
                    if (p.Length >= 3) int.TryParse(p[p.Length - 1].Trim(), out sec);
                }
                else if (msg.Contains("GREEN:"))
                {
                    color = 'G';
                    string[] p = msg.Split(':');
                    if (p.Length >= 3) int.TryParse(p[p.Length - 1].Trim(), out sec);
                }
                else
                {
                    // "AUTO: RED" / "AUTO: YELLOW" / "AUTO: GREEN" (khong co so)
                    if (msg.Contains("GREEN")) color = 'G';
                    else if (msg.Contains("YELLOW")) color = 'Y';
                    else if (msg.Contains("RED")) color = 'R';
                }

                switch (color)
                {
                    case 'R':
                        if (currentLight != LightState.Red)
                        {
                            currentLight = LightState.Red;
                            SetLightsGUI(true, false, false);
                            UpdateModeLabel("MODE 3 – Đèn ĐỎ");
                        }
                        break;
                    case 'Y':
                        if (currentLight != LightState.Yellow)
                        {
                            currentLight = LightState.Yellow;
                            SetLightsGUI(false, true, false);
                            UpdateModeLabel("MODE 3 – Đèn VÀNG");
                        }
                        break;
                    case 'G':
                        if (currentLight != LightState.Green)
                        {
                            currentLight = LightState.Green;
                            SetLightsGUI(false, false, true);
                            UpdateModeLabel("MODE 3 – Đèn XANH");
                        }
                        break;
                }

                if (sec > 0)
                {
                    countdown = sec;
                    lblCountdown.Text = countdown.ToString();
                    lblCountdown.ForeColor = redOn ? Color.Red : yellowOn ? Color.Yellow : Color.Lime;

                }
                return;
            }

            // ── RB0 → Mode 1 ─────────────────────────────────────
            if (msg.Contains("RED_ON"))
            {
                if (isGUI) return;
                currentMode = TrafficMode.Mode1_Red;
                blinkTimer.Stop();
                SetLightsGUI(true, false, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 1 – Đỏ liên tục");
                HighlightBtn(btnMode1);
                return;
            }

            // ── RB1 → Mode 2 ─────────────────────────────────────
            if (msg.Contains("YELLOW_BLINK"))
            {
                if (isGUI) return;
                currentMode = TrafficMode.Mode2_YellowBlink;
                // KHONG dung blinkTimer - dong bo theo BLINK: tu PIC
                blinkTimer.Stop();
                SetLightsGUI(false, true, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 2 – Vàng nhấp nháy");
                HighlightBtn(btnMode2);
                return;
            }

            // ── RB2 → Mode 3 ─────────────────────────────────────
            if (msg.Contains("AUTO_MODE"))
            {
                if (isGUI) return;
                currentMode = TrafficMode.Mode3_Time;
                currentLight = LightState.Red;
                // KHONG dung blinkTimer - dong bo theo BLINK: tu PIC
                blinkTimer.Stop();
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                HighlightBtn(btnMode3);

                bool isNight = (DateTime.Now.Hour < 5 || DateTime.Now.Hour >= 22);
                if (isNight)
                {
                    // Ban dem: hien vang tren GUI, gui 'Y' ve PIC
                    // PIC se chay Yellow_Blink() va gui "BLINK:1/0" ve dong bo
                    SetLightsGUI(false, true, false);
                    UpdateModeLabel("MODE 3 – Ban đêm (Vàng nhấp nháy)");
                    lastWasDaytime = false;
                    SendChar('Y');
                }
                else
                {
                    // Ban ngay: gui 'A' ve PIC, cho PIC gui trang thai
                    SetLightsGUI(false, false, false);
                    UpdateModeLabel("MODE 3 – Chờ PIC...");
                    lastWasDaytime = true;
                    SendChar('A');
                }
                return;
            }

            // ── PIC xac nhan MANUAL ───────────────────────────────
            if (msg.Contains("MANUAL_MODE"))
            {
                isGUI = false; chkGUI.Checked = false;
                lblControlMode.Text = "Chế độ: MANUAL (Tại trụ)";
                lblControlMode.ForeColor = Color.Orange;
                btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = false;
                SetTimeInputsEnabled(false);
                return;
            }

            // ── PIC xac nhan GUI ─────────────────────────────────
            if (msg.Contains("GUI_MODE"))
            {
                isGUI = true; chkGUI.Checked = true;
                lblControlMode.Text = "Chế độ: GUI (Máy tính)";
                lblControlMode.ForeColor = Color.Cyan;
                btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = true;
                SetTimeInputsEnabled(true);
                return;
            }
        }

        // ══════════════════════════════════════════════════════════════
        // CAC MODE – tu nut bam GUI
        // ══════════════════════════════════════════════════════════════
        private void btnMode1_Click(object? sender, EventArgs e)
        {
            lastWasDaytime = null;
            currentMode = TrafficMode.Mode1_Red;
            blinkTimer.Stop();
            SetLightsGUI(true, false, false);
            lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            UpdateModeLabel("MODE 1 – Đỏ liên tục");
            HighlightBtn(btnMode1);
            SendChar('R');
        }


        private void btnMode2_Click(object? sender, EventArgs e)
        {
            lastWasDaytime = null;
            currentMode = TrafficMode.Mode2_YellowBlink;
            // GUI mode 2: dung blinkTimer vi khong co dong bo tu PIC
            yellowBlink = false;
            SetLightsGUI(false, true, false);
            lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            blinkTimer.Start();
            UpdateModeLabel("MODE 2 – Vàng nhấp nháy");
            HighlightBtn(btnMode2);
            SendChar('Y');
        }

        private void btnMode3_Click(object? sender, EventArgs e)
        {
            currentMode = TrafficMode.Mode3_Time;
            blinkTimer.Stop();
            SetLightsGUI(false, false, false);
            lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            UpdateModeLabel("MODE 3 – Đang đồng bộ...");
            HighlightBtn(btnMode3);
            lastWasDaytime = null;
            CheckTimeMode3(DateTime.Now);
        }

        // ══════════════════════════════════════════════════════════════
        // MODE 3 – THEO GIO (chi ap dung GUI mode)
        // ══════════════════════════════════════════════════════════════
        private void CheckTimeMode3(DateTime now)
        {
            bool isDaytime = (now.Hour >= 5 && now.Hour < 22);
            if (lastWasDaytime == isDaytime) return;
            lastWasDaytime = isDaytime;

            if (isDaytime)
            {
                // Ban ngay: gui 'A' ve PIC, PIC chay auto va gui trang thai ve
                blinkTimer.Stop();
                SetLightsGUI(false, false, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 3 – Đang đồng bộ...");
                SendChar('A');
            }
            else
            {
                // Ban dem: gui 'Y' ve PIC
                // PIC chay Yellow_Blink() va gui "BLINK:1/0" ve dong bo
                // KHONG dung blinkTimer GUI tranh lech pha
                blinkTimer.Stop();
                SetLightsGUI(false, true, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 3 – Ban đêm (Vàng nhấp nháy)");
                SendChar('Y');
            }
        }

        // ══════════════════════════════════════════════════════════════
        // HIGHLIGHT NUT MODE DANG ACTIVE
        // ══════════════════════════════════════════════════════════════
        private void HighlightBtn(Button active)
        {
            foreach (var b in new[] { btnMode1, btnMode2, btnMode3 })
                b.BackColor = (b == active) ? Color.FromArgb(0, 180, 120) : Color.FromArgb(50, 50, 65);
        }

        // ══════════════════════════════════════════════════════════════
        // CHECKBOX GUI / MANUAL
        // ══════════════════════════════════════════════════════════════
        private void chkGUI_CheckedChanged(object? sender, EventArgs e)
        {
            isGUI = chkGUI.Checked;
            lblControlMode.Text = isGUI ? "Chế độ: GUI (Máy tính)" : "Chế độ: MANUAL (Tại trụ)";
            lblControlMode.ForeColor = isGUI ? Color.Cyan : Color.Orange;
            btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = isGUI;
            SetTimeInputsEnabled(isGUI);

            if (isGUI)
            {
                SendChar('G');
            }
            else
            {
                blinkTimer.Stop();
                SetLightsGUI(false, false, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MANUAL – Điều khiển tại trụ");
                lastWasDaytime = null;
                SendChar('M');

                // Ban dem trong MANUAL: gui 'Y' ve PIC
                // PIC chay Yellow_Blink() va gui "BLINK:1/0" de dong bo
                // KHONG dung blinkTimer GUI
                if (DateTime.Now.Hour < 5 || DateTime.Now.Hour >= 22)
                {
                    SendChar('Y');
                    blinkTimer.Stop();
                    SetLightsGUI(false, true, false);
                    UpdateModeLabel("MANUAL – Ban đêm (Vàng nhấp nháy)");
                }
            }
        }

        // ══════════════════════════════════════════════════════════════
        // KET NOI SERIAL
        // ══════════════════════════════════════════════════════════════
        private void btnConnect_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.PortName = cmbPort.SelectedItem?.ToString() ?? "COM1";
                    serialPort.Open();
                    btnConnect.Text = "Ngắt kết nối";
                    lblStatus.Text = "✔ Đã kết nối " + serialPort.PortName;
                    lblStatus.ForeColor = Color.LimeGreen;
                    grpControlSource.Enabled = true;
                    if (isGUI) btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = true;
                    SendChar(isGUI ? 'G' : 'M');
                }
                else
                {
                    serialPort.Close();
                    blinkTimer.Stop();
                    btnConnect.Text = "Kết nối";
                    lblStatus.Text = "✖ Chưa kết nối";
                    lblStatus.ForeColor = Color.OrangeRed;
                    SetLightsGUI(false, false, false);
                    lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    UpdateModeLabel("Chờ kết nối...");
                    grpControlSource.Enabled = false;
                    btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = false;
                    SetTimeInputsEnabled(false);
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Lỗi Serial: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // ══════════════════════════════════════════════════════════════
        // CAI THOI GIAN DEN
        // ══════════════════════════════════════════════════════════════
        private void btnApplyTime_Click(object? sender, EventArgs e)
        {
            Color ok = Color.FromArgb(35, 35, 50), err = Color.FromArgb(80, 20, 20);
            bool valid = true; int r = 0, y = 0, g = 0;

            if (!int.TryParse(txtRed.Text, out r) || r < 1 || r > 9) { valid = false; txtRed.BackColor = err; } else txtRed.BackColor = ok;
            if (!int.TryParse(txtYellow.Text, out y) || y < 1 || y > 9) { valid = false; txtYellow.BackColor = err; } else txtYellow.BackColor = ok;
            if (!int.TryParse(txtGreen.Text, out g) || g < 1 || g > 9) { valid = false; txtGreen.BackColor = err; } else txtGreen.BackColor = ok;
            if (!valid) { MessageBox.Show("Thời gian phải từ 1 đến 9 giây!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            tRed = r; tYellow = y; tGreen = g;

            // Gui lenh T + 3 ky tu thoi gian
            SendChar('T');
            System.Threading.Thread.Sleep(50);
            SendChar((char)('0' + tRed));
            System.Threading.Thread.Sleep(50);
            SendChar((char)('0' + tYellow));
            System.Threading.Thread.Sleep(50);
            SendChar((char)('0' + tGreen));
            System.Threading.Thread.Sleep(200);

            // Neu dang Mode 3 ban ngay: reset ve auto
            if (currentMode == TrafficMode.Mode3_Time && isGUI)
            {
                if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 22)
                {
                    blinkTimer.Stop();
                    SetLightsGUI(false, false, false);
                    lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    UpdateModeLabel("MODE 3 – Đang đồng bộ...");
                    SendChar('A');
                }
            }

            MessageBox.Show($"Đã cập nhật: Đỏ={tRed}s  Vàng={tYellow}s  Xanh={tGreen}s",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTime_KeyPress(object? sender, KeyPressEventArgs e)
        { if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true; }

        private void txtTime_TextChanged(object? sender, EventArgs e)
        {
            if (sender is not TextBox txt) return;
            if (int.TryParse(txt.Text, out int v))
                txt.BackColor = (v >= 1 && v <= 9) ? Color.FromArgb(35, 35, 50) : Color.FromArgb(80, 20, 20);
        }

        // ══════════════════════════════════════════════════════════════
        // HELPERS
        // ══════════════════════════════════════════════════════════════
        private void SetTimeInputsEnabled(bool enabled)
        {
            txtRed.Enabled = txtYellow.Enabled = txtGreen.Enabled = btnApplyTime.Enabled = enabled;
            Color bg = enabled ? Color.FromArgb(35, 35, 50) : Color.FromArgb(25, 25, 35);
            txtRed.BackColor = txtYellow.BackColor = txtGreen.BackColor = bg;
        }

        private void SetLightsGUI(bool red, bool yellow, bool green)
        {
            redOn = red; yellowOn = yellow; greenOn = green;
            pictureBox1.Image = red ? Properties.Resources._do : Properties.Resources.den;
            pictureBox2.Image = yellow ? Properties.Resources.vang : Properties.Resources.den;
            pictureBox3.Image = green ? Properties.Resources.xanh : Properties.Resources.den;


        }

        private void UpdateModeLabel(string text)
        { lblCurrentMode.Text = text; lblCurrentMode.ForeColor = Color.Lime; }

        private void panelTrafficLight_Paint(object? sender, PaintEventArgs e)
        {

        }

        private void panelLight_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel p) return;
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            int d = Math.Min(p.Width, p.Height) - 12, x = (p.Width - d) / 2, y = (p.Height - d) / 2;
            var rect = new Rectangle(x, y, d, d);
            using (var br = new SolidBrush(p.BackColor)) g.FillEllipse(br, rect);
            using (var pen = new Pen(Color.FromArgb(90, 90, 90), 2)) g.DrawEllipse(pen, rect);
        }

    }

    // ══════════════════════════════════════════════════════════════
    // EXTENSION
    // ══════════════════════════════════════════════════════════════
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush b, Rectangle r, int radius)
        { using (var path = BuildPath(r, radius)) g.FillPath(b, path); }
        public static void DrawRoundedRectangle(this Graphics g, Pen p, Rectangle r, int radius)
        { using (var path = BuildPath(r, radius)) g.DrawPath(p, path); }
        private static GraphicsPath BuildPath(Rectangle r, int radius)
        {
            int d = radius * 2; var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure(); return path;
        }
    }
}