using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrossDeviceNetworkTool.Models;
using CrossDeviceNetworkTool.Networking;

namespace CrossDeviceNetworkTool
{
    public partial class client : Form
    {
        private ClientNetwork _clientNet;
        private string _lastConnectedIp = "";

        public client()
        {
            InitializeComponent();
            _clientNet = new ClientNetwork();
            _clientNet.OnLog += (msg) => Invoke(new Action(() => Output(msg)));
            _clientNet.OnResponseReceived += (res) => Invoke(new Action(() => {
                Output($"Server: {res.Status} - {res.Message}");
                btn_send.Enabled = true;
            }));
        }

        private async void btn_send_Click(object sender, EventArgs e)
        {
            tb_command.Focus();

            string input = tb_command.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(input)) return;

            var parts = input.Split(' ');
            string baseCommand = parts[0];

            switch (baseCommand)
            {
                case "connect":
                    string targetIp = parts.Length > 1 ? parts[1] : _lastConnectedIp;
                    HandleConnect(targetIp);
                    tb_command.Clear();
                    return;

                case "stream":
                    if (parts.Length > 1 && (parts[1] == "open" || parts[1] == "close"))
                    {
                        HandleLocalStream(parts[1]);
                        tb_command.Clear();
                        return;
                    }
                    break;

                case "server":
                    if (parts.Length > 1 && parts[1] == "exit")
                    {
                        break;
                    }

                    HandleLocalSwitch();
                    tb_command.Clear();
                    return;

                case "exit":
                    ExitSafely();
                    return;
            }

            if (!_clientNet.IsConnected)
            {
                Output("ERROR: Not connected.");
                return;
            }

            btn_send.Enabled = false;
            var cmd = new CommandPacket { Name = baseCommand };
            if (parts.Length > 1) cmd.Action = parts[1];

            await _clientNet.SendCommandAsync(cmd);
            tb_command.Clear();
        }

        private async void HandleConnect(string ip)
        {
            Output($"Attempting to connect to {ip}...");

            if (await _clientNet.ConnectAsync(ip, 8910))
            {
                _lastConnectedIp = ip;
                Output($"Connected successfully to {ip}.");
            }
            else
            {
                Output("Connection failed.");
            }
        }

        private void HandleLocalStream(string action)
        {
            if (action == "open")
            {
                if (Application.OpenForms["stream"] == null)
                {
                    if (string.IsNullOrWhiteSpace(_lastConnectedIp))
                    {
                        Output("ERROR: No connection established. Use 'connect [ip]' first.");
                        return;
                    }

                    stream streamWindow = new stream();
                    streamWindow.Name = "stream";
                    streamWindow.Show();

                    streamWindow.StartStream(_lastConnectedIp, 8911);
                    Output($"Stream window opened. Connecting to {_lastConnectedIp}:8911...");
                }
            }
            else if (action == "close")
            {
                Form streamWindow = Application.OpenForms["stream"];
                streamWindow?.Close();
                Output("Stream window closed.");
            }
        }

        private void HandleLocalSwitch()
        {
            _clientNet.Disconnect();
            this.Hide();
            server serverForm = new server();
            serverForm.Show();
            serverForm.FormClosed += (s, args) => this.Close();
        }

        private void ExitSafely()
        {
            _clientNet.Disconnect();
            Application.Exit();
        }

        private void Output(string _text) => rtb_output.AppendText($"{DateTime.Now:HH:mm:ss} | {_text}\n");

        private void btn_exit_Click(object sender, EventArgs e) => ExitSafely();
    }
}
