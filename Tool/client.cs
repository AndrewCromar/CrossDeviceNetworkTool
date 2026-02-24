using System.Data;
using System.Text;
using CrossDeviceNetworkTool.Models;
using CrossDeviceNetworkTool.Networking;
using System.Security.Cryptography;

namespace CrossDeviceNetworkTool
{
    public partial class client : Form
    {
        private ClientNetwork ClientNetwork;
        private string LastConnectedIP = "";
        private stream _StreamForm;

        private List<string> PresetIPs = new List<string>
        {
            "qEp+c2dFfaSlKptUFmTSINurinBzxokdo8c6H2IuIHo=",
            "oKhMbfi+VREYqBnajcf3Rwdva0VeJ5+3UtieWt3wYDA=",
            "oKhMbfi+VREYqBnajcf3R6H87TNNwmLxbqLSlzj548M="
        };

        public client()
        {
            InitializeComponent();
            _StreamForm = new stream();
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
            SendCommand();
        }

        private void SendCommand()
        {
            string raw = tb_command.Text;

            tb_command.Focus();
            tb_command.Clear();

            Output("Attempting to run command: " + raw);

            if(raw == null)
            {
                Output("[ERROR] No command.");
                return;
            }

            CommandPacket command = ParseCommand(raw);

            bool remoteCommand = !command.Flags.Contains("l");

            if (remoteCommand)
            {
                RunRemoteCommand(command);
            }
            else
            {
                RunLocalCommand(command);
            }
        }

        private CommandPacket ParseCommand(string _raw)
        {
            CommandPacket command = new CommandPacket { };

            string[] rawSplit = _raw.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            command.Name = rawSplit.Length > 0 ? rawSplit[0] : "Unknown";

            bool hasAction = rawSplit.Length > 1 && !rawSplit[1].StartsWith("-");
            command.Action = hasAction ? rawSplit[1] : "None";

            command.Flags = rawSplit.Skip(1)
                                    .Where(word => word.StartsWith("-"))
                                    .Select(word => word.TrimStart('-'))
                                    .ToList();
            return command;
        }

        private void RunLocalCommand(CommandPacket _command)
        {
            if (_command.Name == "server") OpenServer();
            if (_command.Name == "stream") StreamCommandHandler(_command);
            if (_command.Name == "connect") Connect(_command);
            if (_command.Name == "crypt") CryptCommandHandler(_command);
            if (_command.Name == "exit") ExitSafely();
        }

        private async void RunRemoteCommand(CommandPacket _command)
        {
            if (!ClientNetwork.IsConnected)
            {
                Output("[ERROR] Not connected to server.");
                return;
            }

            await ClientNetwork.SendCommandAsync(_command);

            Output("Sent command to server.");
        }

        private void ExitSafely()
        {
            ClientNetwork.Disconnect();
            Application.Exit();
        }

        private void StreamCommandHandler(CommandPacket _command)
        {
            switch (_command.Action)
            {
                case "open":
                    _StreamForm.Show();
                    _StreamForm.StartStream(LastConnectedIP, 8911);
                    Output("Opened stream.");
                    break;


                case "close":
                    _StreamForm.StopStream();
                    _StreamForm.Hide();
                    Output("Closed stream.");
                    break;
            }
        }

        private void OpenServer()
        {
            ClientNetwork.Disconnect();

            this.Hide();

            server serverForm = new server();
            serverForm.Show();
        }

        private async void Connect(CommandPacket _command)
        {
            if (ClientNetwork.IsConnected)
            {
                Output("[ERROR]: Already connected to a server.");
                return;
            }

            bool usingPreset = _command.Flags.Contains("preset");

            string ip = "";

            if(!usingPreset)
            {
                ip = _command.Action;

            }
            else
            {
                int.TryParse(_command.Flags[1], out int index);
                string password = _command.Flags[2];
                string preset = PresetIPs[index];
                ip = DecryptData(preset, password);
            }
            
            await ClientNetwork.ConnectAsync(ip, 8910);

            LastConnectedIP = ip;

            Output("Connected to server: '" + LastConnectedIP + "'.");
        }

        private void CryptCommandHandler(CommandPacket _command)
        {
            if (string.IsNullOrEmpty(_command.Action) || _command.Flags.Count == 0)
            {
                Output("[ERROR] Missing data.");
                return;
            }

            switch(_command.Action)
            {
                case "encrypt":
                    Output($"That string encrypted = '{EncryptData(_command.Flags[0], _command.Flags[1])}'.");
                    break;

                case "decrypt":
                    Output($"That string decrypted = '{DecryptData(_command.Flags[0], _command.Flags[1])}'.");
                    break;
            }
        }

        private string EncryptData(string _encrypt, string _password)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(_encrypt);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string DecryptData(string _decrypt, string _password)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(_decrypt);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        return Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch
            {
                return "[ERROR] Invalid password or corrupted data.";
            }
        }

        private void Output(string _text)
        {
            rtb_output.AppendText($"{DateTime.Now:HH:mm:ss} | {_text}\n");
            rtb_output.SelectionStart = rtb_output.Text.Length;
            rtb_output.ScrollToCaret();
        }
        
        private void btn_exit_Click(object sender, EventArgs e) => ExitSafely();

        private string GetSha256Hash(string _input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(_input));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
