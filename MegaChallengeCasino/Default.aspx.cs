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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                slotImage1.ImageUrl = "Images/Bar.png";
                slotImage2.ImageUrl = "Images/Bar.png";
                slotImage3.ImageUrl = "Images/Bar.png";
            }
        }

        String[] imageURLs ={
            "Images/Bell.png", "Images/Clover.png", "Images/Diamond.png",
            "Images/HorseShoe.png", "Images/Lemon.png", "Images/Orange.png",
            "Images/Plum.png", "Images/Strawberry.png", "Images/Watermellon.png"};
        Random rnd = new Random();

        protected void leverButton_Click(object sender, EventArgs e)
        {
            generateImages();
        }

        private void generateImages()
        {
            generateImage1();
            generateImage2();
            generateImage3();
        }

        private void generateImage1()
        {
            int index = rnd.Next(0, imageURLs.Length);
            slotImage1.ImageUrl = imageURLs[index];
        }

        private void generateImage2()
        {
            int index = rnd.Next(0, imageURLs.Length);
            slotImage2.ImageUrl = imageURLs[index];
        }

        private void generateImage3()
        {
            int index = rnd.Next(0, imageURLs.Length);
            slotImage3.ImageUrl = imageURLs[index];
        }
    }
}