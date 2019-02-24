using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Server
{
    public class Client : INotifyPropertyChanged
    {
        private int _id;
        private string _username;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                this.NotifyPropertyChanged("ID");
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                this._username = value;
                this.NotifyPropertyChanged("Username");
            }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion
    }
}
