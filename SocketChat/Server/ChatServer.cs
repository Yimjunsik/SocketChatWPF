﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;

namespace Server
{
    public class ChatServer
    {
        private Dispatcher _dispatcher { get; set; }

        private int _clientIdCounter;
        private Thread _thread;
        private Socket _socket;

        private IPAddress _ipAddress;
        private ushort _port;
        public ushort Port
        {
            get
            {
                return _port;
            }
            set
            {
                if (this.IsServerActive)
                    throw new Exception("Can't change this property when server is active");
                this._port = value;
            }
        }

        private IPEndPoint _ipEndPoint => new IPEndPoint(_ipAddress, _port);

        public string IpAddress
        {
            get
            {
                return _ipAddress.ToString();
            }
            set
            {
                if (this.IsServerActive)
                    throw new Exception("Can't hange this property when server is active ");
                _ipAddress = IPAddress.Parse(value);
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion

        private bool _isServerActive;
        public bool IsServerActive
        {
            get
            {
                return _isServerActive;
            }
            private set
            {
                this._isServerActive = value;

                this.NotifyPropertyChanged("IsServerActive");
                this.NotifyPropertyChanged("IsServerStopped");
            }
        }
    }
}