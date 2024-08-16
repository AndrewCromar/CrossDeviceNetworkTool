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
            gb_sounds = new GroupBox();
            btn_uwu = new Button();
            btn_bluetoothDevice = new Button();
            btn_rizz = new Button();
            btn_huhCat = new Button();
            btn_huhAsain = new Button();
            btn_goofyAhhCarHorn = new Button();
            btn_galaxyMeme = new Button();
            btn_femaleScream = new Button();
            btn_knocking = new Button();
            btn_metalPipe = new Button();
            btn_fart = new Button();
            t_outputScroller = new System.Windows.Forms.Timer(components);
            btn_clearOutput = new Button();
            gb_ips.SuspendLayout();
            gb_sounds.SuspendLayout();
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
            btn_menu.Location = new Point(713, 6);
            btn_menu.Name = "btn_menu";
            btn_menu.Size = new Size(75, 23);
            btn_menu.TabIndex = 1;
            btn_menu.Text = "Menu";
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
            gb_ips.Location = new Point(387, 6);
            gb_ips.Name = "gb_ips";
            gb_ips.Size = new Size(147, 81);
            gb_ips.TabIndex = 15;
            gb_ips.TabStop = false;
            gb_ips.Text = "IP Presets";
            // 
            // gb_sounds
            // 
            gb_sounds.Controls.Add(btn_uwu);
            gb_sounds.Controls.Add(btn_bluetoothDevice);
            gb_sounds.Controls.Add(btn_rizz);
            gb_sounds.Controls.Add(btn_huhCat);
            gb_sounds.Controls.Add(btn_huhAsain);
            gb_sounds.Controls.Add(btn_goofyAhhCarHorn);
            gb_sounds.Controls.Add(btn_galaxyMeme);
            gb_sounds.Controls.Add(btn_femaleScream);
            gb_sounds.Controls.Add(btn_knocking);
            gb_sounds.Controls.Add(btn_metalPipe);
            gb_sounds.Controls.Add(btn_fart);
            gb_sounds.Location = new Point(12, 299);
            gb_sounds.Name = "gb_sounds";
            gb_sounds.Size = new Size(776, 139);
            gb_sounds.TabIndex = 16;
            gb_sounds.TabStop = false;
            gb_sounds.Text = "Sounds Effects";
            // 
            // btn_uwu
            // 
            btn_uwu.Location = new Point(198, 51);
            btn_uwu.Name = "btn_uwu";
            btn_uwu.Size = new Size(75, 23);
            btn_uwu.TabIndex = 10;
            btn_uwu.Text = "UWU";
            btn_uwu.UseVisualStyleBackColor = true;
            btn_uwu.Click += btn_uwu_Click;
            // 
            // btn_bluetoothDevice
            // 
            btn_bluetoothDevice.Location = new Point(87, 51);
            btn_bluetoothDevice.Name = "btn_bluetoothDevice";
            btn_bluetoothDevice.Size = new Size(105, 23);
            btn_bluetoothDevice.TabIndex = 9;
            btn_bluetoothDevice.Text = "Bluetooth Device";
            btn_bluetoothDevice.UseVisualStyleBackColor = true;
            btn_bluetoothDevice.Click += btn_bluetoothDevice_Click;
            // 
            // btn_rizz
            // 
            btn_rizz.Location = new Point(6, 51);
            btn_rizz.Name = "btn_rizz";
            btn_rizz.Size = new Size(75, 23);
            btn_rizz.TabIndex = 8;
            btn_rizz.Text = "Rizz";
            btn_rizz.UseVisualStyleBackColor = true;
            btn_rizz.Click += btn_rizz_Click;
            // 
            // btn_huhCat
            // 
            btn_huhCat.Location = new Point(562, 22);
            btn_huhCat.Name = "btn_huhCat";
            btn_huhCat.Size = new Size(75, 23);
            btn_huhCat.TabIndex = 7;
            btn_huhCat.Text = "Huh Cat";
            btn_huhCat.UseVisualStyleBackColor = true;
            btn_huhCat.Click += btn_huhCat_Click;
            // 
            // btn_huhAsain
            // 
            btn_huhAsain.Location = new Point(481, 22);
            btn_huhAsain.Name = "btn_huhAsain";
            btn_huhAsain.Size = new Size(75, 23);
            btn_huhAsain.TabIndex = 6;
            btn_huhAsain.Text = "Huh Asian";
            btn_huhAsain.UseVisualStyleBackColor = true;
            btn_huhAsain.Click += btn_huhAsain_Click;
            // 
            // btn_goofyAhhCarHorn
            // 
            btn_goofyAhhCarHorn.Location = new Point(375, 22);
            btn_goofyAhhCarHorn.Name = "btn_goofyAhhCarHorn";
            btn_goofyAhhCarHorn.Size = new Size(100, 23);
            btn_goofyAhhCarHorn.TabIndex = 5;
            btn_goofyAhhCarHorn.Text = "Goofy Ahh Car Horn";
            btn_goofyAhhCarHorn.UseVisualStyleBackColor = true;
            btn_goofyAhhCarHorn.Click += btn_goofyAhhCarHorn_Click;
            // 
            // btn_galaxyMeme
            // 
            btn_galaxyMeme.Location = new Point(274, 22);
            btn_galaxyMeme.Name = "btn_galaxyMeme";
            btn_galaxyMeme.Size = new Size(95, 23);
            btn_galaxyMeme.TabIndex = 4;
            btn_galaxyMeme.Text = "Galaxy Meme";
            btn_galaxyMeme.UseVisualStyleBackColor = true;
            btn_galaxyMeme.Click += btn_galaxyMeme_Click;
            // 
            // btn_femaleScream
            // 
            btn_femaleScream.Location = new Point(168, 22);
            btn_femaleScream.Name = "btn_femaleScream";
            btn_femaleScream.Size = new Size(100, 23);
            btn_femaleScream.TabIndex = 3;
            btn_femaleScream.Text = "Female Scream";
            btn_femaleScream.UseVisualStyleBackColor = true;
            btn_femaleScream.Click += btn_femaleScream_Click;
            // 
            // btn_knocking
            // 
            btn_knocking.Location = new Point(6, 22);
            btn_knocking.Name = "btn_knocking";
            btn_knocking.Size = new Size(75, 23);
            btn_knocking.TabIndex = 2;
            btn_knocking.Text = "Knocking";
            btn_knocking.UseVisualStyleBackColor = true;
            btn_knocking.Click += btn_knocking_Click;
            // 
            // btn_metalPipe
            // 
            btn_metalPipe.Location = new Point(643, 22);
            btn_metalPipe.Name = "btn_metalPipe";
            btn_metalPipe.Size = new Size(75, 23);
            btn_metalPipe.TabIndex = 1;
            btn_metalPipe.Text = "Metal Pipe";
            btn_metalPipe.UseVisualStyleBackColor = true;
            btn_metalPipe.Click += btn_metalPipe_Click;
            // 
            // btn_fart
            // 
            btn_fart.Location = new Point(87, 22);
            btn_fart.Name = "btn_fart";
            btn_fart.Size = new Size(75, 23);
            btn_fart.TabIndex = 0;
            btn_fart.Text = "Fart";
            btn_fart.UseVisualStyleBackColor = true;
            btn_fart.Click += btn_fart_Click;
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
            // client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btn_clearOutput);
            Controls.Add(gb_sounds);
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
            Name = "client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "client";
            Load += client_Load;
            gb_ips.ResumeLayout(false);
            gb_sounds.ResumeLayout(false);
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
        private GroupBox gb_sounds;
        private Button btn_fart;
        private Button btn_metalPipe;
        private Button btn_knocking;
        private Button btn_galaxyMeme;
        private Button btn_femaleScream;
        private Button btn_goofyAhhCarHorn;
        private Button btn_rizz;
        private Button btn_huhCat;
        private Button btn_huhAsain;
        private Button btn_bluetoothDevice;
        private Button btn_uwu;
        private System.Windows.Forms.Timer t_outputScroller;
        private Button btn_clearOutput;
    }
}