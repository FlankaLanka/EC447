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

namespace Lab3
{
    public partial class Form1 : Form
    {

        private int x, x2;
        private int y, y2;
        public List<Marker> coordinates = new List<Marker>();

        public class Marker
        {
            public Point p;
            public int isRed;
            public Marker(Point po)
            {
                isRed = 0;
                p = new Point(po.X, po.Y);
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                Point p = new Point(x, y);
                Marker marks = new Marker(p);
                this.coordinates.Add(marks);
                this.Invalidate();
            }

            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i <= this.coordinates.Count - 1; i++)
                {
                    x2 = e.X;
                    y2 = e.Y;
                    Point p = new Point(x2, y2);
                    Point p2 = this.coordinates[i].p;

                    if (p.X >= p2.X - 10 && p.X <= p2.X + 10 && p.Y >= p2.Y - 10 && p.Y <= p2.Y + 10)
                    {
                        if (this.coordinates[i].isRed == 1)
                        {
                            this.coordinates.RemoveAt(i);
                        }

                        else
                        {
                            this.coordinates[i].isRed = 1;
                        }
                        break;
                    }

                }
                this.Invalidate();
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen = new Pen(Brushes.Black);
            int i = 0;
            foreach (Marker marks in this.coordinates)
            {

                if (i == 0)
                {
                    if (marks.isRed == 0)
                    {
                        e.Graphics.FillEllipse(Brushes.Black, marks.p.X - 10, marks.p.Y - 10, 20, 20);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(Brushes.Red, marks.p.X - 10, marks.p.Y - 10, 20, 20);
                    }

                    i++;
                }

                else
                {
                    if (marks.isRed == 0)
                    {
                        e.Graphics.FillEllipse(Brushes.Black, marks.p.X - 10, marks.p.Y - 10, 20, 20);
                        e.Graphics.DrawLine(pen, coordinates[i].p, coordinates[i - 1].p);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(Brushes.Red, marks.p.X - 10, marks.p.Y - 10, 20, 20);
                        e.Graphics.DrawLine(pen, coordinates[i].p, coordinates[i - 1].p);
                    }
                    i++;
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.coordinates.Clear();
            this.Invalidate();
        }

    }
}