using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSignup.Model
{
    public class Student : INotifyPropertyChanged
    {

        private string _FirstName, _LastName, _Password, _EmailAddress;
        private int _CourseID;

        public Student(String firstName, String lastName, int courseID, string emailAddress, string password)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _Password = password;
            _CourseID = courseID;
            _EmailAddress = emailAddress;
        }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public int CourseID
        {
            get { return _CourseID; }
            set
            {
                _CourseID = value;
                OnPropertyChanged("CourseID");
            }
        }

        public string Password
        {
            get { return _Password; }
            set{
                _Password = value;
                OnPropertyChanged("Password");
            }
        }

        public string EmailAddress
        {
            get { return _EmailAddress; }
            set
            {
                _EmailAddress = value;
                OnPropertyChanged("Email Address");
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
