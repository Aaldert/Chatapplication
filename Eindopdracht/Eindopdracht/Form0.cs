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

        public Form0(TcpConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
			OpenMainForm();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
			if ((Keys)e.KeyChar == Keys.Enter)
				OpenMainForm();
        }

		private void OpenMainForm()
		{
			if (textBox1.Text != null)
			{
				String naam = textBox1.Text;
				textBox1.Clear();
				connection.SendUsername(naam);
				Form main_form = new Form1(connection);
				Hide();
				main_form.Show();
			}
		}
    }
}
