using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        int billion = 10, hundred = 10, hundredcopy = 10,  billioncopy = 10;
        bool isNum1 = true, isNum2 = true;
        String billionString, reversedString;


        public Form1()
        {
            
            InitializeComponent();
            this.Text = "Palindrome by Frank Yang";
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Find Numeric Palindromes", new Font("Arial", 25), Brushes.Black, 220, 40);

            e.Graphics.DrawString("Enter a starting integer (0-1,000,000,000):", new Font("Arial", 10), Brushes.Black, 100, 100);

            e.Graphics.DrawString("Enter count (1-100):", new Font("Arial", 10), Brushes.Black, 500, 100);

            /*if (isNum1 == false || isNum2 == false)
            {
                e.Graphics.DrawString("Please enter a positive integer within range!!!", new Font("Arial", 10), Brushes.Black, 200, 400);
            }*/
            if ((billioncopy > 1000000000) || (billioncopy < 0) || (hundredcopy > 100) || (hundredcopy < 1) || isNum1 == false || isNum2 == false)
            {
                e.Graphics.DrawString("Please enter a positive integer within range", new Font("Arial", 10), Brushes.Black, 300, 400);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isNum1 = int.TryParse(billionBox.Text, out billion);
            isNum2 = int.TryParse(hundredBox.Text, out hundred);
            listBox1.Items.Add(billion.ToString());
            listBox1.Items.Add(hundred.ToString());
            billioncopy = billion;
            hundredcopy = hundred;

            if (billion <= 1000000000 && billion >= 0 && hundred <= 100 && hundred >= 1 && isNum1 && isNum2)
            {
                listBox1.Items.Clear();

            while(hundred != 0)
                {
                    billionString = billion.ToString();

                    for (int j = 0; j < billionString.Length; j++)
                    {
                        reversedString = billionString[j] + reversedString;
                    }

                   if (billionString == reversedString)
                    {
                        listBox1.Items.Add(billionString);
                        hundred--;
                    }


                    billion++;
                    reversedString = "";
                }
            }
            else
            {
                listBox1.Items.Clear();
            }

            this.Invalidate();
        }
    }


}
