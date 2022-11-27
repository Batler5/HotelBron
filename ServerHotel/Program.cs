using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace ServerHotel
{
    internal class Program
    {
        static UdpClient udpClient = new UdpClient(11000);
        static string num = "";
        static string path = @"serv.txt";
        static IPEndPoint RemoteIpEndPoint = null;
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(20);
                    byte[] data = udpClient.Receive(ref RemoteIpEndPoint);
                    string results = Encoding.UTF8.GetString(data);
                    Console.WriteLine(results);                    
                    ReadWrite(results);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        static void Bron(string n)
        {
            string[] s = File.ReadAllLines(path);
            string[] g = new string[2];
            string[] s2 = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                g = s[i].Split(' ');
                if (g[0] != n)
                {
                    s2[i] = g[0] + " " + g[1];
                }
                else
                {
                    s2[i] = g[0] + " Забронировано";
                    Send("Забронировано");
                }
            }
            File.WriteAllLines(path, s2);
        }

        static void Send(string k1)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(k1);
                udpClient.Send(data, data.Length, RemoteIpEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static string Read(string messege)
        {
            string[] s = File.ReadAllLines(path);
            string[] g = new string[2];
            string k1 = "";
            for (int i = 0; i < 7; i++)
            {
                g = s[i].Split(' ');
                if (g[0] == messege)
                {
                    k1 = g[1];
                    break;
                }
            }
            return k1;
        }

        static void ReadWrite(string messege)
        {
           string k1 = Read(messege);
            
            Console.WriteLine(messege + " = " + k1);
            if (k1 != "")
            {
                num = messege;
                Send(k1);
            }
            else if (messege == "8") { Bron(num); }
        }
    }
}
