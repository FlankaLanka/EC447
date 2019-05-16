using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "File Encrypt/Decrypt";
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if(keyTextBox.Text == "")
            {
                MessageBox.Show("Please Enter a Key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!File.Exists(fileTextBox.Text))
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(File.Exists(fileTextBox.Text))
            {
                Encrypt();
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if(keyTextBox.Text == "")
            {
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(fileTextBox.Text.Length < 4)
            {
                MessageBox.Show("Not a .enc file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(fileTextBox.Text.Substring(fileTextBox.Text.Length - 4) != ".enc")
            {
                MessageBox.Show("Not a .enc file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!File.Exists(fileTextBox.Text))
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (File.Exists(fileTextBox.Text))
            {
                Decrypt();
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileTextBox.Text = openFileDialog1.FileName;
            }
        }


        public void Encrypt()
        {
            string fileName = @fileTextBox.Text;

            string fileNameOut = fileName + ".enc";
            //Path.GetFileName(fileName) + ".enc";

            if (File.Exists(fileNameOut))
            {
                if (MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }


            FileStream fin = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(fileNameOut, FileMode.Create, FileAccess.Write);


            int rbyte;
            int pos = 0;    //position in key string
            int length = keyTextBox.Text.Length; //length of key
            Console.WriteLine(length);
            byte kbyte, ebyte; //encrypted byte

            while ((rbyte = fin.ReadByte()) != -1)
            {
                kbyte = (byte)keyTextBox.Text[pos];
                
                ebyte = (byte)(rbyte ^ kbyte);
                fout.WriteByte(ebyte);
                Console.WriteLine(ebyte);
                ++pos;
                if (pos == length)
                    pos = 0;
            }

            fin.Close();
            fout.Close();

            MessageBox.Show("Operation Completed Successfully");
        }

        public void Decrypt()
        {
            string fileName = @fileTextBox.Text;

            string fileNameOut = fileName.Substring(0, fileName.Length - 4);
            //Path.GetFileName(fileName) + ".enc";

            if (File.Exists(fileNameOut))
            {
                if (MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }


            FileStream fin = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(fileNameOut, FileMode.Create, FileAccess.Write);


            int rbyte;
            int pos = 0;    //position in key string
            int length = keyTextBox.Text.Length; //length of key
            Console.WriteLine(length);
            byte kbyte, ebyte; //encrypted byte

            while ((rbyte = fin.ReadByte()) != -1)
            {
                kbyte = (byte)keyTextBox.Text[pos];

                ebyte = (byte)((rbyte ^ kbyte));
                fout.WriteByte(ebyte);
                Console.WriteLine(ebyte);
                ++pos;
                if (pos == length)
                    pos = 0;
            }

            fin.Close();
            fout.Close();

            MessageBox.Show("Operation Completed Successfully");
        }
    }
}
