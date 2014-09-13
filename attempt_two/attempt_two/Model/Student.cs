using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attempt_two.Model
{
    public class Student : INotifyPropertyChanged
    {

        private string _FirstName, _LastName;

        public Student(String firstName, String lastName){
            _FirstName = firstName;
            _LastName = lastName;
        }
        public string FirstName{
            get{
                return _FirstName;
            }
            set{
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
