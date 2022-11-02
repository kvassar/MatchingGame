using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MatchingIconsGame
{
    public partial class Form1 : Form
    {
        // variables will be used to keep track if the users guess is the first or second.
        Label firstClicked = null;
        Label secondClicked = null;
        // Variable will be used to keep track of the seconds that have passed.
        int clock;
        // New list of possiable character that will be on the diffrent "cards". Because I am using the Webdings font the character turn into diffrent icons.
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N",",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w","z","z"
        };
        // initialize project and than givs each spot on the table the "cards" an icon using the assignIconsToSquares method.
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
            
        }
        // Assigns an icon to every spot on the tableLayoutPanel or "cards"
        private void AssignIconsToSquares()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
                {
                Label iconsLabel = control as Label;
                if (iconsLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconsLabel.Text = icons[randomNumber];

                    iconsLabel.ForeColor = iconsLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void Label_click(object sender, EventArgs e)
        {
            // checks if the timer that shows the elapesed time is started
            if (timer2.Enabled == true)
            {
                // checks if this is the second click by making sure that timer1 is not started already.
                if (timer1.Enabled == true)
                {
                    return;
                }
                // What is the clickedLabel
                // This will only run if it is the first click
                Label clickedLabel = sender as Label;

                if (clickedLabel != null)
                {
                    if (clickedLabel.ForeColor == Color.Black)
                        return;
                    // because firstclicked does no have a value it will assign firstclick a value and set the for color to black so you can see the icon 
                    if (firstClicked == null)
                    {

                        firstClicked = clickedLabel;
                        firstClicked.ForeColor = Color.Black;

                        return;
                    }
                    // This only runs if it is the second click.
                    // reveals the icon and checks if you have matched all of the icons
                    secondClicked = clickedLabel;
                    secondClicked.ForeColor = Color.Black;
                    checkForWinner();
                    /* checks if the text matches on the clicked boxes if they do the back color randomly changes to the same color for both.
                     * The first clicked and second clicked variables values are both set back to null.
                     */
                    if (firstClicked.Text == secondClicked.Text)
                    {
                        Random rnd = new Random();
                        int num = rnd.Next(255);
                        int num2 = rnd.Next(255);
                        int num3 = rnd.Next(255);
                        int num4 = rnd.Next(255);
                        firstClicked.BackColor = Color.FromArgb(num, num2, num3, num4);
                        secondClicked.BackColor = Color.FromArgb(((Color)firstClicked.BackColor).ToArgb());
                        firstClicked = null;
                        secondClicked = null;

                        return;
                    }
                    // will run if it is the second click and the two revealed icons do not match.
                    timer1.Start();
                }
            }
        }
        // Stops the timer and sets the two mismatched icons so that they are hidden.
        // It also resets the values of firstclicked and secondclicked to null so the user can click two new spots. 
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;

        }
        // looks at every spot in the table and makes sure that the iconLabel has a value and that the icon is not the same as the back color
        // If these two restrictions are satisfide it will end the elapsed timer and a message box will tell the user that they have won.
        private void checkForWinner()
        { 
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            timer2.Stop();
            MessageBox.Show("You matched all the icons!", "Congratulations and well done!");
                Close();
        }
        // If the start button is clicked than the timer will start
        private void timer2_Tick(object sender, EventArgs e)
        {
            string elepsedTime;
            if (clock != 0)
            {
                clock += 1;
                stopWatch.Text = clock + " Sec";
                elepsedTime = stopWatch.Text;
            }
            
        }
        // sets the clock variable to one when the button is clicked.
        private void startButton_Click(object sender, EventArgs e)
        {
            clock = 1;
            stopWatch.Text = "0 Sec";
            timer2.Start();
        }
    }
}
