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
    public partial class gui : Form
    {
        client MYclient;

        public gui(client _client)
        {
            InitializeComponent();

            MYclient = _client;
        }

        private void btn_connectIP_Click(object sender, EventArgs e)
        {
            RunCommand($"connect {tb_ip.Text} -l");
        }

        private void btn_connectPreset_Click(object sender, EventArgs e)
        {
            RunCommand($"connect -preset -{tb_preset.Text} -{tb_password.Text} -l");
        }

        private void RunCommand(string _command)
        {
            MYclient.SendCommand(_command);
        }
    }
}
