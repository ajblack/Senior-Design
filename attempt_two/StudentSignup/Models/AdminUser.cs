using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSignup.Models
{
    class AdminUser:INotifyPropertyChanged
    {
        private String _Username, _Password;

        public AdminUser(String username, String password)
        {
            _Username = username;
            _Password = password;
        }

        public string Username
        {
            get { return _Username; }
            set{
                _Username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }



        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
