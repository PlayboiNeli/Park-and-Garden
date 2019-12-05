using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Park_and_Garden.Model
{
    public class Admin : User
    {
        public Admin(string name, string username, string password, int phoneNumber) : base(name, username, password,
            phoneNumber)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            Username = username;
            Name = name;
            IsAdmin = true;
        }

        public bool IsAdmin { get; }

        
    }
}
