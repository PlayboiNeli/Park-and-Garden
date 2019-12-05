using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Park_and_Garden.Common;

namespace Park_and_Garden.Model
{
    public class Admin:User
    {
        public Admin(string name, string username, string password, int phoneNumber) : base(name, username, password, phoneNumber)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            Username = username;
            Name = name;
            IsAdmin = true;
        }

        public bool IsAdmin { get; }

        public void AddUser(string name, string username, string password, int phoneNumber)
        {
            Common.AllLists.Users.Add(new User(name,username,password,phoneNumber));
        }

        public void DeleteEmployee(User selectedUser)
        {
            
        }
    }
}
