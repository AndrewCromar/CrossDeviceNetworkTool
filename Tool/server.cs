using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrossDeviceNetworkTool.Models;
using CrossDeviceNetworkTool.Networking;
using CrossDeviceNetworkTool.Streaming;
using AudioSwitcher.AudioApi.CoreAudio;

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
            if (_command.Name == "msg") MessageCommandHandler(_command, _client);
            if (_command.Name == "display") DisplayCommandHandler(_command, _client);
            if (_command.Name == "web") WebCommandHandler(_command, _client);
            if (_command.Name == "volume") VolumeCommandHandler(_command, _client);
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

        private async void MessageCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            _ = Task.Run(() =>
            {
                MessageBox.Show(_command.Action, "Incoming Message");
            });

            ResponsePacket response = new ResponsePacket { Name = _command.Name, Status = "success", Message = "Displayed your message." };
            await _ServerNetwork.SendResponseAsync(_client, response);
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

        private async void WebCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            Process.Start(new ProcessStartInfo { FileName = _command.Action, UseShellExecute = true });

            ResponsePacket response = new ResponsePacket { Name = _command.Name, Status = "success", Message = "Opened that url." };
            await _ServerNetwork.SendResponseAsync(_client, response);
        }

        private async void VolumeCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            
            ResponsePacket response = new ResponsePacket { Name = _command.Name, Status = "success" };

            switch (_command.Action)
            {
                case "mute":
                    if(_command.Flags.Contains("get"))
                    {
                        response.Message = "Mute is currently set to: " + (defaultPlaybackDevice.IsMuted ? "muted." : "unmuted.");
                    }
                    if(_command.Flags.Contains("toggle"))
                    {
                        bool newMuteState = defaultPlaybackDevice.ToggleMute();
                        response.Message = "Toggled mute to: " + (defaultPlaybackDevice.IsMuted ? "muted." : "unmuted.");

                    }
                    break;
                case "volume":
                    if (_command.Flags.Count > 0 && int.TryParse(_command.Flags[0], out int flag))
                    {
                        int volume = Math.Clamp(flag, 0, 100);
                        defaultPlaybackDevice.Volume = volume;
                        response.Message = "Set volume to: " + volume.ToString() + ".";
                    }
                    break;
                default:
                    response.Status = "error";
                    response.Message = "Missing data.";
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