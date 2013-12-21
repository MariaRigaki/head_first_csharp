using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTrack
{
    public partial class Form1 : Form
    {
        private Greyhound[] GreyhoundArray = new Greyhound[4];
        private Guy[] GuyArray = new Guy[3];
        private Random MyRandomizer = new Random();
        public Form1()
        {
            InitializeComponent();
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = dogBox1,
                StartingPosition = raceTrackPictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - dogBox1.Width,
                Randomizer = MyRandomizer,
            };
            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = dogBox2,
                StartingPosition = raceTrackPictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - dogBox2.Width,
                Randomizer = MyRandomizer,
            };
            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = dogBox3,
                StartingPosition = raceTrackPictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - dogBox3.Width,
                Randomizer = MyRandomizer,
            };
            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = dogBox4,
                StartingPosition = raceTrackPictureBox.Left,
                RacetrackLength = raceTrackPictureBox.Width - dogBox4.Width,
                Randomizer = MyRandomizer,
            };

            GuyArray[0] = new Guy() { Name = "Joe", Cash = 150, MyLabel = joeBetLabel, MyRadioButton = joeRadioButton, MyBet = new Bet() };
            GuyArray[1] = new Guy() { Name = "Bob", Cash = 150, MyLabel = bobBetLabel, MyRadioButton = bobRadioButton, MyBet = new Bet() };
            GuyArray[2] = new Guy() { Name = "Al", Cash = 150, MyLabel = alBetLabel, MyRadioButton = alRadioButton, MyBet = new Bet() };

            for (int i = 0; i < 3; i++)
            {
                GuyArray[i].PlaceBet(0, 0);
            }
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                GreyhoundArray[i].TakeStartingPosition();
            }
            timer1.Start();
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                GuyArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            } 
            else if (bobRadioButton.Checked)
            {
                GuyArray[1].PlaceBet((int) numericUpDown1.Value, (int) numericUpDown2.Value);
            } 
            else 
            {
                GuyArray[2].PlaceBet((int) numericUpDown1.Value, (int) numericUpDown2.Value);
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Joe";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Bob";
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Al";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("The winner is " + (i + 1));
                    for (int j = 0; j < 3; j++)
                    {
                        GuyArray[j].Collect(i + 1);
                    }
                    break;
                }
            }
        }
    }
}
