using System.Diagnostics;

namespace Updater
{
    public partial class updater : Form
    {
        private int UPDATE_DURATION_ms = 20000;

        public updater()
        {
            InitializeComponent();
        }

        private void updater_Load(object sender, EventArgs e)
        {
            t_updateTime.Interval = UPDATE_DURATION_ms;
            t_updateTime.Enabled = true;
        }

        private void t_updateTime_Tick(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\..\\Tool\\Tool.exe");
            Application.Exit();
        }
    }
}
