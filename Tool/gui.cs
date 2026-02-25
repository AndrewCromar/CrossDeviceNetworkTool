using Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool
{
    public partial class Gui : Form
    {
        Client MYclient;

        public Gui(Client _client)
        {
            InitializeComponent();

            MYclient = _client;
        }

        private void RunCommand(string _command)
        {
            MYclient.SendCommand(_command);
        }

        private void btn_connectIP_Click(object sender, EventArgs e)
        {
            RunCommand($"connect {tb_ip.Text} -l");
        }

        private void btn_connectPreset_Click(object sender, EventArgs e)
        {
            RunCommand($"connect -preset -{tb_preset.Text} -{tb_password.Text} -l");
        }

        private void btn_volume_Click(object sender, EventArgs e)
        {
            RunCommand($"volume set -{tbar_volume.Value}");
        }

        private void btn_mute_Click(object sender, EventArgs e)
        {
            RunCommand("volume mute -set -true");
        }

        private void btn_unmute_Click(object sender, EventArgs e)
        {
            RunCommand("volume mute -set -false");
        }

        private void btn_connectLocal_Click(object sender, EventArgs e)
        {
            RunCommand("connect -local -l");
        }

        private void btn_streamOpen_Click(object sender, EventArgs e)
        {
            RunCommand("stream open -l");
        }

        private void btn_streamClose_Click(object sender, EventArgs e)
        {
            RunCommand("stream close -l");
        }

        private void btn_streamStart_Click(object sender, EventArgs e)
        {
            RunCommand("stream start");
        }

        private void btn_streamStop_Click(object sender, EventArgs e)
        {
            RunCommand("stream stop");
        }

        private void btn_streamWebcam_Click(object sender, EventArgs e)
        {
            RunCommand("stream source -webcam");
        }

        private void btn_streamScreen_Click(object sender, EventArgs e)
        {
            RunCommand("stream source -screen");
        }

        private void btn_exitClient_Click(object sender, EventArgs e)
        {
            RunCommand("exit -l");
        }

        private void btn_exitGui_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_exitServer_Click(object sender, EventArgs e)
        {
            RunCommand("exit -yes");
        }

        private void btn_displayShow_Click(object sender, EventArgs e)
        {
            RunCommand("display show");
        }

        private void btn_displayHide_Click(object sender, EventArgs e)
        {
            RunCommand("display hide");
        }
    }
}
