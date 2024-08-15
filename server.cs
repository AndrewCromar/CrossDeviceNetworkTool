using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace TrollCMD
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
        }

        SimpleTcpServer tcp_server;
        private void server_Load(object sender, EventArgs e)
        {
            tcp_server = new SimpleTcpServer();
            tcp_server.Delimiter = 0x13;
            tcp_server.StringEncoder = Encoding.UTF8;
            tcp_server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txt_output.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
            {
                txt_output.Text += "\nReceived: " + e.MessageString;
                string result = TryCommand(e.MessageString);
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
        }

        private void TryCommand()
        {

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            txt_output.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txt_host.Text);
            tcp_server.Start(ip, Convert.ToInt32(txt_port.Text));
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            if (tcp_server.IsStarted)
            {
                tcp_server.Stop();
            }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            StopServer();
            start new_start = new start();
            new_start.Show();
            new_start.ExitTray();
            this.Hide();
        }
    }
}
