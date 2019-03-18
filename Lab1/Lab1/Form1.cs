using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString("Frank Yang", Font, Brushes.Black, 100, 20);

            int x=1;

            for(int i=1;i<17;i++)
            {
                x = x*2;
                
                g.DrawString(i.ToString() + " " + x.ToString(), Font, Brushes.Black, 100, 87 + 13 * i);
            }
        }
    }
}
