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
    public partial class Form0 : Form
    {

        Form f1;
        private string naam;

        public Form0()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            naam = textBox1.Text;
            f1 = new Form1(naam);
            Hide();
            f1.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                naam = textBox1.Text;
                f1 = new Form1(naam);
                f1.Show();
                Hide();
            }
        }
    }
}
