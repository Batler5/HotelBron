using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Hotel2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        public int i = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            i = 1;
            Form2 form = new Form2(i);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(2);
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(3);
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(4);
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(5);
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(6);
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(7);
            form.ShowDialog();
        }
    }
}
