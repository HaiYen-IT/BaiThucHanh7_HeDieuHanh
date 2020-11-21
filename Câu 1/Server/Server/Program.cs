using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // tạo một đối tượng UdpClient và lắng nghe cổng 2008
            UdpClient udp = new UdpClient(2008);
            // thực hiện listen liên tục
            while (true)
            {
                // xác định điểm Remote IP
                IPEndPoint RemoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                // thu lấy thông tin từ client dạng byte
                Byte[] data = udp.Receive(ref RemoteIPEndPoint);
                // chuyển về string
                string message = Encoding.ASCII.GetString(data);
                // in thông điệp ra
                Console.WriteLine("Address: {0} - Message: {1}", RemoteIPEndPoint.Address, message);
            }

        }
    }
}
