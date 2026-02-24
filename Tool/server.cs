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
            else if (_command.Name == "stream") StreamCommandHandler(_command, _client);
            else if (_command.Name == "msg") MessageCommandHandler(_command, _client);
            else if (_command.Name == "display") DisplayCommandHandler(_command, _client);
            else if (_command.Name == "web") WebCommandHandler(_command, _client);
            else if (_command.Name == "volume") VolumeCommandHandler(_command, _client);
            else if (_command.Name == "exit" && _command.Flags.Contains("yes")) ExitSafely();
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