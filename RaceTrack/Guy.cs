using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTrack
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        // The last two fields are the guy’s GUI controls on the form
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            // Set my label to my bet’s description, and the label on my
            // radio button to show my cash ("Joe has 43 bucks")
            this.MyRadioButton.Text = this.Name + " has " + Cash + " bucks.";
            this.MyLabel.Text = this.MyBet.GetDescription();
        }

        public void ClearBet()
        {
            this.PlaceBet(0, 0);
            UpdateLabels();
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            // Place a new bet and store it in my bet field
            // Return true if the guy had enough money to bet
            if (BetAmount < 5 && BetAmount != 0)
            {
                MessageBox.Show("The minimum bet is 5 bucks, buddy!");
                return false;

            }
            if (BetAmount <= Cash)
            {
                this.MyBet.Amount = BetAmount;
                this.MyBet.Dog = DogToWin;
                this.MyBet.Bettor = this;
                UpdateLabels();
                if (BetAmount != 0)
                    MessageBox.Show("Thank you for betting, mate. You picked a winner!");
                return true;
            }
            MessageBox.Show("You don't have enough money to cover your bet...");
            return false;
        }

        public void Collect(int Winner)
        {
            // Ask my bet to pay out, clear my bet, and update my labels
            this.Cash += MyBet.PayOut(Winner);
            ClearBet();
        }

    }
}
