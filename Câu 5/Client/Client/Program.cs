using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace Client
{
    class Program
    {
        private const int PORT_NUMBER = 9999;
        static void Main(string[] args)
        {

            try
            {
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", PORT_NUMBER);
                Stream stream = client.GetStream();
                Console.WriteLine("Connected to Y2Server.");
                while (true)
                {
                    Console.Write("Nhap vao ten ung dung: ");
                    string str = Console.ReadLine();
                    var reader = new StreamReader(stream);
                    var writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    writer.WriteLine(str);
                    str = reader.ReadLine();
                    Console.WriteLine(str);
                    if (str.ToUpper() == "BYE")
                        break;
                }
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            Console.Read();
        }
    }
}
