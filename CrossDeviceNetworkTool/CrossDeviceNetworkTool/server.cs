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
        private ServerNetwork _serverNet;
        private StreamingServer _streamServer;

        public server()
        {
            InitializeComponent();
            _serverNet = new ServerNetwork();
            _streamServer = new StreamingServer();

            _serverNet.OnLog += (msg) =>
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

            _serverNet.OnCommandReceived += HandleCommand;

            this.Load += (s, e) => {
                _serverNet.Start(8910);
                _streamServer.Start(8911);
            };
        }

        private async void HandleCommand(CommandPacket cmd, System.Net.Sockets.TcpClient client)
        {
            Invoke(new Action(() => Output($"Command: {cmd.Name} {cmd.Action}")));
            ResponsePacket response = new ResponsePacket { Name = cmd.Name, Status = "success" };

            if (cmd.Name == "stream")
            {
                switch (cmd.Action)
                {
                    case "start":
                        _streamServer.ToggleStreaming(true);
                        response.Message = $"Stream started using {_streamServer.CurrentSource}";
                        break;
                    case "stop":
                        _streamServer.ToggleStreaming(false);
                        response.Message = "Stream paused.";
                        break;
                    case "source":
                        string requested = cmd.Flags.Count > 0 ? cmd.Flags[0].ToLower() : "screen";
                        var source = requested == "webcam" ? StreamingServer.StreamSource.Webcam : StreamingServer.StreamSource.Screen;
                        _streamServer.SetSource(source);
                        response.Message = $"Source switched to {requested}.";
                        break;
                    default:
                        response.Status = "error";
                        response.Message = $"Unknown stream action: {cmd.Action}";
                        break;
                }
            }
            else if (cmd.Name == "server")
            {
                if (cmd.Action == "exit")
                {
                    response.Message = "Server is shutting down...";
                    await _serverNet.SendResponseAsync(client, response);

                    await Task.Delay(500);
                    Application.Exit();
                    return;
                }
            }
            else
            {
                response.Status = "error";
                response.Message = $"Unknown command: {cmd.Name}";
            }

            await _serverNet.SendResponseAsync(client, response);
        }

        private void Output(string _text) => rtb_output.AppendText($"{DateTime.Now:HH:mm:ss} | {_text}\n");

        private void btn_exit_Click(object sender, EventArgs e) => Application.Exit();
    }
}