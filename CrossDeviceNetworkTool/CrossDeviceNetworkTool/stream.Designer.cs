namespace CrossDeviceNetworkTool
{
    partial class stream
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
            pb_stream = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_stream).BeginInit();
            SuspendLayout();
            // 
            // pb_stream
            // 
            pb_stream.Dock = DockStyle.Fill;
            pb_stream.Location = new Point(0, 0);
            pb_stream.Name = "pb_stream";
            pb_stream.Size = new Size(800, 450);
            pb_stream.SizeMode = PictureBoxSizeMode.Zoom;
            pb_stream.TabIndex = 0;
            pb_stream.TabStop = false;
            // 
            // stream
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pb_stream);
            Name = "stream";
            Text = "stream";
            ((System.ComponentModel.ISupportInitialize)pb_stream).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_stream;
    }
}