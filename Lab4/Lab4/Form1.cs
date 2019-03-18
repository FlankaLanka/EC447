using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Eight Queens by Frank Yang";
        }

        //This is a field in your form class

        private bool[,] board = new bool[8, 8];

        //This is the recursive solution
        private bool PlaceQueen(int col)
        {
            for (int row = 0; row <= 7; ++row)
            {
                if (IsSafe(col, row))
                {
                    board[col, row] = true; //place queen
                    if (col == 7)
                        return true;    //we have a solution
                    else
                    {
                        if (PlaceQueen(col + 1))    //continue to next column
                            return true;
                        else
                            board[col, row] = false;   //retract move and look for another safe square
                    }
                }
            }
            return false;   //no safe columns left so backtrack
        }

        private bool IsSafe(int col, int row)
        {
            int n = col, m = row;
            
            for(int i = 0; i< 8; i++)
            {
                if(board[i,row])
                {
                    return false;
                }

            }

            for (int i = 0; i < 8; i++)
            {

                if (board[col, i])
                {
                    return false;
                }
            }

             while(col >= 0 && row <= 7)
             {
                 if (board[col, row])
                 {
                     return false;
                 }
                 col--;
                 row++;
             }

             col = n;
             row = m;

             while (col >= 0 && row >= 0)
             {
                 if (board[col, row])
                 {
                     return false;
                 }
                 col--;
                 row--;
             }

             col = n;
             row = m;

             while (col <= 7 && row <= 7)
             {
                 if (board[col, row])
                 {
                     return false;
                 }
                 col++;
                 row++;
             }

             col = n;
             row = m;

             while (col <= 7 && row >= 0)
             {
                 if (board[col, row])
                 {
                     return false;
                 }
                 col++;
                 row--;
             }
             

            return true;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            //This code goes in your button's event handler
            board = new bool[8, 8]; //clear board
                                    //Set row in column 0 from numeric up/down control
            board[0, (int)StartRow.Value] = true;
            //board[0, 2] = true;
            PlaceQueen(1);  //start at column 1
            Invalidate();   //draw board

           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blk = new Pen(Color.Black);
            Pen Wte = new Pen(Color.White);

            g.DrawString("Select Starting Row:", DefaultFont, Brushes.Black, 120, 30);

            g.DrawRectangle(blk, 100, 100, 400, 400);

            int x = 100, y = 100;

            for(int i = 0; i<8;i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if((i+j) % 2 != 0)
                    {
                        g.FillRectangle(Brushes.Black, x, y, 50, 50);
                    }

                    x = x + 50;
                }

                y = y + 50;
                x = 100;
            }

            int xQ = 100, yQ = 100;

            for(int i = 0; i<8;i++)
            {
                for (int j = 0; j<8;j++)
                {
                    if (board[j,i])
                    {
                        if((i+j) % 2 != 0)
                        {
                            g.DrawString("Q",new Font("Arial",30,FontStyle.Bold), Brushes.White, xQ, yQ);
                        }
                        else
                        {
                            g.DrawString("Q", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, xQ, yQ);
                        }


                        
                    }
                    xQ = xQ + 50;

                }
                yQ = yQ + 50;
                xQ = 100;
            }

        }



    }
}
