using attempt_two.Command;
using attempt_two.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace attempt_two.ViewModel
{
    class StudentViewModel
    {
        public StudentViewModel()
        {
            _Student = new Student("David","Neighoff");
            UpdateCommand = new StudentUpdateCommand(this);
        }
        private Student _Student;
        public Student Student
        {
            get
            {
                return _Student;
            }
        }

        public void SaveChanges()
        {
            Console.WriteLine("I have been updated");
            Debug.Assert(false, String.Format("{0} {1} was updated", Student.FirstName, Student.LastName));
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        //gets or sets a boolean valu indicating whether or not thestudent can be updated
        public bool CanUpdate
        {
            get
            {
                if (Student.LastName == null ||Student.FirstName == null)
                {
                    return false;
                }
                return !(String.IsNullOrWhiteSpace(Student.FirstName) || String.IsNullOrWhiteSpace(Student.LastName));
            }
        }
    }
}
