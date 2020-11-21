using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // thông tin host để kết nối
            string _host = "127.0.0.1";
            // thông tin về port connect
            int _port = 2008;
            // tạo một UDP Object
            UdpClient udp = new UdpClient();
            // kết nối tới host
            udp.Connect(_host, _port);
            bool isConnect = true;
            while (isConnect)
            {
                // tạo data để gửi đi. Luôn ở dạng Bytes
                Console.Write("Nhap noi dung gui toi Server: ");
                string str = Console.ReadLine();
                if (str == "exit")
                {
                    //isConnect = false;
                    return;
                }
                Byte[] data = Encoding.ASCII.GetBytes(str);
                // gửi data tới host
                udp.Send(data, data.Length);
            }
            Console.ReadLine();
        }

    }
}

