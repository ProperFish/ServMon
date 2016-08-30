using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        public static TcpListener tcpList;
        public static Socket tcpSocket;

        static void Main(string[] args)
        {
            Console.WriteLine("ServMon Server Software...\n");
            Console.ReadKey();
            Console.WriteLine("[INF] Server listener initializing...");
            InitListener("127.0.0.1",2254);
            tcpList.Start();
            Console.WriteLine("[INF] Server is now listening at port {0}/TCP!", tcpList.LocalEndpoint);
            Console.WriteLine("[RDY] Waiting for connection...");

            tcpSocket = tcpList.AcceptSocket();
            Console.WriteLine("[INF] Connection attempt from {0}...", tcpSocket.RemoteEndPoint);
            Console.WriteLine("[OK ] Connected - awaiting commands.");

            byte[] packet = new byte[100];
            int packetlength = tcpSocket.Receive(packet);
            Console.WriteLine("[INF] Receiving package from client at {0}", tcpSocket.RemoteEndPoint);

            Console.Write("[MSG] '");
            for (int i = 0; i < packetlength; i++)
            {
                Console.Write(Convert.ToChar(packet[i]));
            }
            Console.Write("'\n");
            
            tcpSocket.Close();
            tcpList.Stop();
            Console.ReadKey();
        }

        static void InitListener(string ip, int port)
        {
            IPAddress ipAddr;
            ipAddr = IPAddress.Parse(ip);
            tcpList = new TcpListener(ipAddr, port);
        }
    }
}
