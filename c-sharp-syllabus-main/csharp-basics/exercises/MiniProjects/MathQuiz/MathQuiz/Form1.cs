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

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int _addEnd1;
        private int _addEnd2;
        private int _minuend;
        private int _subtrahend;
        private int _multiplicand;
        private int _multiplier;
        private int _dividend;
        private int _divisor = 1;
        private int timeLeft;

        public void StartTheQuiz()
        {
            _addEnd1 = random.Next(51);
            _addEnd2 = random.Next(51);
            plusLeftLabel.Text = _addEnd1.ToString();
            plusRightLabel.Text = _addEnd2.ToString();
            sum.Value = 0;
            
            _minuend = random.Next(1, 101);
            _subtrahend = random.Next(1, _minuend);
            minusLeftLabel.Text = _minuend.ToString();
            minusRigthLabel.Text = _subtrahend.ToString();
            diff.Value = 0;
            
            _multiplicand = random.Next(2, 11);
            _multiplier = random.Next(2, 11);
            multiplyLeftLabel.Text = _multiplicand.ToString();
            multiplyRightLabel.Text = _multiplier.ToString();
            mult.Value = 0;
            
            _divisor = random.Next(2, 11);
            int temporaryQuotient = random.Next(2, 11);
            _dividend = _divisor * temporaryQuotient;
            divideLeftLabel.Text = _dividend.ToString();
            divideRightLabel.Text = _divisor.ToString();
            division.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        
        private bool CheckTheAnswer()
        {
            if ((_addEnd1 + _addEnd2 == sum.Value)
                && (_minuend - _subtrahend == diff.Value)
                && (_multiplicand * _multiplier == mult.Value)
                && (_dividend / _divisor == division.Value))
                return true;
            else
                return false;
        } 
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (CheckTheAnswer() && !startButton.Enabled)
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else if(!startButton.Enabled)
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = _addEnd1 + _addEnd2;
                diff.Value = _minuend - _subtrahend;
                mult.Value = _multiplicand * _multiplier;
                division.Value = _dividend / _divisor;
                startButton.Enabled = true;
            }
        }
    }
}