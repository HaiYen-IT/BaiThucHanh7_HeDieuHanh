using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

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

                // 1. listen
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
                    // 2. receive
                    string str = reader.ReadLine();
                    if (str.ToUpper() == "EXIT")
                    {
                        writer.WriteLine("bye");
                        break;
                    }
                    // 3. send
                    Console.Write("Enter your Age: ");
                    string str1 = Console.ReadLine();
                    writer.WriteLine("Hello " + str1);
                    Console.WriteLine("Hello: " + str);
                }
                // 4. close
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
    }
}
