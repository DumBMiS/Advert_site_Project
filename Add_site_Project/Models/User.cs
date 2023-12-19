﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Add_site_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public User()
        {

        }
        public User(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}
