namespace CrossDeviceNetworkTool
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
            btn_exit = new Button();
            rtb_output = new RichTextBox();
            SuspendLayout();
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(12, 12);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(94, 29);
            btn_exit.TabIndex = 0;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // rtb_output
            // 
            rtb_output.Location = new Point(12, 47);
            rtb_output.Name = "rtb_output";
            rtb_output.ReadOnly = true;
            rtb_output.Size = new Size(936, 481);
            rtb_output.TabIndex = 1;
            rtb_output.Text = "";
            // 
            // server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 540);
            ControlBox = false;
            Controls.Add(rtb_output);
            Controls.Add(btn_exit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "server";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "server";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_exit;
        private RichTextBox rtb_output;
    }
}