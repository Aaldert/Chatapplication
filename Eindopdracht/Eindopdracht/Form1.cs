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
        private  TcpConnection _connection;

        public Form1(TcpConnection _connection)
        {
            this._connection = _connection;
            InitializeComponent();

            _connection.IncomingChatmessageEvent += new TcpConnection.ChatmassegeDelegate(textToevoegen);
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
            if (textBox1.Text != null)
            {
                String data = textBox1.Text;
                textBox1.Clear();
                _connection.SendChatMessage(data);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter)
            {
                if (textBox1.Text != null)
                {
                    String data = textBox1.Text;
                    textBox1.Clear();            
                    _connection.SendChatMessage(data);
                }
            }
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                Close();
            }
        }

        private void textToevoegen(string[] data)
        {
            string bericht = data[1];
            bericht = bericht.Trim();
            if (bericht.StartsWith("\0"))
            {
                richTextBox1.Invoke((MethodInvoker)delegate ()
                {
                    textBox1.Clear();
                });
            }
            else
            {
                richTextBox1.Invoke((MethodInvoker)delegate ()
                {
                    string finalMessage = "\r\n" + data[0] + ":\t" + bericht;
                    richTextBox1.AppendText(finalMessage);
                    textBox1.Clear();
                });
            }
        }

    }
}
