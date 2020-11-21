using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace Server
{
    class Program
    {
        private const int PORT_NUMBER = 9999;
        static void Main(string[] args)
        {

            try
            {
                IPAddress address = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(address, PORT_NUMBER);
                listener.Start();
                Console.WriteLine("Server started on " + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");
                Socket socket = listener.AcceptSocket();
                Console.WriteLine("Connection received from " + socket.RemoteEndPoint);
                var stream = new NetworkStream(socket);
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                while (true)
                {
                    string str = reader.ReadLine();
                    if (str.ToUpper() == "EXIT")
                    {
                        writer.WriteLine("bye"); break;
                    }

                    string str1 = sortByEsc(str);
                    writer.WriteLine("Day so sau khi sap xep tang dan: " + str1);

                }
                stream.Close();
                socket.Close();
                listener.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            Console.Read();
        }
        static string sortByEsc(string a)
        {
            a = a.Trim();
            List<int> c = new List<int>();
            string[] b = a.Split(" ");

            foreach (string d in b)
            {
                c.Add(Convert.ToInt32(d));
            }
            c.Sort();
            string e = "";
            foreach (int g in c)
            {
                e += g + " ";
            }
            return e;

        }
    }
}

