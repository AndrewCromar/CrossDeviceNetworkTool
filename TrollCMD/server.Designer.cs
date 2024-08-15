namespace TrollCMD
{
    partial class server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(server));
            btn_start = new Button();
            lbl_host = new Label();
            txt_host = new TextBox();
            txt_port = new TextBox();
            lbl_port = new Label();
            btn_stop = new Button();
            txt_output = new RichTextBox();
            btn_menu = new Button();
            ni_trayIcon = new NotifyIcon(components);
            SuspendLayout();
            // 
            // btn_start
            // 
            btn_start.Location = new Point(306, 6);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(75, 23);
            btn_start.TabIndex = 0;
            btn_start.Text = "Start";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // lbl_host
            // 
            lbl_host.AutoSize = true;
            lbl_host.Location = new Point(12, 9);
            lbl_host.Name = "lbl_host";
            lbl_host.Size = new Size(35, 15);
            lbl_host.TabIndex = 1;
            lbl_host.Text = "Host:";
            // 
            // txt_host
            // 
            txt_host.Location = new Point(53, 6);
            txt_host.Name = "txt_host";
            txt_host.Size = new Size(100, 23);
            txt_host.TabIndex = 2;
            txt_host.Text = "0.0.0.0";
            // 
            // txt_port
            // 
            txt_port.Location = new Point(200, 6);
            txt_port.Name = "txt_port";
            txt_port.Size = new Size(100, 23);
            txt_port.TabIndex = 4;
            txt_port.Text = "50000";
            // 
            // lbl_port
            // 
            lbl_port.AutoSize = true;
            lbl_port.Location = new Point(159, 9);
            lbl_port.Name = "lbl_port";
            lbl_port.Size = new Size(32, 15);
            lbl_port.TabIndex = 3;
            lbl_port.Text = "Port:";
            // 
            // btn_stop
            // 
            btn_stop.Location = new Point(387, 6);
            btn_stop.Name = "btn_stop";
            btn_stop.Size = new Size(75, 23);
            btn_stop.TabIndex = 5;
            btn_stop.Text = "Stop";
            btn_stop.UseVisualStyleBackColor = true;
            btn_stop.Click += btn_stop_Click;
            // 
            // txt_output
            // 
            txt_output.Location = new Point(12, 35);
            txt_output.Name = "txt_output";
            txt_output.Size = new Size(450, 305);
            txt_output.TabIndex = 6;
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
            // ni_trayIcon
            // 
            ni_trayIcon.Icon = (Icon)resources.GetObject("ni_trayIcon.Icon");
            ni_trayIcon.Text = "TrollCMD - AndrewCromar";
            ni_trayIcon.MouseDoubleClick += ni_trayIcon_MouseDoubleClick;
            // 
            // server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btn_menu);
            Controls.Add(txt_output);
            Controls.Add(btn_stop);
            Controls.Add(txt_port);
            Controls.Add(lbl_port);
            Controls.Add(txt_host);
            Controls.Add(lbl_host);
            Controls.Add(btn_start);
            Name = "server";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "server";
            Load += server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_start;
        private Label lbl_host;
        private TextBox txt_host;
        private TextBox txt_port;
        private Label lbl_port;
        private Button btn_stop;
        private RichTextBox txt_output;
        private Button btn_menu;
        private NotifyIcon ni_trayIcon;
    }
}