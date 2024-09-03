using Microsoft.Win32;

namespace Tool
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        public bool notFirstLoad = false;

        private void start_Load(object sender, EventArgs e)
        {
            bool startInTray = Properties.Settings.Default.startInTray;
            bool bootServerOnStart = Properties.Settings.Default.bootServerOnStart;

            cb_startInTray.Checked = startInTray;
            cb_startWithWindows.Checked = Properties.Settings.Default.startWithWindows;
            cb_bootServerOnStart.Checked = bootServerOnStart;

            if (notFirstLoad) return;

            if (bootServerOnStart && startInTray)
            {
                server new_server = new server();
                new_server.Show();
                new_server.StartServer();
                new_server.EnterTray();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Hide();
            }
            else if (bootServerOnStart && !startInTray)
            {
                server new_server = new server();
                new_server.Show();
                new_server.StartServer();
                this.ShowInTaskbar = false;
                this.Hide();
            }
            else if (!bootServerOnStart && startInTray)
            {
                EnterTray();
            }
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            server new_server = new server();
            new_server.Show();
            this.Hide();
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            client new_client = new client();
            new_client.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ni_trayIcon.Dispose();
            base.OnFormClosing(e);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_tray_Click(object sender, EventArgs e)
        {
            EnterTray();
        }

        #region Tray
        private void EnterTray()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            ni_trayIcon.Visible = true;
        }

        public void ExitTray()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            ni_trayIcon.Visible = false;
        }

        private void ni_trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExitTray();
        }
        #endregion

        private void cb_startInTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["startInTray"] = cb_startInTray.Checked;
            Properties.Settings.Default.Save();
        }

        private void cb_startWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["startWithWindows"] = cb_startWithWindows.Checked;
            Properties.Settings.Default.Save();

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            string appName = "TrollCMD - AndrewCromar";
            string appPath = Application.ExecutablePath;

            if (cb_startWithWindows.Checked)
            {
                // Add the application to the startup registry
                registryKey.SetValue(appName, "\"" + appPath + "\"");
            }
            else
            {
                // Remove the application from the startup registry
                registryKey.DeleteValue(appName, false);
            }
        }

        private void cb_bootServerOnStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["bootServerOnStart"] = cb_bootServerOnStart.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
