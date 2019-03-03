using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public class ChatClient
    {
        private Dispatcher _dispatcher;
        private Thread _thread;
        private Socket _socket;

        private IPAddress _ipAddress;
        public string IpAddress
        {
            get
            {
                return _ipAddress.ToString();
            }
            set
            {
//                if (this.IsClientConnected)
//                    throw new Exception("Can't change this property when server is active");
                _ipAddress = IPAddress.Parse(value);
            }
        }
    }
}
