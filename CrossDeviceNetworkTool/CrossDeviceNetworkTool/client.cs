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
using Newtonsoft.Json.Linq;

namespace CrossDeviceNetworkTool
{
    public partial class client : Form
    {
        private ClientNetwork ClientNetwork;
        private string LastConnectedIP = "";
        private stream _StreamForm;

        public client()
        {
            InitializeComponent();
            _StreamForm = new stream();
            ClientNetwork = new ClientNetwork();
            ClientNetwork.OnLog += (_message) => ServerLogHandler(_message);
            ClientNetwork.OnResponseReceived += ServerResponseHandler;
        }

        private void ServerResponseHandler(ResponsePacket _response)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ServerResponseHandler(_response)));
                return;
            }

            Output($"Server: {_response.Status} - {_response.Message}");
        }

        private void ServerLogHandler(string _message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ServerLogHandler(_message)));
                return;
            }

            Output(_message);
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void SendCommand()
        {
            string raw = tb_command.Text;

            tb_command.Focus();
            tb_command.Clear();

            Output("Attempting to run command: " + raw);

            if(raw == null)
            {
                Output("[ERROR] No command.");
                return;
            }

            CommandPacket command = ParseCommand(raw);

            bool remoteCommand = !command.Flags.Contains("l");

            if (remoteCommand)
            {
                RunRemoteCommand(command);
            }
            else
            {
                RunLocalCommand(command);
            }
        }

        private CommandPacket ParseCommand(string _raw)
        {
            CommandPacket command = new CommandPacket { };

            string[] rawSplit = _raw.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            command.Name = rawSplit.Length > 0 ? rawSplit[0] : "Unknown";

            bool hasAction = rawSplit.Length > 1 && !rawSplit[1].StartsWith("-");
            command.Action = hasAction ? rawSplit[1] : "None";

            command.Flags = rawSplit.Skip(1)
                                    .Where(word => word.StartsWith("-"))
                                    .Select(word => word.TrimStart('-'))
                                    .ToList();
            return command;
        }

        private void RunLocalCommand(CommandPacket _command)
        {
            if (_command.Name == "server") OpenServer();
            if (_command.Name == "stream") StreamCommandHandler(_command);
            if (_command.Name == "connect") Connect(_command);
            if (_command.Name == "exit") ExitSafely();
        }

        private async void RunRemoteCommand(CommandPacket _command)
        {
            if (!ClientNetwork.IsConnected)
            {
                Output("[ERROR] Not connected to server.");
                return;
            }

            await ClientNetwork.SendCommandAsync(_command);

            Output("Sent command to server.");
        }

        private void ExitSafely()
        {
            ClientNetwork.Disconnect();
            Application.Exit();
        }

        private void StreamCommandHandler(CommandPacket _command)
        {
            switch (_command.Action)
            {
                case "open":
                    _StreamForm.Show();
                    _StreamForm.StartStream(LastConnectedIP, 8911);
                    Output("Opened stream.");
                    break;

                case "close":
                    _StreamForm.StopStream();
                    _StreamForm.Hide();
                    Output("Closed stream.");
                    break;
            }
        }

        private void OpenServer()
        {
            ClientNetwork.Disconnect();

            this.Hide();

            server serverForm = new server();
            serverForm.Show();
        }

        private async void Connect(CommandPacket _command)
        {
            if (ClientNetwork.IsConnected)
            {
                Output("[ERROR]: Already connected to a server.");
                return;
            }

            string ip = _command.Action;

            await ClientNetwork.ConnectAsync(ip, 8910);

            LastConnectedIP = ip;

            Output("Connected to server: '" + ip + "'.");
        }

        private void Output(string _text) => rtb_output.AppendText($"{DateTime.Now:HH:mm:ss} | {_text}\n");

        // Commented out old stuff.
        //
        //private void HandleLocalStream(string action)
        //{
        //    if (action == "open")
        //    {
        //        if (Application.OpenForms["stream"] == null)
        //        {
        //            if (string.IsNullOrWhiteSpace(LastConnectedIP))
        //            {
        //                Output("ERROR: No connection established. Use 'connect [ip]' first.");
        //                return;
        //            }

        //            stream streamWindow = new stream();
        //            streamWindow.Name = "stream";
        //            streamWindow.Show();

        //            streamWindow.StartStream(LastConnectedIP, 8911);
        //            Output($"Stream window opened. Connecting to {LastConnectedIP}:8911...");
        //        }
        //    }
        //    else if (action == "close")
        //    {
        //        Form streamWindow = Application.OpenForms["stream"];
        //        streamWindow?.Close();
        //        Output("Stream window closed.");
        //    }
        //}

        private void btn_exit_Click(object sender, EventArgs e) => ExitSafely();
    }
}
