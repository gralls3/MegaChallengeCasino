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
        Random rnd = new Random(); //Used to randomly grab slot images from above array
        Decimal playerBalance = 100; //Used to keep track of player $ balance
        Decimal bet = 0;
        Decimal multiplier = 0;
        Decimal winnings = 0;
        String bar = "Images/Bar.png";
        String bell = "Images/Bell.png";
        String cherry = "Images/Cherry.png";
        String clover = "Images/Clover.png";
        String diamond = "Images/Diamond.png";
        String horseshoe = "Images/HorseShoe.png";
        String lemon = "Images/Lemon.png";
        String orange = "Images/Orange.png";
        String plum = "Images/Plum.png";
        String seven = "Images/Seven.png";
        String strawberry = "Images/Strawberry.png";
        String watermellon = "Images/Watermellon.png";

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
                displayBalance(playerBalance);
            }
        }

        private void displayBalance(Decimal playerBalance)
        {
            moneyLabel.Text = String.Format("{0:C}", playerBalance);
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            generateAllImages();
            determineWinLoss();
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

        private void determineWinLoss()
        {//If image1 is bar, lose. If cherry, x2. If 7, x100.
            bet = decimal.Parse(betTextBox.Text);
            if (slotImage1.ImageUrl == bar//if any bars, x0
                || slotImage2.ImageUrl == bar
                || slotImage3.ImageUrl == bar)
            {
                multiplier = 0;
            }
            else if ((slotImage1.ImageUrl == cherry//if cherry in 1 or,
                && slotImage2.ImageUrl != cherry
                && slotImage3.ImageUrl != cherry)
                || (slotImage1.ImageUrl != cherry
                && slotImage2.ImageUrl == cherry//or cherry in 2 or,
                && slotImage3.ImageUrl != cherry)
                || (slotImage1.ImageUrl != cherry
                && slotImage2.ImageUrl != cherry
                && slotImage3.ImageUrl == cherry))//or cherry in 3, x2
            {
                multiplier = 2;
            }
            else if ((slotImage1.ImageUrl == cherry //if cherry in 1
              && slotImage2.ImageUrl == cherry//and 2, or
              && slotImage3.ImageUrl != cherry)
              || (slotImage1.ImageUrl == cherry//if cherry in 1
              && slotImage2.ImageUrl != cherry
              && slotImage3.ImageUrl == cherry)//and 3, or
              || (slotImage1.ImageUrl != cherry
              && slotImage2.ImageUrl == cherry//if cherry in 2
              && slotImage3.ImageUrl == cherry))//and 3, x3
            {
                multiplier = 3;
            }
            else if ((slotImage1.ImageUrl == cherry//if cherry in all 3,
              && slotImage2.ImageUrl == cherry//x4
              && slotImage3.ImageUrl == cherry))
            {
                multiplier = 4;
            }
            else if (slotImage1.ImageUrl == seven//if seven in all 3,
              && slotImage2.ImageUrl == seven//x100
              && slotImage3.ImageUrl == seven)
            {
                multiplier = 100;
            }
            else multiplier = 0;

            winnings = bet * multiplier;
            displayBetResult(bet, winnings);
        }

        private void displayBetResult(decimal bet, decimal winnings)
        {
            resultLabel.Text = String.Format("You bet {0:C} and won {1:C}.",bet, winnings);
            calculateBalance(winnings, playerBalance, bet);
        }

        private void calculateBalance(decimal winnings, decimal playerBalance, decimal bet)
        {
            playerBalance = (playerBalance + winnings) - bet;
            displayBalance(playerBalance);
        }
    }
}