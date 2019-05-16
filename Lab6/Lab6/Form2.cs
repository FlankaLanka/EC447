using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
            penColor.SelectedIndex = 0;
            fillColor.SelectedIndex = 0;
            penWidth.SelectedIndex = 0;
        }

        public bool outl = true, fil = false, outlC = true, filC = false;
        public int pC = 0, bC = 0, pW = 0, pCC = 0, bCC = 0, pWC = 0;


        private void penColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            pC = penColor.SelectedIndex;
        }

        private void SettingsDialog_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Pen Color                      Fill Color                       Pen Width", new Font("Arial", 8), Brushes.Black, 30, 40);
        }

        private void fillColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            bC = fillColor.SelectedIndex;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if(outlC == true)
            {
                outlineBox.Checked = true;
            }
            else
            {
                outlineBox.Checked = false;
            }

            if(filC == true)
            {
                fillBox.Checked = true;
            }
            else
            {
                fillBox.Checked = false;
            }

            penWidth.SelectedIndex = pWC;
            penColor.SelectedIndex = pCC;
            fillColor.SelectedIndex = bCC;

            this.Invalidate();
        }

        private void penWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            pW = penWidth.SelectedIndex;
        }

        private void outlineBox_CheckedChanged(object sender, EventArgs e)
        {
            if(outlineBox.Checked == true)
            {
                outl = true;
            }
            else
            {
                outl = false;
            }
        }

        private void fillBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fillBox.Checked == true)
            {
                fil = true;
            }
            else
            {
                fil = false;
            }
        }
    }
}
