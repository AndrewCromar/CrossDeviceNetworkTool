using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CrossDeviceNetworkTool.Models;

namespace CrossDeviceNetworkTool.Networking
{
    public class ClientNetwork
    {
        private TcpClient _client;
        private NetworkStream _stream;
        public event Action<string> OnLog;
        public event Action<ResponsePacket> OnResponseReceived;
        public bool IsConnected => _client != null && _client.Connected;

        public async Task<bool> ConnectAsync(string ip, int port)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(ip, port);
                _stream = _client.GetStream();
                _ = ListenForResponsesAsync();
                return true;
            }
            catch (Exception ex)
            {
                OnLog?.Invoke($"Connection failed: {ex.Message}");
                return false;
            }
        }

        public async Task SendCommandAsync(CommandPacket cmd)
        {
            if (_client == null || !_client.Connected) return;

            string json = JsonConvert.SerializeObject(cmd);
            byte[] data = Encoding.UTF8.GetBytes(json);
            byte[] length = BitConverter.GetBytes(data.Length);

            await _stream.WriteAsync(length, 0, 4);
            await _stream.WriteAsync(data, 0, data.Length);
        }

        private async Task ListenForResponsesAsync()
        {
            byte[] lengthBuffer = new byte[4];
            try
            {
                while (_client.Connected)
                {
                    int bytesRead = await _stream.ReadAsync(lengthBuffer, 0, 4);
                    if (bytesRead < 4) break;

                    int packetLength = BitConverter.ToInt32(lengthBuffer, 0);
                    byte[] payloadBuffer = new byte[packetLength];

                    int totalRead = 0;
                    while (totalRead < packetLength)
                    {
                        int read = await _stream.ReadAsync(payloadBuffer, totalRead, packetLength - totalRead);
                        totalRead += read;
                    }

                    string json = Encoding.UTF8.GetString(payloadBuffer);
                    var response = JsonConvert.DeserializeObject<ResponsePacket>(json);
                    OnResponseReceived?.Invoke(response);
                }
            }
            catch { OnLog?.Invoke("Disconnected from server."); }
        }

        public void Disconnect()
        {
            _client?.Close();
        }
    }
}