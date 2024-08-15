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
            txt_port = new TextBox();
            lbl_port = new Label();
            txt_host = new TextBox();
            lbl_host = new Label();
            btn_connect = new Button();
            txt_input = new TextBox();
            btx_send = new Button();
            txt_output = new RichTextBox();
            btn_menu = new Button();
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
            // client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}