using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ethernet_TrafficLight
{
    public partial class Form1 : Form
    {
        enum TrafficMode { Mode1_Red, Mode2_YellowBlink, Mode3_Time }
        enum LightState  { Red, Yellow, Green }

        private TrafficMode currentMode  = TrafficMode.Mode3_Time;
        private LightState  currentLight = LightState.Red;
        private bool isGUI        = false;
        private bool yellowBlink  = false;
        private bool redOn = false, yellowOn = false, greenOn = false;

        private int    tRed = 5, tYellow = 3, tGreen = 8;
        private int    countdown      = 0;
        private string recvBuffer     = "";
        private bool   lastWasDaytimeSet = false;
        private bool   lastWasDaytime    = false;

        // TCP Server
        private TcpListener  tcpServer    = null;
        private TcpClient    picClient    = null;
        private NetworkStream netStream   = null;
        private Thread        listenThread = null;
        private Thread        readThread   = null;
        private volatile bool serverRunning = false;

        // Timers
        private System.Windows.Forms.Timer blinkTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer();

        // ════════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ════════════════════════════════════════════════════════
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            SetLightsGUI(false, false, false);
            SetTimeInputsEnabled(false);
            InitTimers();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();
            blinkTimer.Stop();
            clockTimer.Stop();
        }

        // ════════════════════════════════════════════════════════
        // TIMERS
        // ════════════════════════════════════════════════════════
        private void InitTimers()
        {
            clockTimer.Interval = 1000;
            clockTimer.Tick += new EventHandler(ClockTimer_Tick);
            clockTimer.Start();

            blinkTimer.Interval = 500;
            blinkTimer.Tick += new EventHandler(BlinkTimer_Tick);
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            lblClock.Text = now.ToString("HH:mm:ss");
            lblDate.Text  = now.ToString("dd/MM/yyyy");
            if (currentMode == TrafficMode.Mode3_Time && isGUI)
                CheckTimeMode3(now);
        }

        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            yellowBlink = !yellowBlink;
            panelYellow.BackColor = yellowBlink ? Color.Yellow : Color.FromArgb(60, 60, 0);
            panelYellow.Invalidate();
        }

        // ════════════════════════════════════════════════════════
        // TCP SERVER
        // ════════════════════════════════════════════════════════
        private void StartServer(string ip, int port)
        {
            try
            {
                IPAddress localIP = IPAddress.Parse(ip);
                tcpServer     = new TcpListener(localIP, port);
                serverRunning = true;
                tcpServer.Start();

                lblStatus.Text      = "Server dang chay " + ip + ":" + port + " - Cho PIC ket noi...";
                lblStatus.ForeColor = Color.Yellow;

                listenThread = new Thread(new ThreadStart(ListenLoop));
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khoi dong server:\n" + ex.Message, "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopServer()
        {
            serverRunning = false;
            try { if (netStream  != null) netStream.Close();  } catch { }
            try { if (picClient  != null) picClient.Close();  } catch { }
            try { if (tcpServer  != null) tcpServer.Stop();   } catch { }
            netStream = null; picClient = null; tcpServer = null;
        }

        private void ListenLoop()
        {
            while (serverRunning)
            {
                try
                {
                    picClient = tcpServer.AcceptTcpClient();
                    netStream = picClient.GetStream();

                    string picAddr = ((IPEndPoint)picClient.Client.RemoteEndPoint).Address.ToString();

                    if (IsHandleCreated)
                        Invoke(new Action(delegate
                        {
                            lblStatus.Text      = " da ket noi tu " + picAddr;
                            lblStatus.ForeColor = Color.LimeGreen;
                            grpControlSource.Enabled = true;
                            SendChar(isGUI ? 'G' : 'M');
                        }));

                    readThread = new Thread(new ThreadStart(ReadLoop));
                    readThread.IsBackground = true;
                    readThread.Start();
                    readThread.Join();

                    if (IsHandleCreated)
                        Invoke(new Action(delegate
                        {
                            lblStatus.Text      = " ngat ket noi - Cho ket noi lai...";
                            lblStatus.ForeColor = Color.Yellow;
                            grpControlSource.Enabled     = false;
                            btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = false;
                            SetTimeInputsEnabled(false);
                            SetLightsGUI(false, false, false);
                            lblCountdown.Text      = "--";
                            lblCountdown.ForeColor = Color.Gray;
                            UpdateModeLabel(" ngat ket noi...");
                            blinkTimer.Stop();
                        }));
                }
                catch { if (!serverRunning) break; }
            }
        }

        private void ReadLoop()
        {
            byte[] buf = new byte[256];
            while (serverRunning && netStream != null)
            {
                try
                {
                    int len = netStream.Read(buf, 0, buf.Length);
                    if (len <= 0) break;

                    string data = Encoding.ASCII.GetString(buf, 0, len);
                    recvBuffer += data;

                    while (recvBuffer.Contains("\n"))
                    {
                        int    idx  = recvBuffer.IndexOf("\n");
                        string line = recvBuffer.Substring(0, idx).Trim();
                        recvBuffer  = recvBuffer.Substring(idx + 1);
                        if (!string.IsNullOrEmpty(line) && IsHandleCreated)
                        {
                            string captured = line;
                            Invoke(new Action(delegate { ProcessPicMessage(captured); }));
                        }
                    }
                }
                catch { break; }
            }
        }

        private void SendChar(char c)
        {
            try
            {
                if (netStream == null || !netStream.CanWrite) return;
                netStream.Write(new byte[] { (byte)c }, 0, 1);
            }
            catch { }
        }

        private void SendBytes(byte[] payload)
        {
            try
            {
                if (netStream == null || !netStream.CanWrite) return;
                netStream.Write(payload, 0, payload.Length);
            }
            catch { }
        }

        // ════════════════════════════════════════════════════════
        // XU LY TIN NHAN TU PIC
        // ════════════════════════════════════════════════════════
        private void ProcessPicMessage(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;

            // DONG BO NHAP NHAY TU PIC
            if (msg.StartsWith("BLINK:"))
            {
                bool on = msg.Contains("BLINK:1");
                panelYellow.BackColor = on ? Color.Yellow : Color.FromArgb(60, 60, 0);
                panelYellow.Invalidate();
                return;
            }

            // AUTO: PIC gui trang thai
            if (msg.Contains("AUTO:"))
            {
                blinkTimer.Stop();
                char color = ' ';
                int  sec   = 0;

                if      (msg.Contains("RED:"))    color = 'R';
                else if (msg.Contains("YELLOW:")) color = 'Y';
                else if (msg.Contains("GREEN:"))  color = 'G';
                else if (msg.Contains("RED"))     color = 'R';
                else if (msg.Contains("YELLOW"))  color = 'Y';
                else if (msg.Contains("GREEN"))   color = 'G';

                int colonIdx = msg.LastIndexOf(':');
                if (colonIdx >= 0 && colonIdx < msg.Length - 1)
                    int.TryParse(msg.Substring(colonIdx + 1).Trim(), out sec);

                if (color == 'R' && currentLight != LightState.Red)
                { currentLight = LightState.Red; SetLightsGUI(true, false, false); UpdateModeLabel("MODE 3 - Den DO"); }
                else if (color == 'Y' && currentLight != LightState.Yellow)
                { currentLight = LightState.Yellow; SetLightsGUI(false, true, false); UpdateModeLabel("MODE 3 - Den VANG"); }
                else if (color == 'G' && currentLight != LightState.Green)
                { currentLight = LightState.Green; SetLightsGUI(false, false, true); UpdateModeLabel("MODE 3 - Den XANH"); }

                if (sec > 0)
                {
                    countdown              = sec;
                    lblCountdown.Text      = countdown.ToString();
                    lblCountdown.ForeColor = redOn ? Color.Red : yellowOn ? Color.Yellow : Color.Lime;
                }
                return;
            }

            // RB0 Mode 1
            if (msg.Contains("RED_ON"))
            {
                if (isGUI) return;
                currentMode = TrafficMode.Mode1_Red;
                blinkTimer.Stop();
                SetLightsGUI(true, false, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 1 - Do lien tuc");
                HighlightBtn(btnMode1);
                return;
            }

            // RB1 Mode 2
            if (msg.Contains("YELLOW_BLINK"))
            {
                if (isGUI) return;
                currentMode = TrafficMode.Mode2_YellowBlink;
                blinkTimer.Stop();
                SetLightsGUI(false, true, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 2 - Vang nhap nhay");
                HighlightBtn(btnMode2);
                return;
            }

            // RB2 Mode 3
            if (msg.Contains("AUTO_MODE"))
            {
                if (isGUI) return;
                currentMode  = TrafficMode.Mode3_Time;
                currentLight = LightState.Red;
                blinkTimer.Stop();
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                HighlightBtn(btnMode3);

                bool isNight = (DateTime.Now.Hour < 5 || DateTime.Now.Hour >= 22);
                if (isNight)
                {
                    SetLightsGUI(false, true, false);
                    UpdateModeLabel("MODE 3 - Ban dem (Vang nhap nhay)");
                    lastWasDaytimeSet = true;
                    lastWasDaytime    = false;
                    SendChar('Y');
                }
                else
                {
                    SetLightsGUI(false, false, false);
                    UpdateModeLabel("MODE 3 - Cho PIC...");
                    lastWasDaytimeSet = true;
                    lastWasDaytime    = true;
                    SendChar('A');
                }
                return;
            }

            // PIC xac nhan MANUAL
            if (msg.Contains("MANUAL_MODE"))
            {
                isGUI = false; chkGUI.Checked = false;
                lblControlMode.Text      = "Che do: MANUAL (Tai tru)";
                lblControlMode.ForeColor = Color.Orange;
                btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = false;
                SetTimeInputsEnabled(false);
                return;
            }

            // PIC xac nhan GUI
            if (msg.Contains("GUI_MODE"))
            {
                isGUI = true; chkGUI.Checked = true;
                lblControlMode.Text      = "Che do: GUI (May tinh)";
                lblControlMode.ForeColor = Color.Cyan;
                btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = true;
                SetTimeInputsEnabled(true);
                return;
            }
        }

        // ════════════════════════════════════════════════════════
        // CAC MODE TU NUT BAM GUI
        // ════════════════════════════════════════════════════════
        private void btnMode1_Click(object sender, EventArgs e)
        {
            lastWasDaytimeSet = false;
            currentMode = TrafficMode.Mode1_Red;
            blinkTimer.Stop();
            SetLightsGUI(true, false, false);
            lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            UpdateModeLabel("MODE 1 - Do lien tuc");
            HighlightBtn(btnMode1);
            SendChar('R');
        }

        private void btnMode2_Click(object sender, EventArgs e)
        {
            lastWasDaytimeSet = false;
            currentMode = TrafficMode.Mode2_YellowBlink;
            yellowBlink = false;
            SetLightsGUI(false, true, false);
            lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            blinkTimer.Start();
            UpdateModeLabel("MODE 2 - Vang nhap nhay");
            HighlightBtn(btnMode2);
            SendChar('Y');
        }

        private void btnMode3_Click(object sender, EventArgs e)
        {
            currentMode = TrafficMode.Mode3_Time;
            blinkTimer.Stop();
            SetLightsGUI(false, false, false);
            lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
            UpdateModeLabel("MODE 3 - Dang dong bo...");
            HighlightBtn(btnMode3);
            lastWasDaytimeSet = false;
            CheckTimeMode3(DateTime.Now);
        }

        private void CheckTimeMode3(DateTime now)
        {
            bool isDaytime = (now.Hour >= 5 && now.Hour < 22);
            if (lastWasDaytimeSet && lastWasDaytime == isDaytime) return;
            lastWasDaytimeSet = true;
            lastWasDaytime    = isDaytime;

            if (isDaytime)
            {
                blinkTimer.Stop();
                SetLightsGUI(false, false, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 3 - Dang dong bo...");
                SendChar('A');
            }
            else
            {
                blinkTimer.Stop();
                SetLightsGUI(false, true, false);
                lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("MODE 3 - Ban dem (Vang nhap nhay)");
                SendChar('Y');
            }
        }

        private void HighlightBtn(Button active)
        {
            Button[] btns = new Button[] { btnMode1, btnMode2, btnMode3 };
            foreach (Button b in btns)
                b.BackColor = (b == active) ? Color.FromArgb(0, 180, 120) : Color.FromArgb(50, 50, 65);
        }

        // ════════════════════════════════════════════════════════
        // CHECKBOX GUI / MANUAL
        // ════════════════════════════════════════════════════════
        private void chkGUI_CheckedChanged(object sender, EventArgs e)
        {
            isGUI = chkGUI.Checked;
            lblControlMode.Text      = isGUI ? "Che do: GUI (May tinh)" : "Che do: MANUAL (Tai tru)";
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
                UpdateModeLabel("MANUAL - Dieu khien tai tru");
                lastWasDaytimeSet = false;
                SendChar('M');

                if (DateTime.Now.Hour < 5 || DateTime.Now.Hour >= 22)
                {
                    SendChar('Y');
                    blinkTimer.Stop();
                    SetLightsGUI(false, true, false);
                    UpdateModeLabel("MANUAL - Ban dem (Vang nhap nhay)");
                }
            }
        }

        // ════════════════════════════════════════════════════════
        // KHOI DONG / DUNG SERVER
        // ════════════════════════════════════════════════════════
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!serverRunning)
            {
                string ip      = txtServerIP.Text.Trim();
                string portStr = txtServerPort.Text.Trim();
                IPAddress dummy;

                if (!IPAddress.TryParse(ip, out dummy))
                { MessageBox.Show("IP khong hop le!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                int port;
                if (!int.TryParse(portStr, out port) || port < 1 || port > 65535)
                { MessageBox.Show("Port khong hop le (1-65535)!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                StartServer(ip, port);
                btnStartServer.Text      = "Dung Server";
                btnStartServer.BackColor = Color.Firebrick;
            }
            else
            {
                StopServer();
                serverRunning            = false;
                btnStartServer.Text      = "Khoi dong Server";
                btnStartServer.BackColor = Color.MediumSeaGreen;
                lblStatus.Text           = "X Server da dung";
                lblStatus.ForeColor      = Color.OrangeRed;
                grpControlSource.Enabled = false;
                btnMode1.Enabled = btnMode2.Enabled = btnMode3.Enabled = false;
                SetTimeInputsEnabled(false);
                SetLightsGUI(false, false, false);
                blinkTimer.Stop();
                lblCountdown.Text      = "--";
                lblCountdown.ForeColor = Color.Gray;
                UpdateModeLabel("Cho ket noi...");
            }
        }

        // ════════════════════════════════════════════════════════
        // CAI THOI GIAN DEN
        // ════════════════════════════════════════════════════════
        private void btnApplyTime_Click(object sender, EventArgs e)
        {
            Color ok  = Color.FromArgb(35, 35, 50);
            Color err = Color.FromArgb(80, 20, 20);
            bool valid = true;
            int r = 0, y = 0, g = 0;

            if (!int.TryParse(txtRed.Text,    out r) || r < 1 || r > 9) { valid = false; txtRed.BackColor    = err; } else txtRed.BackColor    = ok;
            if (!int.TryParse(txtYellow.Text, out y) || y < 1 || y > 9) { valid = false; txtYellow.BackColor = err; } else txtYellow.BackColor = ok;
            if (!int.TryParse(txtGreen.Text,  out g) || g < 1 || g > 9) { valid = false; txtGreen.BackColor  = err; } else txtGreen.BackColor  = ok;
            if (!valid) { MessageBox.Show("Thoi gian phai tu 1 den 9 giay!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            tRed = r; tYellow = y; tGreen = g;

            SendBytes(new byte[] { (byte)'T', (byte)('0' + tRed), (byte)('0' + tYellow), (byte)('0' + tGreen) });
            Thread.Sleep(200);

            if (currentMode == TrafficMode.Mode3_Time && isGUI)
                if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 22)
                {
                    blinkTimer.Stop();
                    SetLightsGUI(false, false, false);
                    lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    UpdateModeLabel("MODE 3 - Dang dong bo...");
                    SendChar('A');
                }

            MessageBox.Show("Da cap nhat: Do=" + tRed + "s  Vang=" + tYellow + "s  Xanh=" + tGreen + "s",
                "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        { if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true; }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            int v;
            if (int.TryParse(txt.Text, out v))
                txt.BackColor = (v >= 1 && v <= 9) ? Color.FromArgb(35, 35, 50) : Color.FromArgb(80, 20, 20);
        }

        // ════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════
        private void SetTimeInputsEnabled(bool en)
        {
            txtRed.Enabled = txtYellow.Enabled = txtGreen.Enabled = btnApplyTime.Enabled = en;
            Color bg = en ? Color.FromArgb(35, 35, 50) : Color.FromArgb(25, 25, 35);
            txtRed.BackColor = txtYellow.BackColor = txtGreen.BackColor = bg;
        }

        private void grpServer_Enter(object sender, EventArgs e)
        {

        }

        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblCountdown_Click(object sender, EventArgs e)
        {

        }

        private void lblClock_Click(object sender, EventArgs e)
        {

        }

        private void button888_click_Click(object sender, EventArgs e)
        {
            Color ok = Color.FromArgb(35, 35, 50);
            Color err = Color.FromArgb(80, 20, 20);
            bool valid = true;
            int r = 0, y = 0, g = 0;

            if (!int.TryParse(txtRed.Text, out r) || r < 1 || r > 9) { valid = false; txtRed.BackColor = err; } else txtRed.BackColor = ok;
            if (!int.TryParse(txtYellow.Text, out y) || y < 1 || y > 9) { valid = false; txtYellow.BackColor = err; } else txtYellow.BackColor = ok;
            if (!int.TryParse(txtGreen.Text, out g) || g < 1 || g > 9) { valid = false; txtGreen.BackColor = err; } else txtGreen.BackColor = ok;
            if (!valid) { MessageBox.Show("Thoi gian phai tu 1 den 9 giay!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            tRed = r; tYellow = y; tGreen = g;

            SendBytes(new byte[] { (byte)'T', (byte)('0' + tRed), (byte)('0' + tYellow), (byte)('0' + tGreen) });
            Thread.Sleep(200);

            if (currentMode == TrafficMode.Mode3_Time && isGUI)
                if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 22)
                {
                    blinkTimer.Stop();
                    SetLightsGUI(false, false, false);
                    lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    UpdateModeLabel("MODE 3 - Dang dong bo...");
                    SendChar('A');
                }

            MessageBox.Show("Da cap nhat: Do=" + tRed + "s  Vang=" + tYellow + "s  Xanh=" + tGreen + "s",
                "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button777_click_Click(object sender, EventArgs e)
        {
            Color ok = Color.FromArgb(35, 35, 50);
            Color err = Color.FromArgb(80, 20, 20);
            bool valid = true;
            int r = 0, y = 0, g = 0;

            if (!int.TryParse(txtRed.Text, out r) || r < 1 || r > 9) { valid = false; txtRed.BackColor = err; } else txtRed.BackColor = ok;
            if (!int.TryParse(txtYellow.Text, out y) || y < 1 || y > 9) { valid = false; txtYellow.BackColor = err; } else txtYellow.BackColor = ok;
            if (!int.TryParse(txtGreen.Text, out g) || g < 1 || g > 9) { valid = false; txtGreen.BackColor = err; } else txtGreen.BackColor = ok;
            if (!valid) { MessageBox.Show("Thoi gian phai tu 1 den 9 giay!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            tRed = r; tYellow = y; tGreen = g;

            SendBytes(new byte[] { (byte)'T', (byte)('0' + tRed), (byte)('0' + tYellow), (byte)('0' + tGreen) });
            Thread.Sleep(200);

            if (currentMode == TrafficMode.Mode3_Time && isGUI)
                if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 22)
                {
                    blinkTimer.Stop();
                    SetLightsGUI(false, false, false);
                    lblCountdown.Text = "--"; lblCountdown.ForeColor = Color.Gray;
                    UpdateModeLabel("MODE 3 - Dang dong bo...");
                    SendChar('A');
                }

            MessageBox.Show("Da cap nhat: Do=" + tRed + "s  Vang=" + tYellow + "s  Xanh=" + tGreen + "s",
                "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetLightsGUI(bool red, bool yellow, bool green)
        {
            redOn = red; yellowOn = yellow; greenOn = green;
            panelRed.BackColor    = red    ? Color.Red    : Color.FromArgb(60, 0, 0);
            panelYellow.BackColor = yellow ? Color.Yellow : Color.FromArgb(60, 60, 0);
            panelGreen.BackColor  = green  ? Color.Lime   : Color.FromArgb(0, 60, 0);
            panelRed.Invalidate(); panelYellow.Invalidate(); panelGreen.Invalidate();
        }

        private void UpdateModeLabel(string text)
        { lblCurrentMode.Text = text; lblCurrentMode.ForeColor = Color.Lime; }

        private void panelTrafficLight_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle r = new Rectangle(5, 5, panelTrafficLight.Width - 10, panelTrafficLight.Height - 10);
            using (SolidBrush br  = new SolidBrush(Color.FromArgb(25, 25, 35))) g.FillRoundedRectangle(br, r, 18);
            using (Pen        pen = new Pen(Color.FromArgb(80, 80, 100), 2))    g.DrawRoundedRectangle(pen, r, 18);
        }

        private void panelLight_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int d = Math.Min(p.Width, p.Height) - 12, x = (p.Width - d) / 2, y = (p.Height - d) / 2;
            Rectangle rect = new Rectangle(x, y, d, d);
            using (SolidBrush br  = new SolidBrush(p.BackColor))            g.FillEllipse(br, rect);
            using (Pen        pen = new Pen(Color.FromArgb(90, 90, 90), 2)) g.DrawEllipse(pen, rect);
        }
    }

    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush b, Rectangle r, int radius)
        { using (GraphicsPath path = BuildPath(r, radius)) g.FillPath(b, path); }
        public static void DrawRoundedRectangle(this Graphics g, Pen p, Rectangle r, int radius)
        { using (GraphicsPath path = BuildPath(r, radius)) g.DrawPath(p, path); }
        private static GraphicsPath BuildPath(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
