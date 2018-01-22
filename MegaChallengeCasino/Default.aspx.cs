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
            //When lever button pressed, generate images
            //Then calculate win/loss
            //Display result to player
            generateImage1();
        }

        private void generateImage1()
        {
            int index = rnd.Next(0, imageURLs.Length);
            slotImage1.ImageUrl = imageURLs[index];
            string image1 = slotImage1.ImageUrl.ToString();
            calculateBetResult(image1);
        }

        private void calculateBetResult(string image1)
        {//If image1 is bar, lose. If cherry, x2. If 7, x100.
            bet = decimal.Parse(betTextBox.Text);
            if (image1 == bar)
            {
                multiplier = 0;
            }
            else if (image1 == cherry)
            {
                multiplier = 2;
            }
            else if (image1 == seven)
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