namespace Tool
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
            btn_exit.Location = new Point(10, 9);
            btn_exit.Margin = new Padding(3, 2, 3, 2);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(82, 22);
            btn_exit.TabIndex = 0;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = true;
            btn_exit.Click += btn_exit_Click;
            // 
            // rtb_output
            // 
            rtb_output.Location = new Point(10, 35);
            rtb_output.Margin = new Padding(3, 2, 3, 2);
            rtb_output.Name = "rtb_output";
            rtb_output.ReadOnly = true;
            rtb_output.Size = new Size(818, 359);
            rtb_output.TabIndex = 1;
            rtb_output.Text = "";
            // 
            // server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 405);
            ControlBox = false;
            Controls.Add(rtb_output);
            Controls.Add(btn_exit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
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