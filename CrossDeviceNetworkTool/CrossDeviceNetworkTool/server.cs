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

        //private async void HandleCommand(CommandPacket cmd, System.Net.Sockets.TcpClient client)
        //{
        //    Invoke(new Action(() => Output($"Command: {cmd.Name} {cmd.Action}")));
        //    ResponsePacket response = new ResponsePacket { Name = cmd.Name, Status = "success" };

        //    if (cmd.Name == "stream")
        //    {
        //        switch (cmd.Action)
        //        {
        //            case "start":
        //                _StreamServer.ToggleStreaming(true);
        //                response.Message = $"Stream started using {_StreamServer.CurrentSource}";
        //                break;
        //            case "stop":
        //                _StreamServer.ToggleStreaming(false);
        //                response.Message = "Stream paused.";
        //                break;
        //            case "source":
        //                string requested = cmd.Flags.Count > 0 ? cmd.Flags[0].ToLower() : "screen";
        //                var source = requested == "webcam" ? StreamingServer.StreamSource.Webcam : StreamingServer.StreamSource.Screen;
        //                _StreamServer.SetSource(source);
        //                response.Message = $"Source switched to {requested}.";
        //                break;
        //            default:
        //                response.Status = "error";
        //                response.Message = $"Unknown stream action: {cmd.Action}";
        //                break;
        //        }
        //    }
        //    else if (cmd.Name == "server")
        //    {
        //        if (cmd.Action == "exit")
        //        {
        //            response.Message = "Server is shutting down...";
        //            await _ServerNetwork.SendResponseAsync(client, response);

        //            await Task.Delay(500);
        //            Application.Exit();
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        response.Status = "error";
        //        response.Message = $"Unknown command: {cmd.Name}";
        //    }

        //    await _ServerNetwork.SendResponseAsync(client, response);
        //}

        public void OnCommandReceived(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            if (_command.Name == "ping") PingCommandHandler(_command, _client);
            if (_command.Name == "stream") StreamCommandHandler(_command, _client);
            if (_command.Name == "show") ShowCommandHandler();
            if (_command.Name == "hide") HideCommandHandler();
            if (_command.Name == "exit" && _command.Flags.Contains("yes")) ExitSafely();
        }

        private async void PingCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            await _ServerNetwork.SendResponseAsync(_client, new ResponsePacket { Name = _command.Name, Status = "success", Message = "Pong!" });
        }

        private async void StreamCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            ResponsePacket response = new ResponsePacket { Name = _command.Name, Status = "success" };

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
                case "source":
                    string requested = _command.Flags.Count > 0 ? _command.Flags[0].ToLower() : "screen";
                    var source = requested == "webcam" ? StreamingServer.StreamSource.Webcam : StreamingServer.StreamSource.Screen;
                    _StreamServer.SetSource(source);
                    response.Message = $"Source switched to {requested}.";
                    break;
                default:
                    response.Status = "error";
                    response.Message = $"Unknown stream action: {_command.Action}";
                    break;
            }

            await _ServerNetwork.SendResponseAsync(_client, response);
        }

        private void ShowCommandHandler()
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void HideCommandHandler()
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void ExitSafely()
        {
            _StreamServer.Stop();
            _ServerNetwork.Disconnect();
            Application.Exit();
        }

        private void Output(string _text) => rtb_output.AppendText($"{DateTime.Now:HH:mm:ss} | {_text}\n");

        private void btn_exit_Click(object sender, EventArgs e) => ExitSafely();
    }
}