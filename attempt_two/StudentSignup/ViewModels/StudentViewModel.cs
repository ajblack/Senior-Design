
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
using StudentSignup.Model;
using StudentSignup.Commands;

namespace StudentSignup.ViewModel
{
    class StudentViewModel
    {
        private Student _Student;
        public StudentViewModel()
        {
            _Student = new Student("", "", -1, "", "");
            UpdateCommand = new SignupUpdateCommand(this);
        }
       
        public Student Student
        {
            get
            {
                return _Student;
            }
        }

        public string FirstName{
            get { return _Student.FirstName; }
            set
            {
                _Student.FirstName = value;
            }
        }

        public string LastName
        {
            get { return _Student.LastName; }
            set
            {
                _Student.LastName = value;
            }
        }

        public int CourseID
        {
            get { return _Student.CourseID; }
            set
            {
                _Student.CourseID = value;
            }
        }

        public string EmailAddress
        {
            get { return _Student.EmailAddress; }
            set
            {
                _Student.EmailAddress = value;
            }
        }

        public string Password
        {
            get { return _Student.Password; }
            set{
                _Student.Password = value;
            }
        }

         public void SaveChanges()
        {
            // Debug.Assert(false, String.Format("{0} {1} {2} {3} was updated", Student.FirstName, Student.LastName, Student.CourseID, Student.Password));
            Console.WriteLine("Student name is {0}", _Student.FirstName);

            //this is where I think I can insert my mongo shit to update the database
            String uri = "mongodb://austin:Ozzyblack12!@ds033740.mongolab.com:33740/lab_notebook";

            MongoUrl url = new MongoUrl(uri);
            MongoClient client = new MongoClient(url);
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase(url.DatabaseName);
            var students = db.GetCollection<BsonDocument>("Students");
            //Console.WriteLine("{0}, {1}", _Student.EmailAddress, _Student.FirstName);
            BsonDocument the_student = new BsonDocument{
               {"first_name",_Student.FirstName},
               {"last_name",_Student.LastName},
               {"course_ID",_Student.CourseID},
               {"email address", _Student.EmailAddress},
               {"password",_Student.Password}
            };
            students.Insert(the_student);
            server.Disconnect();
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
                 //if (Student.LastName == null || Student.FirstName == null)
                 //{
                 //    return false;
                 //}
                 //return !(String.IsNullOrWhiteSpace(Student.FirstName) || String.IsNullOrWhiteSpace(Student.LastName) || String.IsNullOrWhiteSpace(Student.Password) || String.IsNullOrWhiteSpace(Student.CourseID.ToString()));
                 return true;
             }
         }

    }
}
