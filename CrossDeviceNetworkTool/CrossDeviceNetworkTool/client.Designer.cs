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
            SuspendLayout();
            // 
            // tb_command
            // 
            tb_command.Location = new Point(10, 9);
            tb_command.Margin = new Padding(3, 2, 3, 2);
            tb_command.Name = "tb_command";
            tb_command.Size = new Size(730, 23);
            tb_command.TabIndex = 0;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(746, 11);
            btn_send.Margin = new Padding(3, 2, 3, 2);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(82, 22);
            btn_send.TabIndex = 1;
            btn_send.Text = "Send";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // rtb_output
            // 
            rtb_output.Location = new Point(10, 37);
            rtb_output.Margin = new Padding(3, 2, 3, 2);
            rtb_output.Name = "rtb_output";
            rtb_output.ReadOnly = true;
            rtb_output.Size = new Size(820, 360);
            rtb_output.TabIndex = 2;
            rtb_output.Text = "";
            // 
            // client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 405);
            ControlBox = false;
            Controls.Add(rtb_output);
            Controls.Add(btn_send);
            Controls.Add(tb_command);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
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
    }
}