using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrollCMD
{
    public class MouseWiggler
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        private System.Windows.Forms.Timer wiggleTimer;
        private int wiggleCount = 0;
        private int wiggleLimit;
        private int wiggleDistance;
        private int initialX;
        private int initialY;
        private Random random;

        public MouseWiggler(int interval = 100, int wiggleLimit = 20, int wiggleDistance = 10)
        {
            this.wiggleLimit = wiggleLimit;
            this.wiggleDistance = wiggleDistance;
            random = new Random();

            // Initialize the Timer
            wiggleTimer = new System.Windows.Forms.Timer();
            wiggleTimer.Interval = interval;
            wiggleTimer.Tick += WiggleMouse;
        }

        public void StartWiggle()
        {
            wiggleCount = 0;
            // Capture the initial mouse position
            initialX = Cursor.Position.X;
            initialY = Cursor.Position.Y;
            wiggleTimer.Start();
        }

        private void WiggleMouse(object sender, EventArgs e)
        {
            if (wiggleCount >= wiggleLimit)
            {
                wiggleTimer.Stop();
                // Ensure the mouse returns to the initial position
                SetCursorPos(initialX, initialY);
                return;
            }

            // Generate a random position within a square area around the initial position
            int randomX = initialX + random.Next(-wiggleDistance, wiggleDistance + 1);
            int randomY = initialY + random.Next(-wiggleDistance, wiggleDistance + 1);

            // Set the new mouse position
            SetCursorPos(randomX, randomY);

            // Increment the wiggle count
            wiggleCount++;
        }
    }
}
