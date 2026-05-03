using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HidSharp;

namespace USB_TrafficLightControl
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
        private bool? lastWasDaytime = null;
        private bool? lastWasNight = null;

        private const int USB_VID = 0x04D8;
        private const int USB_PID_HW = 0x0033;
        private const int USB_PID_SIM = 0x0001;

        private HidDevice hidDevice = null;
        private HidStream hidStream = null;
        private Thread readThread = null;
        private volatile bool running = false;

        private System.Windows.Forms.Timer blinkTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer pollTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            InitTimers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pollTimer.Interval = 500;
            pollTimer.Tick += PollTimer_Tick;
            pollTimer.Start();
        }

        // ???????????????????????????????????????????????????????
        // POLL
        // ???????????????????????????????????????????????????????
        private void PollTimer_Tick(object sender, EventArgs e)
        {
            var allDevices = DeviceList.Local.GetHidDevices().ToList();
            var matched = allDevices.Where(d =>
                d.VendorID == USB_VID &&
                (d.ProductID == USB_PID_HW || d.ProductID == USB_PID_SIM)
            ).ToList();

            if (matched.Any() && hidStream == null)
            {
                lblStatus.Text = "Tìm thấy thiết bị – đang kết nối...";
                lblStatus.ForeColor = Color.Yellow;
                ConnectDevice();
            }
            else if (!matched.Any() && hidStream != null)
            {
                DisconnectDevice();
            }
         
        }

        private void ConnectDevice()
        {
            try
            {
                var devices = DeviceList.Local.GetHidDevices()
                    .Where(d => d.VendorID == USB_VID &&
                               (d.ProductID == USB_PID_HW || d.ProductID == USB_PID_SIM))
                    .ToList();

                if (!devices.Any()) return;

                foreach (var dev in devices)
                {
                    try
                    {
                        HidStream s;
                        if (dev.TryOpen(out s))
                        {
                            hidDevice = dev;
                            hidStream = s;
                            hidStream.ReadTimeout = Timeout.Infinite;
                            hidStream.WriteTimeout = 2000;

                            running = true;
                            readThread = new Thread(ReadLoop) { IsBackground = true };
                            readThread.Start();

                            string pidStr = dev.ProductID == USB_PID_HW ? "0033 (Phần cứng)" : "0001 (Proteus)";
                            lblStatus.Text = "Đã kết nối  VID:04D8";
                            lblStatus.ForeColor = Color.LimeGreen;
                            chkGUI.Enabled = true;
                            UpdateModeLabel("Đã kết nối – chọn chế độ điều khiển");
                            lastWasNight = null;
                            SendByte((byte)(isGUI ? 'G' : 'M'));
                            return;
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void DisconnectDevice()
        {
            running = false;
            try { hidStream?.Close(); } catch { }
            hidStream = null;
            hidDevice = null;
            readThread = null;

            if (InvokeRequired) { Invoke(new Action(DisconnectUI)); return; }
            DisconnectUI();
        }

        private void DisconnectUI()
        {
            blinkTimer.Stop();
            lblStatus.Text = "Chưa kết nối thiết bị";
            lblStatus.ForeColor = Color.OrangeRed;
            chkGUI.Enabled = false;
            btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = false;
            SetTimeInputsEnabled(false);
            SetLightsGUI(false, false, false);
            lblCountdown.Text = "--";
            lblCountdown.ForeColor = Color.Gray;
            UpdateModeLabel("Chưa kết nối thiết bị...");
        }

        // ???????????????????????????????????????????????????????
        // READ LOOP
        // ???????????????????????????????????????????????????????
        private void ReadLoop()
        {
            byte[] buf = new byte[hidDevice.GetMaxInputReportLength()];
            while (running)
            {
                try
                {
                    int len = hidStream.Read(buf, 0, buf.Length);
                    if (len > 0)
                    {
                        byte[] data = buf.Take(len).ToArray();
                        if (IsHandleCreated)
                            Invoke(new Action<byte[]>(ProcessUsbData), data);
                    }
                }
                catch { break; }
            }
            DisconnectDevice();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            pollTimer.Stop(); blinkTimer.Stop(); clockTimer.Stop();
            running = false;
            try { hidStream?.Close(); } catch { }
        }

        // ???????????????????????????????????????????????????????
        // G?I D? LI?U
        // ???????????????????????????????????????????????????????
        private void SendByte(byte b)
        {
            try
            {
                if (hidStream == null || hidDevice == null) return;
                int outLen = hidDevice.GetMaxOutputReportLength();
                byte[] buf = new byte[outLen];
                buf[0] = 0x00;
                buf[1] = b;
                hidStream.Write(buf, 0, outLen);
            }
            catch { }
        }

        private void SendBytes(byte[] payload)
        {
            try
            {
                if (hidStream == null || hidDevice == null) return;
                int outLen = hidDevice.GetMaxOutputReportLength();
                byte[] buf = new byte[outLen];
                buf[0] = 0x00;
                for (int i = 0; i < payload.Length && i + 1 < outLen; i++)
                    buf[i + 1] = payload[i];
                hidStream.Write(buf, 0, outLen);
            }
            catch { }
        }

        // ???????????????????????????????????????????????????????
        // NH?N D? LI?U
        // ???????????????????????????????????????????????????????
        private void ProcessUsbData(byte[] data)
        {
            if (data.Length < 2) return;
            char cmd = (char)data[1];

            switch (cmd)
            {
                case 'D': // AUTO sync
                    if (data.Length < 4) return;
                    char color = (char)data[2]; int sec = data[3];
                    blinkTimer.Stop();
                    if (color == 'R' && currentLight != LightState.Red)
                    { currentLight = LightState.Red; SetLightsGUI(true, false, false); UpdateModeLabel("MODE 3 – Đèn ĐỎ"); }
                    else if (color == 'Y' && currentLight != LightState.Yellow)
                    { currentLight = LightState.Yellow; SetLightsGUI(false, true, false); UpdateModeLabel("MODE 3 – Đèn VÀNG"); }
                    else if (color == 'G' && currentLight != LightState.Green)
                    { currentLight = LightState.Green; SetLightsGUI(false, false, true); UpdateModeLabel("MODE 3 – Đèn XANH"); }
                    countdown = sec; lblCountdown.Text = countdown.ToString();
                    lblCountdown.ForeColor = redOn ? Color.Red : yellowOn ? Color.Yellow : Color.Lime;
                    break;

                case 'B': // Đồng bộ vàng nhấp nháy: data[2]=yellow_state
                    if (data.Length < 3) return;
                    panelYellow.BackColor = (data[2] == 1) ? Color.Yellow : Color.FromArgb(60, 60, 0);
                    panelYellow.Invalidate();
                    break;


                case 'R': // PIC báo nút ? ?? (MANUAL)
                    if (isGUI) return;
                    currentMode = TrafficMode.Mode1_Red; blinkTimer.Stop();
                    SetLightsGUI(true, false, false); lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    UpdateModeLabel("MODE 1 – Đỏ liên tục"); HighlightBtn(btnMode1); break;

                case 'Y': // PIC báo nút b?m ? vàng nh?p nháy (MANUAL)
                    if (isGUI) return;
                    currentMode = TrafficMode.Mode2_YellowBlink; yellowBlink = false;
                    blinkTimer.Stop(); SetLightsGUI(false, true, false);
                    lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    UpdateModeLabel("MODE 2 – Vàng nhấp nháy"); HighlightBtn(btnMode2); break;

                case 'A': // PIC báo nút ? AUTO (MANUAL)
                    if (isGUI) return;
                    currentMode = TrafficMode.Mode3_Time; currentLight = LightState.Red;
                    blinkTimer.Stop(); SetLightsGUI(false, false, false);
                    lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    HighlightBtn(btnMode3);
                    if (DateTime.Now.Hour < 5 || DateTime.Now.Hour >= 22)
                    {
                        // Ban ?êm: hi?n vàng trên GUI, g?i 'Y' xu?ng PIC
                        // PIC ch?y Yellow_Blink ? g?i 'B' v? ? GUI ??ng b? qua case 'B'
                        // KHÔNG dùng blinkTimer GUI ?? tránh l?ch pha
                        blinkTimer.Stop();
                        SetLightsGUI(false, true, false);
                        UpdateModeLabel("MODE 3 – Ban đêm (Vàng nhấp nháy)");
                        lastWasDaytime = false;
                        Thread.Sleep(50);
                        SendByte((byte)'Y');
                    }
                    else
                    {
                        UpdateModeLabel("MODE 3 – Ch? PIC...");
                        lastWasDaytime = true;
                    }
                    break;

                case 'G': // PIC xác nhận GUI mode
                    isGUI = true; chkGUI.Checked = true;
                    lblControlMode.Text = "Chế độ: GUI "; lblControlMode.ForeColor = Color.Cyan;
                    btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = true; SetTimeInputsEnabled(true); break;

                case 'M': // PIC xác nhận MANUAL mode
                    isGUI = false; chkGUI.Checked = false;
                    lblControlMode.Text = "Chế độ: MANUAL "; lblControlMode.ForeColor = Color.Orange;
                    btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = false; SetTimeInputsEnabled(false); break;

                case 'S': // PIC xác nhận thời gian
                    if (data.Length >= 5)
                        UpdateModeLabel($"Đã set: Đỏ={data[2]}s  Vàng={data[3]}s  Xanh={data[4]}s"); break;
            }
        }

        // ???????????????????????????????????????????????????????
        // CÁC MODE
        // ???????????????????????????????????????????????????????
        private void btnMode1_Click(object sender, EventArgs e)
        {
            lastWasDaytime = null; currentMode = TrafficMode.Mode1_Red; blinkTimer.Stop();
            SetLightsGUI(true, false, false); lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            UpdateModeLabel("MODE 1 – đỏ liên tục"); HighlightBtn(btnMode1); SendByte((byte)'R');
        }

        private void btnMode2_Click(object sender, EventArgs e)
        {
            lastWasDaytime = null; currentMode = TrafficMode.Mode2_YellowBlink; yellowBlink = false;
            blinkTimer.Stop(); SetLightsGUI(false, true, false);
            lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            UpdateModeLabel("MODE 2 – Vàng nhấp nháy"); HighlightBtn(btnMode2); SendByte((byte)'Y');
        }

        private void btnMode3_Click(object sender, EventArgs e)
        {
            currentMode = TrafficMode.Mode3_Time; blinkTimer.Stop();
            SetLightsGUI(false, false, false); lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            HighlightBtn(btnMode3);
            lastWasDaytime = null;
            CheckTimeMode3(DateTime.Now);
        }

        private void CheckTimeMode3(DateTime now)
        {
            bool isDaytime = (now.Hour >= 5 && now.Hour < 22);
            if (lastWasDaytime == isDaytime) return;
            lastWasDaytime = isDaytime;

            if (isDaytime)
            {
                // Ban ngày: g?i 'A' xu?ng PIC, PIC g?i 'D' v? ?? ??ng b? ?èn
                blinkTimer.Stop();
                SetLightsGUI(false, false, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 3 – ?ang ??ng b?...");
                SendByte((byte)'A');
            }
            else
            {
                // Ban ?êm: g?i 'Y' xu?ng PIC, PIC g?i 'B' v? ?? ??ng b? nh?p nháy
                // KHÔNG dùng blinkTimer GUI – tránh l?ch pha v?i PIC
                blinkTimer.Stop();
                SetLightsGUI(false, true, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 3 – Ban đêm (Vàng nhấp nháy)");
                Thread.Sleep(50);
                SendByte((byte)'Y');
            }
        }

        private void HighlightBtn(Button active)
        {
            foreach (var b in new[] { btnMode1, btnMode2, btnMode3 })
                b.BackColor = (b == active) ? Color.FromArgb(0, 180, 120) : Color.FromArgb(50, 50, 65);
        }

        private void chkGUI_CheckedChanged(object sender, EventArgs e)
        {
            isGUI = chkGUI.Checked;
            lblControlMode.Text = isGUI ? "Chế độ: GUI " : "Chế độ: MANUAL ";
            lblControlMode.ForeColor = isGUI ? Color.Cyan : Color.Orange;
            btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = isGUI;
            SetTimeInputsEnabled(isGUI);
            if (isGUI) { SendByte((byte)'G'); }
            else
            {
                blinkTimer.Stop(); SetLightsGUI(false, false, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MANUAL – ?i?u khi?n t?i tr?"); SendByte((byte)'M');
                lastWasNight = null;
                if (DateTime.Now.Hour < 5 || DateTime.Now.Hour >= 22)
                {
                    // Ban ?êm: g?i 'Y' xu?ng PIC, PIC g?i 'B' v? ?? ??ng b?
                    // KHÔNG dùng blinkTimer GUI
                    Thread.Sleep(100); SendByte((byte)'Y');
                    blinkTimer.Stop();
                    SetLightsGUI(false, true, false);
                    UpdateModeLabel("MANUAL – Ban ?êm (Vàng nh?p nháy)");
                }
            }
        }

        private void btnApplyTime_Click(object sender, EventArgs e)
        {
            Color ok = Color.FromArgb(35, 35, 50), err = Color.FromArgb(80, 20, 20);
            bool valid = true; int r = 0, y = 0, g = 0;
            if (!int.TryParse(txtRed.Text, out r) || r < 1 || r > 9) { valid = false; txtRed.BackColor = err; } else txtRed.BackColor = ok;
            if (!int.TryParse(txtYellow.Text, out y) || y < 1 || y > 9) { valid = false; txtYellow.BackColor = err; } else txtYellow.BackColor = ok;
            if (!int.TryParse(txtGreen.Text, out g) || g < 1 || g > 9) { valid = false; txtGreen.BackColor = err; } else txtGreen.BackColor = ok;
            if (!valid) { MessageBox.Show("Th?i gian ph?i t? 1 ??n 9 giây!", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            tRed = r; tYellow = y; tGreen = g;
            SendBytes(new byte[] { (byte)'T', (byte)tRed, (byte)tYellow, (byte)tGreen });
            if (currentMode == TrafficMode.Mode3_Time && isGUI)
            {
                if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 22)
                {
                    blinkTimer.Stop(); SetLightsGUI(false, false, false);
                    lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    UpdateModeLabel("MODE 3 – ?ang ??ng b?...");
                    Thread.Sleep(100); SendByte((byte)'A');
                }
            }
            MessageBox.Show($"?ã c?p nh?t: ??={tRed}s  Vàng={tYellow}s  Xanh={tGreen}s",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        { if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true; }

        private void txtTime_TextChanged(object sender, EventArgs e)
        { var txt = (TextBox)sender; if (int.TryParse(txt.Text, out int v)) txt.BackColor = (v >= 1 && v <= 9) ? Color.FromArgb(35, 35, 50) : Color.FromArgb(80, 20, 20); }

        // ???????????????????????????????????????????????????????
        // TIMERS
        // ???????????????????????????????????????????????????????
        private void InitTimers()
        {
            clockTimer.Interval = 1000;
            clockTimer.Tick += (s, e) => {
                var now = DateTime.Now;
                lblClock.Text = now.ToString("HH:mm:ss");
                lblDate.Text = now.ToString("dd/MM/yyyy");

                bool isNight = (now.Hour < 5 || now.Hour >= 22);

                // Mode 3: t? chuy?n theo gi? (c? GUI l?n MANUAL)
                if (currentMode == TrafficMode.Mode3_Time)
                {
                    CheckTimeMode3(now);
                    return;
                }

                // MANUAL mode (không ph?i Mode 3): t? ??ng vàng ban ?êm
                if (!isGUI && hidStream != null)
                {
                    if (lastWasNight == isNight) return;
                    lastWasNight = isNight;

                    if (isNight)
                    {
                        // G?i 'Y' xu?ng PIC, PIC g?i 'B' v? ??ng b?
                        // KHÔNG dùng blinkTimer GUI
                        blinkTimer.Stop();
                        SetLightsGUI(false, true, false);
                        UpdateModeLabel("MANUAL – Ban đêm (Vàng nhấp nháy)");
                        SendByte((byte)'Y');
                    }
                    else
                    {
                        blinkTimer.Stop();
                        SetLightsGUI(false, false, false);
                        lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                        UpdateModeLabel("MANUAL – Ban ngày (chờ nút bấm)");
                        SendByte((byte)'A');
                    }
                }
            };
            clockTimer.Start();

            // blinkTimer CH? dùng cho Mode 2 (không dùng cho ban ?êm Mode 3)
            blinkTimer.Interval = 500;
            blinkTimer.Tick += (s, e) => {
                yellowBlink = !yellowBlink;
                panelYellow.BackColor = yellowBlink ? Color.Yellow : Color.FromArgb(60, 60, 0);
                panelYellow.Invalidate();
            };
        }

        // ???????????????????????????????????????????????????????
        // HELPERS
        // ???????????????????????????????????????????????????????
        private void SetTimeInputsEnabled(bool en)
        {
            txtRed.Enabled = txtYellow.Enabled = txtGreen.Enabled = btnApplyTime.Enabled = en;
            Color bg = en ? Color.FromArgb(35, 35, 50) : Color.FromArgb(25, 25, 35);
            txtRed.BackColor = txtYellow.BackColor = txtGreen.BackColor = bg;
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblCurrentMode_Click(object sender, EventArgs e)
        {

        }

        private void SetLightsGUI(bool red, bool yellow, bool green)
        {
            redOn = red; yellowOn = yellow; greenOn = green;
            panelRed.BackColor = red ? Color.Red : Color.FromArgb(60, 0, 0);
            panelYellow.BackColor = yellow ? Color.Yellow : Color.FromArgb(60, 60, 0);
            panelGreen.BackColor = green ? Color.Lime : Color.FromArgb(0, 60, 0);
            panelRed.Invalidate(); panelYellow.Invalidate(); panelGreen.Invalidate();
        }

        private void UpdateModeLabel(string text)
        { lblCurrentMode.Text = text; lblCurrentMode.ForeColor = Color.Lime; }

        private void panelTrafficLight_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(5, 5, panelTrafficLight.Width - 10, panelTrafficLight.Height - 10);
            using (var br = new SolidBrush(Color.FromArgb(25, 25, 35))) g.FillRoundedRectangle(br, r, 18);
            using (var pen = new Pen(Color.FromArgb(80, 80, 100), 2)) g.DrawRoundedRectangle(pen, r, 18);
        }

        private void panelLight_Paint(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender; var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
            int d = Math.Min(p.Width, p.Height) - 12, x = (p.Width - d) / 2, y = (p.Height - d) / 2;
            var rect = new Rectangle(x, y, d, d);
            using (var br = new SolidBrush(p.BackColor)) g.FillEllipse(br, rect);
            using (var pen = new Pen(Color.FromArgb(90, 90, 90), 2)) g.DrawEllipse(pen, rect);
        }
    }

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
