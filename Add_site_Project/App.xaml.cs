﻿using Add_site_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Add_site_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User LoggedUser;
        App()
        {
            this.InitializeComponent();
            DataBase.Connection();
        }
    }
}
