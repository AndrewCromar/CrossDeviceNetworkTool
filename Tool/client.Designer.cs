namespace Tool
{
    partial class client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(client));
            txt_port = new TextBox();
            lbl_port = new Label();
            txt_host = new TextBox();
            lbl_host = new Label();
            btn_connect = new Button();
            txt_input = new TextBox();
            btn_send = new Button();
            txt_output = new RichTextBox();
            btn_menu = new Button();
            btn_andrewDesktopIp = new Button();
            btn_cromarDesktopIp = new Button();
            gb_ips = new GroupBox();
            t_outputScroller = new System.Windows.Forms.Timer(components);
            btn_clearOutput = new Button();
            gb_server = new GroupBox();
            btn_updateServer = new Button();
            btn_shutdownServer = new Button();
            cb_soundeffects = new ComboBox();
            lbl_soundEffects = new Label();
            lbl_links = new Label();
            cb_links = new ComboBox();
            btn_minimize = new Button();
            btn_previewSound = new Button();
            txt_message = new TextBox();
            lbl_message = new Label();
            tb_volume = new TrackBar();
            lbl_volume = new Label();
            gb_mouseWiggle = new GroupBox();
            btn_fillMouseWiggle = new Button();
            txt_count = new TextBox();
            lbl_count = new Label();
            txt_distance = new TextBox();
            lbl_distance = new Label();
            lbl_interval = new Label();
            txt_interval = new TextBox();
            btn_fillSFX = new Button();
            btn_fillLinks = new Button();
            btn_fillMessage = new Button();
            btn_fillVolume = new Button();
            gb_ips.SuspendLayout();
            gb_server.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_volume).BeginInit();
            gb_mouseWiggle.SuspendLayout();
            SuspendLayout();
            // 
            // txt_port
            // 
            txt_port.Location = new Point(200, 6);
            txt_port.Name = "txt_port";
            txt_port.Size = new Size(100, 23);
            txt_port.TabIndex = 9;
            txt_port.Text = "50000";
            // 
            // lbl_port
            // 
            lbl_port.AutoSize = true;
            lbl_port.Location = new Point(159, 9);
            lbl_port.Name = "lbl_port";
            lbl_port.Size = new Size(32, 15);
            lbl_port.TabIndex = 8;
            lbl_port.Text = "Port:";
            // 
            // txt_host
            // 
            txt_host.Location = new Point(53, 6);
            txt_host.Name = "txt_host";
            txt_host.Size = new Size(100, 23);
            txt_host.TabIndex = 7;
            txt_host.Text = "0.0.0.0";
            // 
            // lbl_host
            // 
            lbl_host.AutoSize = true;
            lbl_host.Location = new Point(12, 9);
            lbl_host.Name = "lbl_host";
            lbl_host.Size = new Size(35, 15);
            lbl_host.TabIndex = 6;
            lbl_host.Text = "Host:";
            // 
            // btn_connect
            // 
            btn_connect.Location = new Point(306, 6);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(75, 23);
            btn_connect.TabIndex = 5;
            btn_connect.Text = "Connect";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // txt_input
            // 
            txt_input.Location = new Point(12, 35);
            txt_input.Name = "txt_input";
            txt_input.Size = new Size(288, 23);
            txt_input.TabIndex = 10;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(306, 35);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(75, 23);
            btn_send.TabIndex = 11;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // txt_output
            // 
            txt_output.Location = new Point(12, 64);
            txt_output.Name = "txt_output";
            txt_output.ReadOnly = true;
            txt_output.Size = new Size(369, 229);
            txt_output.TabIndex = 12;
            txt_output.Text = "";
            // 
            // btn_menu
            // 
            btn_menu.Location = new Point(736, 12);
            btn_menu.Name = "btn_menu";
            btn_menu.Size = new Size(23, 23);
            btn_menu.TabIndex = 1;
            btn_menu.Text = "←";
            btn_menu.UseVisualStyleBackColor = true;
            btn_menu.Click += btn_menu_Click;
            // 
            // btn_andrewDesktopIp
            // 
            btn_andrewDesktopIp.Location = new Point(6, 22);
            btn_andrewDesktopIp.Name = "btn_andrewDesktopIp";
            btn_andrewDesktopIp.Size = new Size(135, 23);
            btn_andrewDesktopIp.TabIndex = 13;
            btn_andrewDesktopIp.Text = "Desktop: Andrew";
            btn_andrewDesktopIp.UseVisualStyleBackColor = true;
            btn_andrewDesktopIp.Click += btn_andrewDesktopIp_Click;
            // 
            // btn_cromarDesktopIp
            // 
            btn_cromarDesktopIp.Location = new Point(6, 51);
            btn_cromarDesktopIp.Name = "btn_cromarDesktopIp";
            btn_cromarDesktopIp.Size = new Size(135, 23);
            btn_cromarDesktopIp.TabIndex = 14;
            btn_cromarDesktopIp.Text = "Desktop: Cromar";
            btn_cromarDesktopIp.UseVisualStyleBackColor = true;
            btn_cromarDesktopIp.Click += btn_cromarDesktopIp_Click;
            // 
            // gb_ips
            // 
            gb_ips.Controls.Add(btn_andrewDesktopIp);
            gb_ips.Controls.Add(btn_cromarDesktopIp);
            gb_ips.Location = new Point(387, 96);
            gb_ips.Name = "gb_ips";
            gb_ips.Size = new Size(147, 81);
            gb_ips.TabIndex = 15;
            gb_ips.TabStop = false;
            gb_ips.Text = "IP Presets";
            // 
            // t_outputScroller
            // 
            t_outputScroller.Enabled = true;
            t_outputScroller.Interval = 1000;
            t_outputScroller.Tick += t_outputScroller_Tick;
            // 
            // btn_clearOutput
            // 
            btn_clearOutput.Location = new Point(387, 270);
            btn_clearOutput.Name = "btn_clearOutput";
            btn_clearOutput.Size = new Size(97, 23);
            btn_clearOutput.TabIndex = 17;
            btn_clearOutput.Text = "Clear Output";
            btn_clearOutput.UseVisualStyleBackColor = true;
            btn_clearOutput.Click += btn_clearOutput_Click;
            // 
            // gb_server
            // 
            gb_server.Controls.Add(btn_updateServer);
            gb_server.Controls.Add(btn_shutdownServer);
            gb_server.Location = new Point(387, 6);
            gb_server.Name = "gb_server";
            gb_server.Size = new Size(147, 84);
            gb_server.TabIndex = 16;
            gb_server.TabStop = false;
            gb_server.Text = "Server";
            // 
            // btn_updateServer
            // 
            btn_updateServer.Location = new Point(6, 22);
            btn_updateServer.Name = "btn_updateServer";
            btn_updateServer.Size = new Size(135, 23);
            btn_updateServer.TabIndex = 14;
            btn_updateServer.Text = "Update Server";
            btn_updateServer.UseVisualStyleBackColor = true;
            btn_updateServer.Click += btn_updateServer_Click;
            // 
            // btn_shutdownServer
            // 
            btn_shutdownServer.Location = new Point(6, 51);
            btn_shutdownServer.Name = "btn_shutdownServer";
            btn_shutdownServer.Size = new Size(135, 23);
            btn_shutdownServer.TabIndex = 13;
            btn_shutdownServer.Text = "Shutdown Server";
            btn_shutdownServer.UseVisualStyleBackColor = true;
            btn_shutdownServer.Click += btn_shutdownServer_Click;
            // 
            // cb_soundeffects
            // 
            cb_soundeffects.FormattingEnabled = true;
            cb_soundeffects.Location = new Point(100, 299);
            cb_soundeffects.Name = "cb_soundeffects";
            cb_soundeffects.Size = new Size(281, 23);
            cb_soundeffects.TabIndex = 19;
            cb_soundeffects.SelectedIndexChanged += cb_soundeffects_SelectedIndexChanged;
            // 
            // lbl_soundEffects
            // 
            lbl_soundEffects.AutoSize = true;
            lbl_soundEffects.Location = new Point(12, 302);
            lbl_soundEffects.Name = "lbl_soundEffects";
            lbl_soundEffects.Size = new Size(82, 15);
            lbl_soundEffects.TabIndex = 20;
            lbl_soundEffects.Text = "Sound Effects:";
            // 
            // lbl_links
            // 
            lbl_links.AutoSize = true;
            lbl_links.Location = new Point(57, 331);
            lbl_links.Name = "lbl_links";
            lbl_links.Size = new Size(37, 15);
            lbl_links.TabIndex = 22;
            lbl_links.Text = "Links:";
            // 
            // cb_links
            // 
            cb_links.FormattingEnabled = true;
            cb_links.Items.AddRange(new object[] { "https://www.youtube.com/watch?v=dQw4w9WgXcQ" });
            cb_links.Location = new Point(100, 328);
            cb_links.Name = "cb_links";
            cb_links.Size = new Size(281, 23);
            cb_links.TabIndex = 21;
            cb_links.SelectedIndexChanged += cb_links_SelectedIndexChanged;
            // 
            // btn_minimize
            // 
            btn_minimize.Location = new Point(765, 12);
            btn_minimize.Name = "btn_minimize";
            btn_minimize.Size = new Size(23, 23);
            btn_minimize.TabIndex = 23;
            btn_minimize.Text = "–";
            btn_minimize.UseVisualStyleBackColor = true;
            btn_minimize.Click += btn_minimize_Click;
            // 
            // btn_previewSound
            // 
            btn_previewSound.Location = new Point(416, 298);
            btn_previewSound.Name = "btn_previewSound";
            btn_previewSound.Size = new Size(23, 23);
            btn_previewSound.TabIndex = 24;
            btn_previewSound.Text = "▶";
            btn_previewSound.UseVisualStyleBackColor = true;
            btn_previewSound.Click += btn_previewSound_Click;
            // 
            // txt_message
            // 
            txt_message.Location = new Point(100, 357);
            txt_message.Name = "txt_message";
            txt_message.Size = new Size(281, 23);
            txt_message.TabIndex = 0;
            txt_message.TextChanged += txt_message_TextChanged;
            // 
            // lbl_message
            // 
            lbl_message.AutoSize = true;
            lbl_message.Location = new Point(38, 360);
            lbl_message.Name = "lbl_message";
            lbl_message.Size = new Size(56, 15);
            lbl_message.TabIndex = 26;
            lbl_message.Text = "Message:";
            // 
            // tb_volume
            // 
            tb_volume.Location = new Point(100, 389);
            tb_volume.Maximum = 100;
            tb_volume.Name = "tb_volume";
            tb_volume.Size = new Size(281, 45);
            tb_volume.TabIndex = 28;
            tb_volume.TickStyle = TickStyle.None;
            tb_volume.Scroll += tb_volume_Scroll;
            // 
            // lbl_volume
            // 
            lbl_volume.AutoSize = true;
            lbl_volume.Location = new Point(44, 389);
            lbl_volume.Name = "lbl_volume";
            lbl_volume.Size = new Size(50, 15);
            lbl_volume.TabIndex = 29;
            lbl_volume.Text = "Volume:";
            // 
            // gb_mouseWiggle
            // 
            gb_mouseWiggle.Controls.Add(btn_fillMouseWiggle);
            gb_mouseWiggle.Controls.Add(txt_count);
            gb_mouseWiggle.Controls.Add(lbl_count);
            gb_mouseWiggle.Controls.Add(txt_distance);
            gb_mouseWiggle.Controls.Add(lbl_distance);
            gb_mouseWiggle.Controls.Add(lbl_interval);
            gb_mouseWiggle.Controls.Add(txt_interval);
            gb_mouseWiggle.Location = new Point(631, 302);
            gb_mouseWiggle.Name = "gb_mouseWiggle";
            gb_mouseWiggle.Size = new Size(157, 136);
            gb_mouseWiggle.TabIndex = 30;
            gb_mouseWiggle.TabStop = false;
            gb_mouseWiggle.Text = "Mouse Wiggle";
            // 
            // btn_fillMouseWiggle
            // 
            btn_fillMouseWiggle.Location = new Point(6, 107);
            btn_fillMouseWiggle.Name = "btn_fillMouseWiggle";
            btn_fillMouseWiggle.Size = new Size(145, 23);
            btn_fillMouseWiggle.TabIndex = 36;
            btn_fillMouseWiggle.Text = "↑";
            btn_fillMouseWiggle.UseVisualStyleBackColor = true;
            btn_fillMouseWiggle.Click += MouseWiggleAutoFill;
            // 
            // txt_count
            // 
            txt_count.Location = new Point(67, 80);
            txt_count.Name = "txt_count";
            txt_count.Size = new Size(84, 23);
            txt_count.TabIndex = 5;
            txt_count.Text = "0";
            txt_count.TextChanged += MouseWiggleAutoFill;
            // 
            // lbl_count
            // 
            lbl_count.AutoSize = true;
            lbl_count.Location = new Point(18, 83);
            lbl_count.Name = "lbl_count";
            lbl_count.Size = new Size(43, 15);
            lbl_count.TabIndex = 4;
            lbl_count.Text = "Count:";
            // 
            // txt_distance
            // 
            txt_distance.Location = new Point(67, 51);
            txt_distance.Name = "txt_distance";
            txt_distance.Size = new Size(84, 23);
            txt_distance.TabIndex = 3;
            txt_distance.Text = "0";
            txt_distance.TextChanged += MouseWiggleAutoFill;
            // 
            // lbl_distance
            // 
            lbl_distance.AutoSize = true;
            lbl_distance.Location = new Point(6, 54);
            lbl_distance.Name = "lbl_distance";
            lbl_distance.Size = new Size(55, 15);
            lbl_distance.TabIndex = 2;
            lbl_distance.Text = "Distance:";
            // 
            // lbl_interval
            // 
            lbl_interval.AutoSize = true;
            lbl_interval.Location = new Point(12, 25);
            lbl_interval.Name = "lbl_interval";
            lbl_interval.Size = new Size(49, 15);
            lbl_interval.TabIndex = 1;
            lbl_interval.Text = "Interval:";
            // 
            // txt_interval
            // 
            txt_interval.Location = new Point(67, 22);
            txt_interval.Name = "txt_interval";
            txt_interval.Size = new Size(84, 23);
            txt_interval.TabIndex = 0;
            txt_interval.Text = "0";
            txt_interval.TextChanged += MouseWiggleAutoFill;
            // 
            // btn_fillSFX
            // 
            btn_fillSFX.Location = new Point(387, 298);
            btn_fillSFX.Name = "btn_fillSFX";
            btn_fillSFX.Size = new Size(23, 23);
            btn_fillSFX.TabIndex = 31;
            btn_fillSFX.Text = "↑";
            btn_fillSFX.UseVisualStyleBackColor = true;
            btn_fillSFX.Click += cb_soundeffects_SelectedIndexChanged;
            // 
            // btn_fillLinks
            // 
            btn_fillLinks.Location = new Point(387, 328);
            btn_fillLinks.Name = "btn_fillLinks";
            btn_fillLinks.Size = new Size(23, 23);
            btn_fillLinks.TabIndex = 32;
            btn_fillLinks.Text = "↑";
            btn_fillLinks.UseVisualStyleBackColor = true;
            btn_fillLinks.Click += cb_links_SelectedIndexChanged;
            // 
            // btn_fillMessage
            // 
            btn_fillMessage.Location = new Point(387, 357);
            btn_fillMessage.Name = "btn_fillMessage";
            btn_fillMessage.Size = new Size(23, 23);
            btn_fillMessage.TabIndex = 33;
            btn_fillMessage.Text = "↑";
            btn_fillMessage.UseVisualStyleBackColor = true;
            btn_fillMessage.Click += txt_message_TextChanged;
            // 
            // btn_fillVolume
            // 
            btn_fillVolume.Location = new Point(387, 386);
            btn_fillVolume.Name = "btn_fillVolume";
            btn_fillVolume.Size = new Size(23, 23);
            btn_fillVolume.TabIndex = 35;
            btn_fillVolume.Text = "↑";
            btn_fillVolume.UseVisualStyleBackColor = true;
            btn_fillVolume.Click += tb_volume_Scroll;
            // 
            // client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btn_fillVolume);
            Controls.Add(btn_fillMessage);
            Controls.Add(btn_fillLinks);
            Controls.Add(btn_fillSFX);
            Controls.Add(gb_mouseWiggle);
            Controls.Add(lbl_volume);
            Controls.Add(tb_volume);
            Controls.Add(lbl_message);
            Controls.Add(txt_message);
            Controls.Add(btn_previewSound);
            Controls.Add(btn_minimize);
            Controls.Add(lbl_links);
            Controls.Add(cb_links);
            Controls.Add(lbl_soundEffects);
            Controls.Add(cb_soundeffects);
            Controls.Add(gb_server);
            Controls.Add(btn_clearOutput);
            Controls.Add(gb_ips);
            Controls.Add(btn_menu);
            Controls.Add(txt_output);
            Controls.Add(btn_send);
            Controls.Add(txt_input);
            Controls.Add(txt_port);
            Controls.Add(lbl_port);
            Controls.Add(txt_host);
            Controls.Add(lbl_host);
            Controls.Add(btn_connect);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "client";
            Load += client_Load;
            gb_ips.ResumeLayout(false);
            gb_server.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tb_volume).EndInit();
            gb_mouseWiggle.ResumeLayout(false);
            gb_mouseWiggle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_port;
        private Label lbl_port;
        private TextBox txt_host;
        private Label lbl_host;
        private Button btn_connect;
        private TextBox txt_input;
        private Button btn_send;
        private RichTextBox txt_output;
        private Button btn_menu;
        private Button btn_andrewDesktopIp;
        private Button btn_cromarDesktopIp;
        private GroupBox gb_ips;
        private System.Windows.Forms.Timer t_outputScroller;
        private Button btn_clearOutput;
        private GroupBox gb_server;
        private Button btn_shutdownServer;
        private ComboBox cb_soundeffects;
        private Label lbl_soundEffects;
        private Label lbl_links;
        private ComboBox cb_links;
        private Button btn_minimize;
        private Button btn_previewSound;
        private TextBox txt_message;
        private Label lbl_message;
        private TrackBar tb_volume;
        private Label lbl_volume;
        private GroupBox gb_mouseWiggle;
        private Label lbl_interval;
        private TextBox txt_interval;
        private Label lbl_distance;
        private Label lbl_count;
        private TextBox txt_distance;
        private TextBox txt_count;
        private Button btn_fillSFX;
        private Button btn_fillLinks;
        private Button btn_fillMessage;
        private Button btn_fillVolume;
        private Button btn_fillMouseWiggle;
        private Button btn_updateServer;
    }
}