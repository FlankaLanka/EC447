using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private int x;
        private int y;
        private ArrayList coordinates = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                Point p = new Point(x, y);
                this.coordinates.Add(p);
                this.Invalidate();
            }

            if(e.Button == MouseButtons.Right)
            {
                this.coordinates.Clear();
                this.Invalidate();
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics;
            Pen pen = new Pen(Brushes.Black);
            int i=0;
            foreach (Point p in this.coordinates)
            {

                if (i == 0)
                {
                    g.FillEllipse(Brushes.Black, p.X - 5 / 2, p.Y - 5 / 2, 5, 5);
                    i++;
                }

                else
                {
                    g.FillEllipse(Brushes.Black, p.X - 5 / 2, p.Y - 5 / 2, 5, 5);
                    g.DrawLine(pen, (Point)coordinates[i], (Point)coordinates[i-1]);
                    i++;
                }

            }
           
        }

        
    }


}
