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

namespace Client
{
    public class ChatClient : INotifyPropertyChanged
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
                if (this.IsClientConnected)
                    throw new Exception("Can't change this property when server is active");
                _ipAddress = IPAddress.Parse(value);
            }
        }

        private bool _isClientConnected;
        public bool IsClientConnected
        {
            get
            {
                return _isClientConnected;
            }
            private set
            {
                this._isClientConnected = value;

                this.NotifyPropertyChanged("IsClientConnected");
                this.NotifyPropertyChanged("IsClientDisconnected");
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion
    }
}