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

        Form f0 = new Form0();
        private string naam;
        public Form1(string naam)
        {
            this.naam = naam;
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                InitializeComponent();
            }
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                Close();
            }
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
            if (s == "")
            {
                textBox1.Clear();
            }
            else
            {
                richTextBox1.AppendText(naam + ": " + s + "\n");
                textBox1.Clear();
            }
        }

    }
}
