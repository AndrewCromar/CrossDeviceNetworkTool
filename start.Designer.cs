﻿namespace TrollCMD
{
    partial class start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(start));
            btn_server = new Button();
            btn_client = new Button();
            gb_startupSettings = new GroupBox();
            cb_startWithWindows = new CheckBox();
            cb_startInTray = new CheckBox();
            ni_trayIcon = new NotifyIcon(components);
            gb_controlls = new GroupBox();
            btn_tray = new Button();
            btn_exit = new Button();
            gb_startupSettings.SuspendLayout();
            gb_controlls.SuspendLayout();
            SuspendLayout();
            // 
            // btn_server
            // 
            btn_server.Location = new Point(12, 12);
            btn_server.Name = "btn_server";
            btn_server.Size = new Size(75, 23);
            btn_server.TabIndex = 0;
            btn_server.Text = "Server";
            btn_server.UseVisualStyleBackColor = true;
            btn_server.Click += btn_server_Click;
            // 
            // btn_client
            // 
            btn_client.Location = new Point(12, 41);
            btn_client.Name = "btn_client";
            btn_client.Size = new Size(75, 23);
            btn_client.TabIndex = 1;
            btn_client.Text = "Client";
            btn_client.UseVisualStyleBackColor = true;
            btn_client.Click += btn_client_Click;
            // 
            // gb_startupSettings
            // 
            gb_startupSettings.Controls.Add(cb_startWithWindows);
            gb_startupSettings.Controls.Add(cb_startInTray);
            gb_startupSettings.Location = new Point(93, 12);
            gb_startupSettings.Name = "gb_startupSettings";
            gb_startupSettings.Size = new Size(149, 100);
            gb_startupSettings.TabIndex = 2;
            gb_startupSettings.TabStop = false;
            gb_startupSettings.Text = "Startup Settings";
            // 
            // cb_startWithWindows
            // 
            cb_startWithWindows.AutoSize = true;
            cb_startWithWindows.Location = new Point(6, 47);
            cb_startWithWindows.Name = "cb_startWithWindows";
            cb_startWithWindows.Size = new Size(129, 19);
            cb_startWithWindows.TabIndex = 1;
            cb_startWithWindows.Text = "Start with windows.";
            cb_startWithWindows.UseVisualStyleBackColor = true;
            // 
            // cb_startInTray
            // 
            cb_startInTray.AutoSize = true;
            cb_startInTray.Location = new Point(6, 22);
            cb_startInTray.Name = "cb_startInTray";
            cb_startInTray.Size = new Size(89, 19);
            cb_startInTray.TabIndex = 0;
            cb_startInTray.Text = "Start in tray.";
            cb_startInTray.UseVisualStyleBackColor = true;
            cb_startInTray.CheckedChanged += cb_startInTray_CheckedChanged;
            // 
            // ni_trayIcon
            // 
            ni_trayIcon.Icon = (Icon)resources.GetObject("ni_trayIcon.Icon");
            ni_trayIcon.Text = "TrollCMD - AndrewCromar";
            ni_trayIcon.Visible = true;
            ni_trayIcon.MouseDoubleClick += ni_trayIcon_MouseDoubleClick;
            // 
            // gb_controlls
            // 
            gb_controlls.Controls.Add(btn_tray);
            gb_controlls.Controls.Add(btn_exit);
            gb_controlls.Location = new Point(248, 12);
            gb_controlls.Name = "gb_controlls";
            gb_controlls.Size = new Size(188, 100);
            gb_controlls.TabIndex = 3;
            gb_controlls.TabStop = false;
            gb_controlls.Text = "Controlls";
            // 
            // btn_tray
            // 
            btn_tray.Location = new Point(6, 51);
            btn_tray.Name = "btn_tray";
            btn_tray.Size = new Size(75, 23);
            btn_tray.TabIndex = 1;
            btn_tray.Text = "Tray";
            btn_tray.UseVisualStyleBackColor = true;
            btn_tray.Click += btn_tray_Click;
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(6, 22);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(75, 23);
            btn_exit.TabIndex = 0;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // start
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 211);
            ControlBox = false;
            Controls.Add(gb_controlls);
            Controls.Add(gb_startupSettings);
            Controls.Add(btn_client);
            Controls.Add(btn_server);
            Name = "start";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "start";
            Load += start_Load;
            gb_startupSettings.ResumeLayout(false);
            gb_startupSettings.PerformLayout();
            gb_controlls.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_server;
        private Button btn_client;
        private GroupBox gb_startupSettings;
        private CheckBox cb_startInTray;
        private CheckBox cb_startWithWindows;
        private NotifyIcon ni_trayIcon;
        private GroupBox gb_controlls;
        private Button btn_exit;
        private Button btn_tray;
    }
}