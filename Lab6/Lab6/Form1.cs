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

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            this.Text = "Lab6";
        }

        public int penWidth = 1, rectX, rectY, rectH, rectW;
        public List <MyLRE> coordinates = new List<MyLRE>();
        public Point first, second;
        public bool drawNow = false;
        public Pen penColor = new Pen(Brushes.Black, 1);
        public Brush fillColor = Brushes.White;
        public bool fill = false, outline = true;
        SettingsDialog s = new SettingsDialog();



        public class MyLRE
        {
            public MyLRE()
            {

            }
            public virtual void draw(Graphics g)
            {

            }
        }

        public class MyLine : MyLRE
        {
            public Point pOne, pTwo;
            public Pen pColor;
            public MyLine(Point pO, Point pT, Pen penColor, int penWidth)
            {
                pOne = pO;
                pTwo = pT;
                pColor = new Pen(penColor.Color, penWidth);
            }

            public override void draw(Graphics g)
            {
                g.DrawLine(pColor, pOne, pTwo);
            }
        }

        public class MyRectangle : MyLRE
        {
            public Point pOne, pTwo;
            public Pen pColor;
            public Brush fColor;
            public int rectX, rectY, rectH, rectW;
            bool f, o;
            public MyRectangle(Point pO, Point pT, Pen penColor, Brush fillColor, int penWidth, bool fill, bool outline)
            {
                pOne = pO;
                pTwo = pT;
                pColor = new Pen(penColor.Color, penWidth);
                fColor = fillColor;
                f = fill;
                o = outline;
            }


            public override void draw(Graphics g)
            {
                rectX = (pOne.X < pTwo.X) ? pOne.X : pTwo.X;
                rectY = (pOne.Y < pTwo.Y) ? pOne.Y : pTwo.Y;
                rectW = Math.Abs(pTwo.X - pOne.X);
                rectH = Math.Abs(pTwo.Y - pOne.Y);
                if (f)
                {
                    g.FillRectangle(fColor, rectX, rectY, rectW, rectH);
                }
                if (o)
                {
                    g.DrawRectangle(pColor, rectX, rectY, rectW, rectH);
                }
            }
        }

        public class MyEllipse : MyLRE
        {
            public Point pOne, pTwo;
            public Pen pColor;
            public Brush fColor;
            public int rectX, rectY, rectH, rectW;
            public bool f, o;
            public MyEllipse(Point pO, Point pT, Pen penColor, Brush fillColor, int penWidth, bool fill, bool outline)
            {
                pOne = pO;
                pTwo = pT;
                pColor = new Pen(penColor.Color, penWidth);
                fColor = fillColor;
                f = fill;
                o = outline;
            }
            public override void draw(Graphics g)
            {
                rectX = (pOne.X < pTwo.X) ? pOne.X : pTwo.X;
                rectY = (pOne.Y < pTwo.Y) ? pOne.Y : pTwo.Y;
                rectW = Math.Abs(pTwo.X - pOne.X);
                rectH = Math.Abs(pTwo.Y - pOne.Y);
                if (f)
                {
                    g.FillEllipse(fColor, rectX, rectY, rectW, rectH);
                }
                if (o)
                {
                    g.DrawEllipse(pColor, rectX, rectY, rectW, rectH);
                }

            }

        }


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (coordinates.Any<MyLRE>())
            {
                coordinates.Clear();
            }
            this.panel1.Invalidate();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(coordinates.Any<MyLRE>())
            {
                coordinates.RemoveAt(coordinates.Count - 1);
            }
            this.panel1.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingButton_Click(object sender, EventArgs e)
        {

            if(s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outline = s.outl;
                fill = s.fil;
                penWidth = s.pW;

                s.outlC = outline;
                s.filC = fill;
                s.pWC = penWidth;
                s.pCC = s.pC;
                s.bCC = s.bC;


                if(s.pC == 0)
                {
                    penColor = new Pen(Brushes.Black, penWidth);
                }
                else if(s.pC == 1)
                {
                    penColor = new Pen(Brushes.Red, penWidth);
                }
                else if (s.pC == 2)
                {
                    penColor = new Pen(Brushes.Blue, penWidth);
                }
                else if (s.pC == 3)
                {
                    penColor = new Pen(Brushes.Green, penWidth);
                }



                if (s.bC == 0)
                {
                    fillColor = Brushes.White;
                }
                else if (s.bC == 1)
                {
                    fillColor = Brushes.Black;
                }
                else if (s.bC == 2)
                {
                    fillColor = Brushes.Red;
                }
                else if (s.bC == 3)
                {
                    fillColor = Brushes.Blue;
                }
                else if (s.bC == 4)
                {
                    fillColor = Brushes.Green;
                }
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (MyLRE myObject in this.coordinates)
            {
                myObject.draw(e.Graphics);
            }

            if (drawNow == true)
            {
                e.Graphics.FillEllipse(Brushes.Black, first.X - 5, first.Y - 5, 10, 10);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawNow == false)
            {
                first = new Point(e.X, e.Y);
                drawNow = true;
            }
            else
            {
                if((rectangleButton.Checked || ellipseButton.Checked) && fill == false && outline == false)
                {
                    MessageBox.Show("Fill or outline must be checked");
                }
                else
                {
                    second = new Point(e.X, e.Y);

                    if (lineButton.Checked)
                    {
                        this.coordinates.Add(new MyLine(first, second, penColor, penWidth));
                    }
                    else if (rectangleButton.Checked)
                    {
                        this.coordinates.Add(new MyRectangle(first, second, penColor, fillColor, penWidth, fill, outline));
                    }
                    else if (ellipseButton.Checked)
                    {
                        this.coordinates.Add(new MyEllipse(first, second, penColor, fillColor, penWidth, fill, outline));
                    }

                }

                drawNow = false;

            }

            this.panel1.Invalidate();
        }
    }
}
