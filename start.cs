using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrollCMD
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
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

        private void start_Load(object sender, EventArgs e)
        {
            bool startInTray = Properties.Settings.Default.startInTray;
            cb_startInTray.Checked = startInTray;
            if (startInTray)
            {
                EnterTray();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ni_trayIcon.Dispose();
            base.OnFormClosing(e);
        }

        private void cb_startInTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["startInTray"] = cb_startInTray.Checked;
            Properties.Settings.Default.Save();
        }

        private void ni_trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExitTray();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_tray_Click(object sender, EventArgs e)
        {
            EnterTray();
        }

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
    }
}
