using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadClient
{
    class Program
    {
        static int Main(string[] args)
        {
            SocketListener.StartListening("127.0.0.1", 2254);
            return 0;
        }
    }
}
