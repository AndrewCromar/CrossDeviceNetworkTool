using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrollCMD
{
    public partial class client : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_VSCROLL = 0x0115;
        private const int SB_BOTTOM = 7;

        public client()
        {
            InitializeComponent();
        }

        SimpleTcpClient tcp_client;

        private void client_Load(object sender, EventArgs e)
        {
            txt_host.Text = Properties.Settings.Default.cromarDesktopIp;

            tcp_client = new SimpleTcpClient();
            tcp_client.StringEncoder = Encoding.UTF8;
            tcp_client.DataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object? sender, SimpleTCP.Message e)
        {
            txt_output.Invoke((System.Windows.Forms.MethodInvoker)delegate ()
            {
                txt_output.Text += "\n > Responce: \"" + e.MessageString + "\"";
            });
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            btn_connect.Enabled = false;
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txt_host.Text);
            tcp_client.Connect(txt_host.Text, Convert.ToInt32(txt_port.Text));
        }

        private void btx_send_Click(object sender, EventArgs e)
        {
            txt_output.Text += "\n\n Sending command: \"" + txt_input.Text + "\"\n > Waiting for responce...";
            tcp_client.WriteLineAndGetReply(txt_input.Text, TimeSpan.FromMilliseconds(100));
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            tcp_client.Disconnect();
            start new_start = new start();
            new_start.Show();
            new_start.ExitTray();
            this.Hide();
        }

        private void btn_andrewDesktopIp_Click(object sender, EventArgs e)
        {
            txt_host.Text = Properties.Settings.Default.andrewDesktopIp;
        }

        private void btn_cromarDesktopIp_Click(object sender, EventArgs e)
        {
            txt_host.Text = Properties.Settings.Default.cromarDesktopIp;
        }

        #region sfx
        private void CommandSoundEffect(string soundEffect)
        {
            txt_output.Text += "\n Sending command: \"sfx " + soundEffect + "\"\n > Waiting for responce...";
            try
            {
                tcp_client.WriteLineAndGetReply("sfx " + soundEffect, TimeSpan.FromMilliseconds(100));
            }
            catch (Exception ex)
            {
                txt_output.Text += "\n > Error: " + ex.ToString();
            }
        }

        private void btn_knocking_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("crazy-realistic-knocking-sound-troll-twitch-streamers_small.wav");
        }
        private void btn_fart_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("fart.wav");
        }

        private void btn_femaleScream_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("female-startled-scream.wav");
        }

        private void btn_galaxyMeme_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("galaxy-meme.wav");
        }

        private void btn_goofyAhhCarHorn_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("goofy-ahh-car-horn-sound-effect.wav");
        }

        private void btn_huhAsain_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("huh_asian.wav");
        }

        private void btn_huhCat_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("huh-cat.wav");
        }

        private void btn_metalPipe_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("metal-pipe-clang.wav");
        }

        private void btn_rizz_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("rizz-sound-effect.wav");
        }

        private void btn_bluetoothDevice_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("the-bluetooth-device-is-ready-to-pair.wav");
        }

        private void btn_uwu_Click(object sender, EventArgs e)
        {
            CommandSoundEffect("youtube-uwuuuuu.wav");
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

        private void btn_shutdownServer_Click(object sender, EventArgs e)
        {
            txt_output.Text += "\n Sending command: \"server shutdown\"\n > Waiting for responce...";
            try
            {
                tcp_client.WriteLineAndGetReply("server shutdown", TimeSpan.FromMilliseconds(100));
            }
            catch (Exception ex)
            {
                txt_output.Text += "\n > Error: " + ex.ToString();
            }
        }

        #region web
        private void CommandOpenLink(string link)
        {
            txt_output.Text += "\n Sending command: \"web " + link + "\"\n > Waiting for responce...";
            try
            {
                tcp_client.WriteLineAndGetReply("web " + link, TimeSpan.FromMilliseconds(100));
            }
            catch (Exception ex)
            {
                txt_output.Text += "\n > Error: " + ex.ToString();
            }
        }

        private void btn_rickRoll_Click(object sender, EventArgs e)
        {
            CommandOpenLink("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
        #endregion
    }
}
