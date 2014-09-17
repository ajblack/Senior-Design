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

    class AdminLoginContext
    {
        private MongoDatabase db;

        public AdminLoginContext()
        {
            String uri = "mongodb://austin:Ozzyblack12!@ds033740.mongolab.com:33740/lab_notebook";
            MongoUrl url = new MongoUrl(uri);
            MongoClient client = new MongoClient(url);
            MongoServer server = client.GetServer();
            this.db = server.GetDatabase(url.DatabaseName);
            var admin_users = db.GetCollection<AdminUser>("Admin_accounts");
        }

        public MongoCollection<AdminUser> Users
        {
            get
            {
                return db.GetCollection<AdminUser>("Admin_acccounts");
            }
        }
    }
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
            AdminLoginContext ctx = new AdminLoginContext();
            ctx.Users.AsQueryable().All();
           

            //server.Disconnect();
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
