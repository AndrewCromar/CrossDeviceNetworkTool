using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossDeviceNetworkTool
{
    public partial class stream : Form
    {
        private TcpClient _videoClient;
        private bool _isStreaming = false;

        public stream()
        {
            InitializeComponent();
        }

        public async void StartStream(string ip, int port)
        {
            try
            {
                _videoClient = new TcpClient();
                await _videoClient.ConnectAsync(ip, port);
                _isStreaming = true;
                _ = ReceiveFramesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Stream Connection Failed: {ex.Message}");
            }
        }

        private async Task ReceiveFramesAsync()
        {
            var networkStream = _videoClient.GetStream();
            byte[] lengthBuffer = new byte[4];

            while (_isStreaming && _videoClient.Connected)
            {
                try
                {
                    int bytesRead = await networkStream.ReadAsync(lengthBuffer, 0, 4);
                    if (bytesRead < 4) break;
                    int imageLength = BitConverter.ToInt32(lengthBuffer, 0);

                    byte[] imageBuffer = new byte[imageLength];
                    int totalRead = 0;
                    while (totalRead < imageLength)
                    {
                        int read = await networkStream.ReadAsync(imageBuffer, totalRead, imageLength - totalRead);
                        if (read == 0) break;
                        totalRead += read;
                    }

                    using (MemoryStream ms = new MemoryStream(imageBuffer))
                    {
                        Image frame = Image.FromStream(ms);

                        pb_stream.Invoke(new Action(() => {
                            pb_stream.Image?.Dispose();
                            pb_stream.Image = frame;
                        }));
                    }
                }
                catch { break; }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _isStreaming = false;
            _videoClient?.Close();
            base.OnFormClosing(e);
        }
    }
}