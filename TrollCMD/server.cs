using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using WMPLib;
using System.Media;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Policy;
using System.Security.Cryptography;

namespace TrollCMD
{
    public partial class server : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 0x0115;
        private const int SB_BOTTOM = 7;

        public server()
        {
            InitializeComponent();
        }

        SimpleTcpServer tcp_server;
        private void server_Load(object sender, EventArgs e)
        {
            tcp_server = new SimpleTcpServer();
            tcp_server.Delimiter = 0x13;
            tcp_server.StringEncoder = Encoding.UTF8;
            tcp_server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txt_output.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
            {
                txt_output.Text += "\nReceived: " + e.MessageString + "\n > Attempting to run command...";
                string result = TryCommand(e.MessageString);
                txt_output.Text += "\n > " + result;
                e.ReplyLine(result);
            });
        }

        private string TryCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return "Error running command: No command found.";
            }

            int spaceIndex = command.IndexOf(' ');

            command = command.Substring(0, command.Length - 1);

            string commandName;
            string arguments = "";

            if (spaceIndex == -1)
            {
                commandName = command;
            }
            else
            {
                commandName = command.Substring(0, spaceIndex);
                arguments = command.Substring(spaceIndex + 1);
            }

            if (commandName == "msg")
            {
                new Thread(() => MessageBox.Show(arguments)).Start();

                return "Success: Message box shown.";
            }

            if (commandName == "server")
            {
                if (arguments == "shutdown")
                {
                    new Thread(() =>
                    {
                        Thread.Sleep(5000);
                        Application.Exit();
                    }).Start();

                    return "Success: Server shutting down in 5 seconds.";
                }
            }

            if (commandName == "sfx")
            {
                try
                {
                    string relativePath = @"sounds/" + arguments;
                    SoundPlayer simpleSound = new SoundPlayer(relativePath);
                    simpleSound.Play();

                    return "Sucess: Played sound: " + arguments;
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.ToString();
                }
            }

            if (commandName == "web")
            {
                string url = arguments;
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });

                    return "Opened link: \"" + url + "\".";
                }
                catch (Exception ex)
                {
                    return "Error running command: " + ex.ToString();
                }
            }

            if (commandName == "mousewiggle")
            {
                var args = arguments.Split(' ');

                if (args.Length != 3)
                {
                    return "Error: mousewiggle command requires 3 arguments: interval, distance, and count.";
                }

                try
                {
                    int interval = int.Parse(args[0]);
                    int distance = int.Parse(args[1]);
                    int count = int.Parse(args[2]);

                    var wiggler = new MouseWiggler(interval, count, distance);
                    wiggler.StartWiggle();

                    return "Success: Mouse wiggling started.";
                }
                catch (Exception ex)
                {
                    return "Error parsing arguments: " + ex.Message;
                }
            }

            return "Error running command: No reson given.";
        }


        private void btn_start_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        public void StartServer()
        {
            txt_output.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txt_host.Text);
            tcp_server.Start(ip, Convert.ToInt32(txt_port.Text));
            txt_output.Text += "\n > Server started.";
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            if (tcp_server.IsStarted)
            {
                tcp_server.Stop();
            }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            StopServer();
            start new_start = new start();
            new_start.notFirstLoad = true;
            new_start.Show();
            new_start.ExitTray();
            this.Hide();
        }

        #region Tray
        public void EnterTray()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            ni_trayIcon.Visible = true;
        }

        public void ExitTray()
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            ni_trayIcon.Visible = false;
        }

        private void ni_trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ExitTray();
        }
        #endregion

        private void t_outputScroller_Tick(object sender, EventArgs e)
        {
            ScrollToBottomUsingAPI(txt_output);
        }

        private void ScrollToBottomUsingAPI(RichTextBox richTextBox)
        {
            SendMessage(richTextBox.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
        }

        private void btn_clearOutput_Click(object sender, EventArgs e)
        {
            txt_output.Clear();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_tray_Click(object sender, EventArgs e)
        {
            EnterTray();
        }
    }
}
