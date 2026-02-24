using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using AForge.Video.DirectShow;

namespace CrossDeviceNetworkTool.Streaming
{
    public class StreamingServer
    {
        private TcpListener _listener;
        private bool _isPaused = true;

        // Hardware/Source Variables
        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _webcam;
        private Bitmap _lastWebcamFrame;
        private readonly object _frameLock = new object();

        public enum StreamSource { Screen, Webcam }
        public StreamSource CurrentSource { get; set; } = StreamSource.Webcam;

        public StreamingServer()
        {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (_videoDevices.Count > 0)
            {
                StartWebcam();
            }
        }

        public void Start(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            _ = AcceptClientsAsync();
        }

        public void ToggleStreaming(bool start)
        {
            _isPaused = !start;
        }

        public void SetSource(StreamSource source)
        {
            CurrentSource = source;
            if (source == StreamSource.Webcam && (_webcam == null || !_webcam.IsRunning))
            {
                StartWebcam();
            }
        }

        private async Task AcceptClientsAsync()
        {
            while (true)
            {
                try
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    _ = StreamToClientAsync(client);
                }
                catch { break; }
            }
        }

        private async Task StreamToClientAsync(TcpClient client)
        {
            var stream = client.GetStream();
            try
            {
                while (client.Connected)
                {
                    if (_isPaused)
                    {
                        await Task.Delay(500);
                        continue;
                    }

                    // *** FIXED: Now calling CaptureFrame() which respects the switch ***
                    byte[] frame = CaptureFrame();

                    byte[] length = BitConverter.GetBytes(frame.Length);

                    await stream.WriteAsync(length, 0, 4);
                    await stream.WriteAsync(frame, 0, frame.Length);

                    await Task.Delay(33); // ~30 FPS
                }
            }
            catch { /* Client disconnected */ }
            finally { client.Close(); }
        }

        private byte[] CaptureFrame()
        {
            if (CurrentSource == StreamSource.Webcam)
            {
                lock (_frameLock)
                {
                    if (_lastWebcamFrame != null)
                        return ImageToBytes(_lastWebcamFrame);
                }
            }
            return CaptureScreen();
        }

        private byte[] CaptureScreen()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                return ImageToBytes(bitmap);
            }
        }

        private byte[] ImageToBytes(Bitmap bmp)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void StartWebcam()
        {
            if (_videoDevices.Count == 0) return;

            _webcam = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            _webcam.NewFrame += (s, e) =>
            {
                lock (_frameLock)
                {
                    _lastWebcamFrame?.Dispose();
                    _lastWebcamFrame = (Bitmap)e.Frame.Clone();
                }
            };
            _webcam.Start();
        }

        public void Stop()
        {
            _isPaused = true;
            if (_webcam != null && _webcam.IsRunning) _webcam.SignalToStop();
        }
    }
}