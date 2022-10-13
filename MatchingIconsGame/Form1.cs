using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingIconsGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;

        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N",",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w","z","z"
        };

        int clock;
        string elepsedTime;

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
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
           
            
           
            if (timer1.Enabled == true)
            {
                return;
            }

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                //clickedLabel.ForeColor = Color.Black;

                if(firstClicked == null)
                {

                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                checkForWinner();
               
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;

                    return;
                }
                 timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;

        }
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (clock != 0)
            {
                clock += 1;
                stopWatch.Text = clock + " Sec";
                elepsedTime = stopWatch.Text;
            }
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            clock = 1;
            stopWatch.Text = "0 Sec";
            timer2.Start();
        }
    }
}
