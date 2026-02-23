namespace CrossDeviceNetworkTool
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
            tb_command = new TextBox();
            btn_send = new Button();
            rtb_output = new RichTextBox();
            btn_exit = new Button();
            SuspendLayout();
            // 
            // tb_command
            // 
            tb_command.Location = new Point(12, 12);
            tb_command.Name = "tb_command";
            tb_command.Size = new Size(736, 27);
            tb_command.TabIndex = 0;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(754, 12);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(94, 29);
            btn_send.TabIndex = 1;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // rtb_output
            // 
            rtb_output.Location = new Point(12, 47);
            rtb_output.Name = "rtb_output";
            rtb_output.ReadOnly = true;
            rtb_output.Size = new Size(936, 481);
            rtb_output.TabIndex = 2;
            rtb_output.Text = "";
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(854, 12);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(94, 29);
            btn_exit.TabIndex = 3;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 540);
            ControlBox = false;
            Controls.Add(btn_exit);
            Controls.Add(rtb_output);
            Controls.Add(btn_send);
            Controls.Add(tb_command);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_command;
        private Button btn_send;
        private RichTextBox rtb_output;
        private Button btn_exit;
    }
}