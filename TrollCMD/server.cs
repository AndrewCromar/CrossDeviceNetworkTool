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
                txt_output.Text += "\nReceived: " + e.MessageString + "\n > Attempting to run command...";
                string result = TryCommand(e.MessageString);
                txt_output.Text += "\n > " + result;
                e.ReplyLine(result);
            });
        }

        private string TryCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return "Error running command: No command found.";
            }

            int spaceIndex = command.IndexOf(' ');

            command = command.Substring(0, command.Length - 1);

            string commandName;
            string arguments = "";

            if (spaceIndex == -1)
            {
                commandName = command;
            }
            else
            {
                commandName = command.Substring(0, spaceIndex);
                arguments = command.Substring(spaceIndex + 1);
            }

            if (commandName == "msg")
            {
                new Thread(() => MessageBox.Show(arguments)).Start();

                return "Success: Message box shown.";
            }

            return "Error running command: No reson given.";
        }


        private void btn_start_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        public void StartServer()
        {
            txt_output.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txt_host.Text);
            tcp_server.Start(ip, Convert.ToInt32(txt_port.Text));
            txt_output.Text += "\n > Server started.";
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
