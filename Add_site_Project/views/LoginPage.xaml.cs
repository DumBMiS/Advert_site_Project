using Add_site_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Add_site_Project.views
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private MainWindow _mainWindow;
        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Password))
                ErrorAlert.Content = "Uzupełnij wszystkie pola";
            else
            {
                var login = LoginEntry.Text;
                var users = Models.DataBase.GetUsers();
                User storedUser = null;

                foreach(var user in users)
                {
                    if(user.Login == login)
                    {
                        storedUser = user;
                        break;
                    }
                }
                if(storedUser != null)
                {
                    var enteredPassword = PasswordEntry.Password;
                    if(enteredPassword == storedUser.Password)
                    {
                        App.LoggedUser = storedUser;
                        _mainWindow.NavigateToMainPage();
                        return;
                    }
                }
                ErrorAlert.Content = "Login lub hasło jest niepoprawne";
            }
        }
        
        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToSiginPage();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToMainPage();
        }
    }
}
