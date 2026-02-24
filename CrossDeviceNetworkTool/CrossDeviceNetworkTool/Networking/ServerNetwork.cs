using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CrossDeviceNetworkTool.Models;

namespace CrossDeviceNetworkTool.Networking
{
    public class ServerNetwork
    {
        private TcpListener _listener;
        private bool _isRunning;

        public event Action<string> OnLog;
        public event Action<CommandPacket, TcpClient> OnCommandReceived;

        public async void Start(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            _isRunning = true;
            OnLog?.Invoke($"Server started on port {port}...");

            while (_isRunning)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    OnLog?.Invoke($"Client connected: {client.Client.RemoteEndPoint}");
                    _ = HandleClientAsync(client);
                }
                catch { break; }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            var stream = client.GetStream();
            byte[] lengthBuffer = new byte[4];

            try
            {
                while (client.Connected)
                {
                    int bytesRead = await stream.ReadAsync(lengthBuffer, 0, 4);
                    if (bytesRead < 4) break;
                    int packetLength = BitConverter.ToInt32(lengthBuffer, 0);

                    byte[] payloadBuffer = new byte[packetLength];
                    int totalRead = 0;
                    while (totalRead < packetLength)
                    {
                        int read = await stream.ReadAsync(payloadBuffer, totalRead, packetLength - totalRead);
                        if (read == 0) break;
                        totalRead += read;
                    }

                    string json = Encoding.UTF8.GetString(payloadBuffer);
                    var command = JsonConvert.DeserializeObject<CommandPacket>(json);

                    if (command != null)
                        OnCommandReceived?.Invoke(command, client);
                }
            }
            catch (Exception ex) { OnLog?.Invoke($"Error: {ex.Message}"); }
            finally { client.Close(); OnLog?.Invoke("Client disconnected."); }
        }

        public async Task SendResponseAsync(TcpClient client, ResponsePacket response)
        {
            try
            {
                string json = JsonConvert.SerializeObject(response);
                byte[] data = Encoding.UTF8.GetBytes(json);
                byte[] length = BitConverter.GetBytes(data.Length);

                var stream = client.GetStream();
                await stream.WriteAsync(length, 0, 4);
                await stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex) { OnLog?.Invoke($"Failed to send response: {ex.Message}"); }
        }

        public void Disconnect()
        {
            if (!_isRunning) return;

            _isRunning = false;

            try
            {
                _listener?.Stop();

                _listener = null;

                OnLog?.Invoke("Server shut down successfully.");
            }
            catch (Exception ex)
            {
                OnLog?.Invoke($"[ERROR] Failed to shutdown: {ex.Message}.");
            }
        }
    }
}