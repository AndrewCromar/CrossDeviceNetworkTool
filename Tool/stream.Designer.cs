namespace Tool
{
    partial class Stream
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
            pb_stream.Margin = new Padding(3, 2, 3, 2);
            pb_stream.Name = "pb_stream";
            pb_stream.Size = new Size(840, 405);
            pb_stream.SizeMode = PictureBoxSizeMode.Zoom;
            pb_stream.TabIndex = 0;
            pb_stream.TabStop = false;
            // 
            // stream
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 405);
            Controls.Add(pb_stream);
            Margin = new Padding(3, 2, 3, 2);
            Name = "stream";
            Text = "stream";
            ((System.ComponentModel.ISupportInitialize)pb_stream).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pb_stream;
    }
}