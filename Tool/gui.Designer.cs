namespace Tool
{
    partial class Gui
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
            tb_ip = new TextBox();
            tb_password = new TextBox();
            btn_connectIP = new Button();
            gb_connection = new GroupBox();
            btn_connectLocal = new Button();
            btn_connectPreset = new Button();
            tb_preset = new TextBox();
            gb_volume = new GroupBox();
            tbar_volume = new TrackBar();
            btn_mute = new Button();
            btn_unmute = new Button();
            btn_volume = new Button();
            btn_exitClient = new Button();
            gb_stream = new GroupBox();
            btn_streamScreen = new Button();
            btn_streamWebcam = new Button();
            btn_streamStop = new Button();
            btn_streamStart = new Button();
            btn_streamClose = new Button();
            btn_streamOpen = new Button();
            gb_exit = new GroupBox();
            btn_exitServer = new Button();
            btn_exitGui = new Button();
            gb_display = new GroupBox();
            btn_displayShow = new Button();
            btn_displayHide = new Button();
            gb_connection.SuspendLayout();
            gb_volume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbar_volume).BeginInit();
            gb_stream.SuspendLayout();
            gb_exit.SuspendLayout();
            gb_display.SuspendLayout();
            SuspendLayout();
            // 
            // tb_ip
            // 
            tb_ip.Location = new Point(6, 22);
            tb_ip.Name = "tb_ip";
            tb_ip.PlaceholderText = "ip";
            tb_ip.Size = new Size(206, 23);
            tb_ip.TabIndex = 0;
            // 
            // tb_password
            // 
            tb_password.Location = new Point(112, 51);
            tb_password.Name = "tb_password";
            tb_password.PasswordChar = '•';
            tb_password.PlaceholderText = "password";
            tb_password.Size = new Size(100, 23);
            tb_password.TabIndex = 1;
            // 
            // btn_connectIP
            // 
            btn_connectIP.Location = new Point(218, 21);
            btn_connectIP.Name = "btn_connectIP";
            btn_connectIP.Size = new Size(75, 23);
            btn_connectIP.TabIndex = 2;
            btn_connectIP.Text = "Connect";
            btn_connectIP.UseVisualStyleBackColor = true;
            btn_connectIP.Click += btn_connectIP_Click;
            // 
            // gb_connection
            // 
            gb_connection.Controls.Add(btn_connectLocal);
            gb_connection.Controls.Add(btn_connectPreset);
            gb_connection.Controls.Add(tb_preset);
            gb_connection.Controls.Add(btn_connectIP);
            gb_connection.Controls.Add(tb_password);
            gb_connection.Controls.Add(tb_ip);
            gb_connection.Location = new Point(12, 12);
            gb_connection.Name = "gb_connection";
            gb_connection.Size = new Size(379, 80);
            gb_connection.TabIndex = 4;
            gb_connection.TabStop = false;
            gb_connection.Text = "Connection";
            // 
            // btn_connectLocal
            // 
            btn_connectLocal.Location = new Point(299, 22);
            btn_connectLocal.Name = "btn_connectLocal";
            btn_connectLocal.Size = new Size(75, 23);
            btn_connectLocal.TabIndex = 5;
            btn_connectLocal.Text = "Local";
            btn_connectLocal.UseVisualStyleBackColor = true;
            btn_connectLocal.Click += btn_connectLocal_Click;
            // 
            // btn_connectPreset
            // 
            btn_connectPreset.Location = new Point(218, 51);
            btn_connectPreset.Name = "btn_connectPreset";
            btn_connectPreset.Size = new Size(75, 23);
            btn_connectPreset.TabIndex = 4;
            btn_connectPreset.Text = "Connect";
            btn_connectPreset.UseVisualStyleBackColor = true;
            btn_connectPreset.Click += btn_connectPreset_Click;
            // 
            // tb_preset
            // 
            tb_preset.Location = new Point(6, 51);
            tb_preset.Name = "tb_preset";
            tb_preset.PlaceholderText = "preset index";
            tb_preset.Size = new Size(100, 23);
            tb_preset.TabIndex = 3;
            // 
            // gb_volume
            // 
            gb_volume.Controls.Add(tbar_volume);
            gb_volume.Controls.Add(btn_mute);
            gb_volume.Controls.Add(btn_unmute);
            gb_volume.Controls.Add(btn_volume);
            gb_volume.Location = new Point(12, 214);
            gb_volume.Name = "gb_volume";
            gb_volume.Size = new Size(249, 103);
            gb_volume.TabIndex = 5;
            gb_volume.TabStop = false;
            gb_volume.Text = "Volume Controlls";
            // 
            // tbar_volume
            // 
            tbar_volume.Location = new Point(6, 22);
            tbar_volume.Maximum = 100;
            tbar_volume.Name = "tbar_volume";
            tbar_volume.Size = new Size(237, 45);
            tbar_volume.TabIndex = 6;
            tbar_volume.TickStyle = TickStyle.None;
            // 
            // btn_mute
            // 
            btn_mute.Location = new Point(87, 73);
            btn_mute.Name = "btn_mute";
            btn_mute.Size = new Size(75, 23);
            btn_mute.TabIndex = 2;
            btn_mute.Text = "Mute";
            btn_mute.UseVisualStyleBackColor = true;
            btn_mute.Click += btn_mute_Click;
            // 
            // btn_unmute
            // 
            btn_unmute.Location = new Point(168, 73);
            btn_unmute.Name = "btn_unmute";
            btn_unmute.Size = new Size(75, 23);
            btn_unmute.TabIndex = 1;
            btn_unmute.Text = "Unmute";
            btn_unmute.UseVisualStyleBackColor = true;
            btn_unmute.Click += btn_unmute_Click;
            // 
            // btn_volume
            // 
            btn_volume.Location = new Point(6, 73);
            btn_volume.Name = "btn_volume";
            btn_volume.Size = new Size(75, 23);
            btn_volume.TabIndex = 0;
            btn_volume.Text = "Set Volume";
            btn_volume.UseVisualStyleBackColor = true;
            btn_volume.Click += btn_volume_Click;
            // 
            // btn_exitClient
            // 
            btn_exitClient.Location = new Point(6, 22);
            btn_exitClient.Name = "btn_exitClient";
            btn_exitClient.Size = new Size(75, 23);
            btn_exitClient.TabIndex = 6;
            btn_exitClient.Text = "Exit Client";
            btn_exitClient.UseVisualStyleBackColor = true;
            btn_exitClient.Click += btn_exitClient_Click;
            // 
            // gb_stream
            // 
            gb_stream.Controls.Add(btn_streamScreen);
            gb_stream.Controls.Add(btn_streamWebcam);
            gb_stream.Controls.Add(btn_streamStop);
            gb_stream.Controls.Add(btn_streamStart);
            gb_stream.Controls.Add(btn_streamClose);
            gb_stream.Controls.Add(btn_streamOpen);
            gb_stream.Location = new Point(12, 98);
            gb_stream.Name = "gb_stream";
            gb_stream.Size = new Size(168, 110);
            gb_stream.TabIndex = 7;
            gb_stream.TabStop = false;
            gb_stream.Text = "Stream";
            // 
            // btn_streamScreen
            // 
            btn_streamScreen.Location = new Point(87, 80);
            btn_streamScreen.Name = "btn_streamScreen";
            btn_streamScreen.Size = new Size(75, 23);
            btn_streamScreen.TabIndex = 5;
            btn_streamScreen.Text = "Screen";
            btn_streamScreen.UseVisualStyleBackColor = true;
            btn_streamScreen.Click += btn_streamScreen_Click;
            // 
            // btn_streamWebcam
            // 
            btn_streamWebcam.Location = new Point(6, 80);
            btn_streamWebcam.Name = "btn_streamWebcam";
            btn_streamWebcam.Size = new Size(75, 23);
            btn_streamWebcam.TabIndex = 4;
            btn_streamWebcam.Text = "Webcam";
            btn_streamWebcam.UseVisualStyleBackColor = true;
            btn_streamWebcam.Click += btn_streamWebcam_Click;
            // 
            // btn_streamStop
            // 
            btn_streamStop.Location = new Point(87, 51);
            btn_streamStop.Name = "btn_streamStop";
            btn_streamStop.Size = new Size(75, 23);
            btn_streamStop.TabIndex = 3;
            btn_streamStop.Text = "Stop";
            btn_streamStop.UseVisualStyleBackColor = true;
            btn_streamStop.Click += btn_streamStop_Click;
            // 
            // btn_streamStart
            // 
            btn_streamStart.Location = new Point(6, 51);
            btn_streamStart.Name = "btn_streamStart";
            btn_streamStart.Size = new Size(75, 23);
            btn_streamStart.TabIndex = 2;
            btn_streamStart.Text = "Start";
            btn_streamStart.UseVisualStyleBackColor = true;
            btn_streamStart.Click += btn_streamStart_Click;
            // 
            // btn_streamClose
            // 
            btn_streamClose.Location = new Point(87, 22);
            btn_streamClose.Name = "btn_streamClose";
            btn_streamClose.Size = new Size(75, 23);
            btn_streamClose.TabIndex = 1;
            btn_streamClose.Text = "Close";
            btn_streamClose.UseVisualStyleBackColor = true;
            btn_streamClose.Click += btn_streamClose_Click;
            // 
            // btn_streamOpen
            // 
            btn_streamOpen.Location = new Point(6, 22);
            btn_streamOpen.Name = "btn_streamOpen";
            btn_streamOpen.Size = new Size(75, 23);
            btn_streamOpen.TabIndex = 0;
            btn_streamOpen.Text = "Open";
            btn_streamOpen.UseVisualStyleBackColor = true;
            btn_streamOpen.Click += btn_streamOpen_Click;
            // 
            // gb_exit
            // 
            gb_exit.Controls.Add(btn_exitServer);
            gb_exit.Controls.Add(btn_exitGui);
            gb_exit.Controls.Add(btn_exitClient);
            gb_exit.Location = new Point(740, 12);
            gb_exit.Name = "gb_exit";
            gb_exit.Size = new Size(88, 109);
            gb_exit.TabIndex = 8;
            gb_exit.TabStop = false;
            gb_exit.Text = "Exit";
            // 
            // btn_exitServer
            // 
            btn_exitServer.Location = new Point(6, 80);
            btn_exitServer.Name = "btn_exitServer";
            btn_exitServer.Size = new Size(75, 23);
            btn_exitServer.TabIndex = 8;
            btn_exitServer.Text = "Exit Server";
            btn_exitServer.UseVisualStyleBackColor = true;
            btn_exitServer.Click += btn_exitServer_Click;
            // 
            // btn_exitGui
            // 
            btn_exitGui.Location = new Point(6, 51);
            btn_exitGui.Name = "btn_exitGui";
            btn_exitGui.Size = new Size(75, 23);
            btn_exitGui.TabIndex = 7;
            btn_exitGui.Text = "Exit Gui";
            btn_exitGui.UseVisualStyleBackColor = true;
            btn_exitGui.Click += btn_exitGui_Click;
            // 
            // gb_display
            // 
            gb_display.Controls.Add(btn_displayHide);
            gb_display.Controls.Add(btn_displayShow);
            gb_display.Location = new Point(186, 98);
            gb_display.Name = "gb_display";
            gb_display.Size = new Size(168, 52);
            gb_display.TabIndex = 9;
            gb_display.TabStop = false;
            gb_display.Text = "Display";
            // 
            // btn_displayShow
            // 
            btn_displayShow.Location = new Point(6, 22);
            btn_displayShow.Name = "btn_displayShow";
            btn_displayShow.Size = new Size(75, 23);
            btn_displayShow.TabIndex = 0;
            btn_displayShow.Text = "Show";
            btn_displayShow.UseVisualStyleBackColor = true;
            btn_displayShow.Click += btn_displayShow_Click;
            // 
            // btn_displayHide
            // 
            btn_displayHide.Location = new Point(87, 22);
            btn_displayHide.Name = "btn_displayHide";
            btn_displayHide.Size = new Size(75, 23);
            btn_displayHide.TabIndex = 1;
            btn_displayHide.Text = "Hide";
            btn_displayHide.UseVisualStyleBackColor = true;
            btn_displayHide.Click += btn_displayHide_Click;
            // 
            // Gui
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 405);
            ControlBox = false;
            Controls.Add(gb_display);
            Controls.Add(gb_exit);
            Controls.Add(gb_stream);
            Controls.Add(gb_volume);
            Controls.Add(gb_connection);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Gui";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "gui";
            gb_connection.ResumeLayout(false);
            gb_connection.PerformLayout();
            gb_volume.ResumeLayout(false);
            gb_volume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbar_volume).EndInit();
            gb_stream.ResumeLayout(false);
            gb_exit.ResumeLayout(false);
            gb_display.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox tb_ip;
        private TextBox tb_password;
        private Button btn_connectIP;
        private GroupBox gb_connection;
        private Button btn_connectPreset;
        private TextBox tb_preset;
        private GroupBox gb_volume;
        private Button btn_volume;
        private TrackBar tbar_volume;
        private Button btn_mute;
        private Button btn_unmute;
        private Button btn_exitClient;
        private Button btn_connectLocal;
        private GroupBox gb_stream;
        private Button btn_streamScreen;
        private Button btn_streamWebcam;
        private Button btn_streamStop;
        private Button btn_streamStart;
        private Button btn_streamClose;
        private Button btn_streamOpen;
        private GroupBox gb_exit;
        private Button btn_exitGui;
        private Button btn_exitServer;
        private GroupBox gb_display;
        private Button btn_displayHide;
        private Button btn_displayShow;
    }
}