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
            string s = textBox1.Text;

            s = s.Trim();
            Console.WriteLine("String is: " + s);
            if (s == "")
            {
                textBox1.Clear();
            }
            else
            {
                richTextBox1.AppendText(s + "\n");
                textBox1.Clear();
            }
        }

    }
}
