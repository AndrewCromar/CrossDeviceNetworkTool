using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrollCMD
{
    public partial class client : Form
    {
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
            txt_output.Text += "\n Sending command: \"" + txt_input.Text + "\"\n > Waiting for responce...";
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
    }
}
