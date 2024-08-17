namespace TrollCMD
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
            txt_port = new TextBox();
            lbl_port = new Label();
            txt_host = new TextBox();
            lbl_host = new Label();
            btn_connect = new Button();
            txt_input = new TextBox();
            btx_send = new Button();
            txt_output = new RichTextBox();
            btn_menu = new Button();
            btn_andrewDesktopIp = new Button();
            btn_cromarDesktopIp = new Button();
            gb_ips = new GroupBox();
            t_outputScroller = new System.Windows.Forms.Timer(components);
            btn_clearOutput = new Button();
            gb_server = new GroupBox();
            btn_shutdownServer = new Button();
            cb_soundeffects = new ComboBox();
            lbl_soundEffects = new Label();
            lbl_links = new Label();
            cb_links = new ComboBox();
            btn_minimize = new Button();
            gb_ips.SuspendLayout();
            gb_server.SuspendLayout();
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
            // btx_send
            // 
            btx_send.Location = new Point(306, 35);
            btx_send.Name = "btx_send";
            btx_send.Size = new Size(75, 23);
            btx_send.TabIndex = 11;
            btx_send.Text = "Send";
            btx_send.UseVisualStyleBackColor = true;
            btx_send.Click += btx_send_Click;
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
            btn_andrewDesktopIp.Text = "Andrew's Desktop IP";
            btn_andrewDesktopIp.UseVisualStyleBackColor = true;
            btn_andrewDesktopIp.Click += btn_andrewDesktopIp_Click;
            // 
            // btn_cromarDesktopIp
            // 
            btn_cromarDesktopIp.Location = new Point(6, 51);
            btn_cromarDesktopIp.Name = "btn_cromarDesktopIp";
            btn_cromarDesktopIp.Size = new Size(135, 23);
            btn_cromarDesktopIp.TabIndex = 14;
            btn_cromarDesktopIp.Text = "Cromar's Desktop IP";
            btn_cromarDesktopIp.UseVisualStyleBackColor = true;
            btn_cromarDesktopIp.Click += btn_cromarDesktopIp_Click;
            // 
            // gb_ips
            // 
            gb_ips.Controls.Add(btn_andrewDesktopIp);
            gb_ips.Controls.Add(btn_cromarDesktopIp);
            gb_ips.Location = new Point(387, 64);
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
            btn_clearOutput.Size = new Size(85, 23);
            btn_clearOutput.TabIndex = 17;
            btn_clearOutput.Text = "Clear Output";
            btn_clearOutput.UseVisualStyleBackColor = true;
            btn_clearOutput.Click += btn_clearOutput_Click;
            // 
            // gb_server
            // 
            gb_server.Controls.Add(btn_shutdownServer);
            gb_server.Location = new Point(387, 6);
            gb_server.Name = "gb_server";
            gb_server.Size = new Size(147, 52);
            gb_server.TabIndex = 16;
            gb_server.TabStop = false;
            gb_server.Text = "Server";
            // 
            // btn_shutdownServer
            // 
            btn_shutdownServer.Location = new Point(6, 22);
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
            // client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
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
            Controls.Add(btx_send);
            Controls.Add(txt_input);
            Controls.Add(txt_port);
            Controls.Add(lbl_port);
            Controls.Add(txt_host);
            Controls.Add(lbl_host);
            Controls.Add(btn_connect);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "client";
            Load += client_Load;
            gb_ips.ResumeLayout(false);
            gb_server.ResumeLayout(false);
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
        private Button btx_send;
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
    }
}