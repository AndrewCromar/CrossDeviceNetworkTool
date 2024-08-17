using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrollCMD
{
    public partial class client : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 0x0115;
        private const int SB_BOTTOM = 7;

        public client()
        {
            InitializeComponent();
        }

        SimpleTcpClient tcp_client;

        private void client_Load(object sender, EventArgs e)
        {
            txt_host.Text = Properties.Settings.Default.cromarDesktopIp;

            tcp_client = new SimpleTcpClient();
            tcp_client.StringEncoder = Encoding.UTF8;
            tcp_client.DataReceived += Client_DataReceived;

            UpdateSoundEffectBox();
        }

        private void UpdateSoundEffectBox()
        {
            cb_soundeffects.Items.Clear();

            string directoryPath = @"sounds/";

            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    cb_soundeffects.Items.Add(Path.GetFileName(file));
                }
            }
            else
            {
                MessageBox.Show("Directory does not exist.");
            }
        }

        private void Client_DataReceived(object? sender, SimpleTCP.Message e)
        {
            txt_output.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
            {
                txt_output.Text += "\n > Responce: \"" + e.MessageString + "\"";
            });
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            btn_connect.Enabled = false;
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txt_host.Text);
            tcp_client.Connect(txt_host.Text, Convert.ToInt32(txt_port.Text));
        }

        private void btx_send_Click(object sender, EventArgs e)
        {
            txt_output.Text += "\n\n Sending command: \"" + txt_input.Text + "\"\n > Waiting for responce...";
            tcp_client.WriteLineAndGetReply(txt_input.Text, TimeSpan.FromMilliseconds(100));
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            tcp_client.Disconnect();
            start new_start = new start();
            new_start.Show();
            new_start.ExitTray();
            this.Hide();
        }

        private void btn_andrewDesktopIp_Click(object sender, EventArgs e)
        {
            txt_host.Text = Properties.Settings.Default.andrewDesktopIp;
        }

        private void btn_cromarDesktopIp_Click(object sender, EventArgs e)
        {
            txt_host.Text = Properties.Settings.Default.cromarDesktopIp;
        }

        private void t_outputScroller_Tick(object sender, EventArgs e)
        {
            SendMessage(txt_output.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
        }

        private void btn_clearOutput_Click(object sender, EventArgs e)
        {
            txt_output.Clear();
        }

        private void btn_shutdownServer_Click(object sender, EventArgs e)
        {
            txt_input.Text = "server shutdown";
        }

        private void cb_soundeffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_input.Text = "sfx " + cb_soundeffects.Items[cb_soundeffects.SelectedIndex].ToString();
        }

        private void cb_links_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_input.Text = "web " + cb_links.Items[cb_links.SelectedIndex].ToString();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
