using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrossDeviceNetworkTool.Models;
using CrossDeviceNetworkTool.Networking;
using CrossDeviceNetworkTool.Streaming;

namespace CrossDeviceNetworkTool
{
    public partial class server : Form
    {
        private ServerNetwork _ServerNetwork;
        private StreamingServer _StreamServer;

        public server()
        {
            InitializeComponent();
            _ServerNetwork = new ServerNetwork();
            _StreamServer = new StreamingServer();

            _ServerNetwork.OnLog += (msg) =>
            {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(() => Output(msg)));
                }
                else
                {
                    Console.WriteLine(msg);
                }
            };

            _ServerNetwork.OnCommandReceived += OnCommandReceived;

            this.Load += (s, e) => {
                _ServerNetwork.Start(8910);
                _StreamServer.Start(8911);
            };
        }

        public void OnCommandReceived(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            if (_command.Name == "ping") PingCommandHandler(_command, _client);
            if (_command.Name == "stream") StreamCommandHandler(_command, _client);
            if (_command.Name == "display") DisplayCommandHandler(_command, _client);
            if (_command.Name == "exit" && _command.Flags.Contains("yes")) ExitSafely();
        }

        private async void PingCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            await _ServerNetwork.SendResponseAsync(_client, new ResponsePacket { Name = _command.Name, Status = "success", Message = "Pong!" });
        }

        private async void StreamCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            ResponsePacket response = new ResponsePacket { Name = _command.Name, Status = "success" };

            if (_command.Flags.Count > 0) SetStreamSource(_command.Flags[0]);

            switch (_command.Action)
            {
                case "start":
                    _StreamServer.ToggleStreaming(true);
                    response.Message = $"Stream started using {_StreamServer.CurrentSource}";
                    break;

                case "stop":
                    _StreamServer.ToggleStreaming(false);
                    response.Message = "Stream paused.";
                    break;

                default:
                    if (_command.Flags.Count > 0) return;
                    response.Status = "error";
                    response.Message = $"Unknown stream action: {_command.Action}";
                    break;
            }

            await _ServerNetwork.SendResponseAsync(_client, response);
        }

        private bool SetStreamSource(string _source)
        {
            StreamingServer.StreamSource newSource = new StreamingServer.StreamSource();

            switch(_source)
            {
                case "screen":
                    newSource = StreamingServer.StreamSource.Screen;
                    break;
                case "webcam":
                    newSource = StreamingServer.StreamSource.Webcam;
                    break;
                default:
                    return false;
            }

            _StreamServer.SetSource(newSource);

            return true;
        }

        private async void DisplayCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            ResponsePacket response = new ResponsePacket { Name = _command.Name, Status = "success" };

            switch (_command.Action)
            {
                case "show":
                    this.ShowInTaskbar = true;
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    response.Message = "Server is showing.";
                    break;

                case "hide":
                    this.Hide();
                    this.ShowInTaskbar = false;
                    response.Message = "Server is hidden.";
                    break;

                default:
                    response.Message = "No action given.";
                    response.Status = "error";
                    break;
            }

            await _ServerNetwork.SendResponseAsync(_client, response);
        }

        private void ExitSafely()
        {
            _StreamServer.Stop();
            _ServerNetwork.Disconnect();
            Application.Exit();
        }

        private void Output(string _text)
        {
            rtb_output.AppendText($"{DateTime.Now:HH:mm:ss} | {_text}\n");
            rtb_output.SelectionStart = rtb_output.Text.Length;
            rtb_output.ScrollToCaret();
        }

        private void btn_exit_Click(object sender, EventArgs e) => ExitSafely();
    }
}