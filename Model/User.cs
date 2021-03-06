﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_and_Garden.Model
{
    //Made by Andreea Vasiliu

    public class User
    {
        public User(string name, string username, string password, int phoneNumber)
        {
            Name = name;
            Username = username;
            Password= password;
            PhoneNumber = phoneNumber;
            IsAdmin = false;
        }

        public int PhoneNumber { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public bool IsAdmin { get; internal set; }



    }
}
