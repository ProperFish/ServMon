using System;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Client
    {
        public static TcpClient tcpClient;
        public static ASCIIEncoding ascii;

        static void Main(string[] args)
        {
            tcpClient = new TcpClient();
            ascii = new ASCIIEncoding();
            Console.WriteLine("ServMon Client Software...\n");
            Console.ReadKey();
            Console.WriteLine("[INF] Client connection initializing...");
            tcpClient.Connect("127.0.0.1", 2254);
            Console.WriteLine("[RDY] Connected!");
            Console.Write("[INP] Input: ");
            String str = Console.ReadLine();

            Stream stm = tcpClient.GetStream();
            byte[] ba = ascii.GetBytes(str);

            Console.WriteLine("[INF] Sending string '{0}' to server...", str);

            stm.Write(ba, 0, ba.Length);

            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
