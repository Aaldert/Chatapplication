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
        private TcpConnection connection;

        Form f1;

        public Form0(TcpConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if(textBox1.Text != null)
            {
                String naam = textBox1.Text;
                textBox1.Clear();
                connection.SendUsername(naam);
                f1 = new Form1(connection);
                Hide();
                f1.Show();
            }
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
