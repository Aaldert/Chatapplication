using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eindopdracht
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textToevoegen();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter)
            {
                textToevoegen();
            }
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                Close();
            }
        }

        private void textToevoegen()
        {
            string s = textBox2.Text;
            bool a = false;
            s.ToCharArray();


            bool loop = true;

            while (loop)
            {
                if (textBox2.Text == "")
                {
                    a = false;
                }
                foreach (char c in s)
                {
                    if (c.Equals(" "))
                    {
                        a = false;
                    }
                    else
                    {
                        a = true;
                        loop = false;
                    }

                }
            }

            if (a == false)
            {
                textBox2.Clear();
            }
            if (a == true)
            {
                richTextBox1.AppendText(textBox2.Text + "\n");
                textBox2.Clear();
            }
        }

    }
}
