namespace Updater
{
    partial class updater
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(updater));
            lbl_updating = new Label();
            t_updateTime = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lbl_updating
            // 
            lbl_updating.Dock = DockStyle.Fill;
            lbl_updating.Location = new Point(0, 0);
            lbl_updating.Name = "lbl_updating";
            lbl_updating.Size = new Size(448, 211);
            lbl_updating.TabIndex = 0;
            lbl_updating.Text = "updating...";
            lbl_updating.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // t_updateTime
            // 
            t_updateTime.Interval = 9999;
            t_updateTime.Tick += t_updateTime_Tick;
            // 
            // updater
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 211);
            ControlBox = false;
            Controls.Add(lbl_updating);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "updater";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "updater";
            WindowState = FormWindowState.Minimized;
            Load += updater_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_updating;
        private System.Windows.Forms.Timer t_updateTime;
    }
}