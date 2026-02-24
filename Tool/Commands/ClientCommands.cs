using System.Security.Cryptography;
using System.Text;
using CrossDeviceNetworkTool.Models;

namespace CrossDeviceNetworkTool
{
    public partial class client : Form
    {
        private void SendCommand()
        {
            string raw = tb_command.Text;

            tb_command.Focus();
            tb_command.Clear();

            Output("Attempting to run command: " + raw);

            if (string.IsNullOrWhiteSpace(raw))
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
            string[] rawSplit = _raw.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = rawSplit[0];

            List<string> flags = rawSplit.Skip(1)
                                         .Where(word => word.StartsWith("-"))
                                         .Select(word => word.TrimStart('-'))
                                         .ToList();

            var actionWords = rawSplit.Skip(1)
                                      .Where(word => !word.StartsWith("-"));

            string action = actionWords.Any() ? string.Join(" ", actionWords) : "None";

            return new CommandPacket
            {
                Name = name,
                Action = action,
                Flags = flags
            };
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

        private async void Connect(CommandPacket _command)
        {
            if (ClientNetwork.IsConnected)
            {
                Output("[ERROR]: Already connected to a server.");
                return;
            }

            bool usingPreset = _command.Flags.Contains("preset");
            bool usingLocalhost = _command.Flags.Contains("local");
            string ip = _command.Action;

            if (usingPreset)
            {
                int.TryParse(_command.Flags.ElementAtOrDefault(1), out int index);
                string password = _command.Flags.ElementAtOrDefault(2);
                if (index < PresetIPs.Count)
                    ip = DecryptData(PresetIPs[index], password);
            }

            if (usingLocalhost) ip = "127.0.0.1";

            bool success = await ClientNetwork.ConnectAsync(ip, 8910);

            if (success)
            {
                LastConnectedIP = ip;
                Output("Connected to server: '" + LastConnectedIP + "'.");
            }
            else
            {
                Output("Failed to connect to the server.");
            }
        }

        private void OpenServer()
        {
            ClientNetwork.Disconnect();
            this.Hide();
            server serverForm = new server();
            serverForm.Show();
        }

        private void ExitSafely()
        {
            ClientNetwork.Disconnect();
            Application.Exit();
        }

        private void CryptCommandHandler(CommandPacket _command)
        {
            if (string.IsNullOrEmpty(_command.Action) || _command.Flags.Count < 2)
            {
                Output("[ERROR] Missing data (Action + 2 Flags required).");
                return;
            }

            if (_command.Action == "encrypt")
                Output($"Encrypted: '{EncryptData(_command.Flags[0], _command.Flags[1])}'");
            else if (_command.Action == "decrypt")
                Output($"Decrypted: '{DecryptData(_command.Flags[0], _command.Flags[1])}'");
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
            catch { return "[ERROR] Decryption failed."; }
        }

        private string GetSha256Hash(string _input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(_input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sBuilder.Append(data[i].ToString("x2"));
                return sBuilder.ToString();
            }
        }
    }
}