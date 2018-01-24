using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        //Global variables:
        Random rnd = new Random();//Used to randomly grab slot images from above array
        String bar = "Images/Bar.png";
        String cherry = "Images/Cherry.png";
        String seven = "Images/Seven.png";

        String[] imageURLs ={
            //Create Array of URLs of slot images
            "Images/Bar.png", "Images/Bell.png", "Images/Cherry.png", "Images/Clover.png",
            "Images/Diamond.png", "Images/HorseShoe.png", "Images/Lemon.png",
            "Images/Orange.png", "Images/Plum.png", "Images/Seven.png", "Images/Strawberry.png",
            "Images/Watermellon.png" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            //If this is first pageload, set images to bars,
            //then set initial player balance and display it
            {
                slotImage1.ImageUrl = bar;
                slotImage2.ImageUrl = bar;
                slotImage3.ImageUrl = bar;
                playerBalance = 100;
                moneyLabel.Text = String.Format("{0}", 100);
            }
        }

        Decimal playerBalance; //Used to keep track of player $ balance

        protected void leverButton_Click(object sender, EventArgs e)
        {
            generateAllImages();
            determineMultiplier();
        }

        private void generateAllImages()
        {
            generateImage1();
            generateImage2();
            generateImage3();
        }

        private void generateImage1()
        {
            generateImageURL(out string imageURLvar);
            slotImage1.ImageUrl = imageURLvar;
        }

        private void generateImage2()
        {
            generateImageURL(out string imageURLvar);
            slotImage2.ImageUrl = imageURLvar;
        }

        private void generateImage3()
        {
            generateImageURL(out string imageURLvar);
            slotImage3.ImageUrl = imageURLvar;
        }

        private void generateImageURL(out string imageURLvar)
        {
            int index = rnd.Next(0, imageURLs.Length);
            imageURLvar = imageURLs[index];
        }

        private void determineMultiplier()
        {
            decimal bet = decimal.Parse(betTextBox.Text);
            decimal multiplier = 0;
            if (slotImage1.ImageUrl == bar//if any bars, x0
                || slotImage2.ImageUrl == bar
                || slotImage3.ImageUrl == bar)
            {
                multiplier = 0;
            }
            else if ((slotImage1.ImageUrl == cherry//if cherry in 1 only or,
                && slotImage2.ImageUrl != cherry
                && slotImage3.ImageUrl != cherry)
                || (slotImage1.ImageUrl != cherry
                && slotImage2.ImageUrl == cherry//or cherry in 2 only or,
                && slotImage3.ImageUrl != cherry)
                || (slotImage1.ImageUrl != cherry
                && slotImage2.ImageUrl != cherry
                && slotImage3.ImageUrl == cherry))//or cherry in 3 only, x2
            {
                multiplier = 2;
            }
            else if ((slotImage1.ImageUrl == cherry //if cherry in 1
              && slotImage2.ImageUrl == cherry//and 2 only, or
              && slotImage3.ImageUrl != cherry)
              || (slotImage1.ImageUrl == cherry//if cherry in 1
              && slotImage2.ImageUrl != cherry
              && slotImage3.ImageUrl == cherry)//and 3 only, or
              || (slotImage1.ImageUrl != cherry
              && slotImage2.ImageUrl == cherry//if cherry in 2
              && slotImage3.ImageUrl == cherry))//and 3 only, x3
            {
                multiplier = 3;
            }
            else if ((slotImage1.ImageUrl == cherry
              && slotImage2.ImageUrl == cherry
              && slotImage3.ImageUrl == cherry))//if cherry in all 3, x4
            {
                multiplier = 4;
            }
            else if (slotImage1.ImageUrl == seven
              && slotImage2.ImageUrl == seven
              && slotImage3.ImageUrl == seven)//if seven in all 3, x100
            {
                multiplier = 100;
            }
            else multiplier = 0;

            calculateBalances(bet, multiplier);
        }

        private void calculateBalances(decimal bet, decimal multiplier)
        {
            //proper way to calc balance after implementing ViewSate:
                //balance -= bet;
                //balance += winnings;
                //ViewState["balance"] = balance;
            decimal winnings = bet * multiplier;
            //playerBalance = (playerBalance - bet) + winnings;
            decimal balance = decimal.Parse(moneyLabel.Text);
            balance = (balance - bet) + winnings;
            moneyLabel.Text = balance.ToString();
            displayBetResult(bet, winnings);
            //displayBalance(playerBalance);
        }
        /*
        private void displayBalance(Decimal playerBalance)
        {
            moneyLabel.Text = String.Format("{0:C}", playerBalance);
        }
        */
        private void displayBetResult(decimal bet, decimal winnings)
        {
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}.", bet, winnings);
        }
    }
}