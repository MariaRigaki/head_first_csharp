using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTrack
{
    class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {

            int step = this.Randomizer.Next(3);
            if (step < 1)
                step = 1;
            this.MyPictureBox.Left += step* MyPictureBox.Width;
            this.Location += step * MyPictureBox.Width;
            if (this.Location > this.RacetrackLength)
                return true;
            else
                return false;
        }

        public void TakeStartingPosition()
        {
            // Reset my location to 0 and my PictureBox to starting position
            this.Location = 0;
            this.MyPictureBox.Left = this.StartingPosition;
        }
    }
}
