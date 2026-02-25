using System.IO;
using Tool.Models;
using Tool.Networking;

namespace Tool
{
    public partial class Client : Form
    {
        private ClientNetwork ClientNetwork;
        private string LastConnectedIP = "";
        private Stream _StreamForm;

        private List<string> PresetIPs = new List<string>
        {
            "oKhMbfi+VREYqBnajcf3R6H87TNNwmLxbqLSlzj548M=",
            "oKhMbfi+VREYqBnajcf3R1GTUgfFY2elf6QbYvtFXDM="
        };

        public Client()
        {
            InitializeComponent();
            _StreamForm = new Stream();
            ClientNetwork = new ClientNetwork();
            ClientNetwork.OnLog += (_message) => ServerLogHandler(_message);
            ClientNetwork.OnResponseReceived += ServerResponseHandler;
        }

        private void ServerResponseHandler(ResponsePacket _response)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ServerResponseHandler(_response)));
                return;
            }

            Output($"Server: {_response.Status} - {_response.Message}");
        }

        private void ServerLogHandler(string _message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ServerLogHandler(_message)));
                return;
            }

            Output(_message);
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SendCommand(null);
        }

        private void btn_exit_Click(object sender, EventArgs e) => ExitSafely();

        private void Output(string _text)
        {
            rtb_output.AppendText($"{DateTime.Now:HH:mm:ss} | {_text}\n");
            rtb_output.SelectionStart = rtb_output.Text.Length;
            rtb_output.ScrollToCaret();
        }
    }
}