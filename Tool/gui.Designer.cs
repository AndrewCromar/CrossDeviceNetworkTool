namespace Tool
{
    partial class gui
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
            folderBrowserDialog1 = new FolderBrowserDialog();
            tb_preset = new TextBox();
            btn_connectPreset = new Button();
            gb_connection.SuspendLayout();
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
            gb_connection.Controls.Add(btn_connectPreset);
            gb_connection.Controls.Add(tb_preset);
            gb_connection.Controls.Add(btn_connectIP);
            gb_connection.Controls.Add(tb_password);
            gb_connection.Controls.Add(tb_ip);
            gb_connection.Location = new Point(12, 12);
            gb_connection.Name = "gb_connection";
            gb_connection.Size = new Size(299, 80);
            gb_connection.TabIndex = 4;
            gb_connection.TabStop = false;
            gb_connection.Text = "Connection";
            // 
            // tb_preset
            // 
            tb_preset.Location = new Point(6, 51);
            tb_preset.Name = "tb_preset";
            tb_preset.PasswordChar = '•';
            tb_preset.PlaceholderText = "preset index";
            tb_preset.Size = new Size(100, 23);
            tb_preset.TabIndex = 3;
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
            // gui
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 405);
            Controls.Add(gb_connection);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "gui";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "gui";
            gb_connection.ResumeLayout(false);
            gb_connection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox tb_ip;
        private TextBox tb_password;
        private Button btn_connectIP;
        private GroupBox gb_connection;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btn_connectPreset;
        private TextBox tb_preset;
    }
}