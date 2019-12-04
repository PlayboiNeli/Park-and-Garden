using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_and_Garden.Model
{
    public class User
    {
        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password= password;
        }

        public string Password { get; }

        public string Username { get; }

        public string Name { get; }

        public void EditQuantity()
        { }
    }
}
