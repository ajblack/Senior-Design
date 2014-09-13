using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using StudentSignup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentSignup.Commands;
using MongoDB.Driver.Builders;

namespace StudentSignup.ViewModels
{
    class AdminLoginViewModel
    {
        private AdminUser _User;
        public AdminLoginViewModel()
        {
            _User = new AdminUser("", "");
            UpdateCommand = new AdminLoginCommand(this);
        }
       
        public AdminUser AdminUser
        {
            get
            {
                return _User;
            }
        }

        public string Username
        {
            get { return _User.Username; }
            set
            {
                _User.Username = value;
            }
        }


        public string Password
        {
            get { return _User.Password; }
            set{
                _User.Password = value;
            }
        }

         public void SaveChanges()
        {
            // Debug.Assert(false, String.Format("{0} {1} {2} {3} was updated", Student.FirstName, Student.LastName, Student.CourseID, Student.Password));
            Console.WriteLine("admin name is {0}", _User.Username);

            //this is where I think I can insert my mongo shit to update the database
            String uri = "mongodb://austin:Ozzyblack12!@ds033740.mongolab.com:33740/lab_notebook";

            MongoUrl url = new MongoUrl(uri);
            MongoClient client = new MongoClient(url);
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase(url.DatabaseName);
            var admin_users = db.GetCollection<BsonDocument>("Admin_accounts");
            var query =
                from e in admin_users.AsQueryable<AdminUser>()
                where e.Username == _User.Username && e.Password == _User.Password
                select e;
            Console.WriteLine("query is {0}", query);
            foreach (var employee in query)
            {
                Console.WriteLine("here!!!");
            }
            //var admin_users = db.GetCollection<BsonDocument>("Admin_accounts");
            //var query = new QueryDocument("username", _User.Username);
            //var pass_query = new QueryDocument("password",_User.Password);      
            //foreach (BsonDocument item in admin_users.Find(query))
            //{
            //    //BsonElement user_name = item.GetElement("username");
            //    BsonElement pass_word = item.GetElement("password");
                
            //    //Console.WriteLine("Username is {0} and password is {1}", user_name.Value, pass_word.Value);

            //}
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
