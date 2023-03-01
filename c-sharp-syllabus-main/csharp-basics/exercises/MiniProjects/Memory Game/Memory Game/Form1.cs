using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private List<string> icons = new List<string>() { 
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        private Label firstClicked = null;
        private Label secondClicked = null;
        
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void CheckForWinner()
        {
            foreach(var control in tableLayoutPanel1.Controls)
            {
                var iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }

            MessageBox.Show("You matched all icons!", "Congratulations!");
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                return;
            }
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                {
                    return;
                }

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return; 
                }
                
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                
                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                
                timer1.Start();
            }
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer1.Stop();
            try
            {
                firstClicked.ForeColor = firstClicked.BackColor;
                secondClicked.ForeColor = secondClicked.BackColor;
                firstClicked = null;
                secondClicked = null;
            }
            catch{}
        }
    }
}