using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingIconsGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "@", "@","#", "#", "$", "$",
            "%", "%", "^", "^", "&", "&","*","*"
        };

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
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                clickedLabel.ForeColor = Color.Black;
            }
        }
    }
}
