using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace asynchronous_udp
{
    internal class Program
    {
        private static IPEndPoint EpServer;
        private static IPEndPoint EpClient;
        private static UdpClient asyncUdpS;
        private static UdpClient asyncUdpC;

        private static void Main(string[] args)
        {
            EpServer = new IPEndPoint(IPAddress.Any, 9999);
            EpClient = new IPEndPoint(IPAddress.Any, 0);

            // UdpClient
            asyncUdpS = new UdpClient(EpServer);
            asyncUdpC = new UdpClient("127.0.0.1", 10000);

            asyncUdpC.SendAsync(Encoding.Default.GetBytes("66666666"), 8);

            asyncUdpS.BeginReceive(new AsyncCallback(ReceiveCallback), null);

            for (; ; )
            {
                Thread.Sleep(1000);
                Console.WriteLine("Sleep 1 second");
            }
        }

        private static void ReceiveCallback(IAsyncResult iar)
        {
            byte[] receiveData = asyncUdpS.EndReceive(iar, ref EpClient);
            asyncUdpS.BeginReceive(new AsyncCallback(ReceiveCallback), null);
            Console.WriteLine("Received a message from [{0}]: {1}", EpClient, Encoding.ASCII.GetString(receiveData));
        }

        private static void SendCallback(IAsyncResult iar)
        {
            int sendCount = asyncUdpS.EndSend(iar);
            if (sendCount == 0)
            {
                Console.WriteLine("Send message failure...");
            }
        }
    }
}