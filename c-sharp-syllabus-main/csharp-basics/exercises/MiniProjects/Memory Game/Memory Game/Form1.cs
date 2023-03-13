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
        private Random _random = new Random();
        private List<string> _icons = new List<string>() { 
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        private Label _firstClicked = null;
        private Label _secondClicked = null;
        
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
                    int randomNumber = _random.Next(_icons.Count);
                    iconLabel.Text = _icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    _icons.RemoveAt(randomNumber);
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

                if (_firstClicked == null)
                {
                    _firstClicked = clickedLabel;
                    _firstClicked.ForeColor = Color.Black;
                    return; 
                }
                
                _secondClicked = clickedLabel;
                _secondClicked.ForeColor = Color.Black;
                
                CheckForWinner();

                if (_firstClicked.Text == _secondClicked.Text)
                {
                    _firstClicked = null;
                    _secondClicked = null;
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
                _firstClicked.ForeColor = _firstClicked.BackColor;
                _secondClicked.ForeColor = _secondClicked.BackColor;
                _firstClicked = null;
                _secondClicked = null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}