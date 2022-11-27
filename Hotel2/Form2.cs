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
    public partial class Form2 : Form
    {

        int localPort;
        UdpClient udpClient = new UdpClient();
        int i= 0;
        
       
        public Form2(int i)
        {
            InitializeComponent();  
            this.i=i;
        }
 
        public void Send(int i)
        {
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(i.ToString());
                udpClient.Send(data, data.Length, new IPEndPoint(ipAddr, 11000));           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string Get()
        {
            string results = "";
            try
            {
                IPEndPoint RemoteIpEndPoint = null;
                byte[] data = udpClient.Receive(ref RemoteIpEndPoint);
                results = Encoding.UTF8.GetString(data);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return results;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text.IndexOf("Забронировано") == -1)
            {
                Send(8);
                label1.Text = Get() + " на " + DateTime.Now.ToShortDateString();
            }


            //if (label1.Text != "Забронировано на " + DateTime.Now.ToShortDateString())
            //{ Send(8); }
            //else { label1.Text = "Забронировано на " + DateTime.Now.ToShortDateString(); }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                Random rng = new Random();
                localPort = rng.Next(999, 20000);
                udpClient = new UdpClient(localPort);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            switch (i)
            {
                case 1:
                    pictureBox1.Image = Image.FromFile(@"a1.jpg");
                    break;
                case 2:
                    pictureBox1.Image = Image.FromFile(@"a2.jpg");
                    break;
                case 3:
                    pictureBox1.Image = Image.FromFile(@"a3.jpg");
                    break;
                case 4:
                    pictureBox1.Image = Image.FromFile(@"a4.jpg");
                    break;
                case 5:
                    pictureBox1.Image = Image.FromFile(@"a5.jpg");
                    break;
                case 6:
                    pictureBox1.Image = Image.FromFile(@"a6.jpg");
                    break;
                case 7:
                    pictureBox1.Image = Image.FromFile(@"a7.jpg");
                    break;
            }
            Send(i);
            string s = Get();
            label1.Text = s + " на " + DateTime.Now.ToShortDateString();            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            udpClient.Close();
        }
    }
}
