using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
namespace Client
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 9999;

        static ASCIIEncoding encoding = new ASCIIEncoding();

        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();

                // 1. connect
                client.Connect("127.0.0.1", PORT_NUMBER);
                Stream stream = client.GetStream();

                Console.WriteLine("Connected to Y2Server.");
                Console.Write("Enter your name: ");

                string str = Console.ReadLine();

                // 2. send
                byte[] data = encoding.GetBytes(str);

                stream.Write(data, 0, data.Length);

                // 3. receive
                data = new byte[BUFFER_SIZE];
                stream.Read(data, 0, BUFFER_SIZE);

                Console.Write(encoding.GetString(data));

                // 4. Close
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
