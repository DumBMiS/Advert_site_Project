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

namespace Add_site_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateToMainPage();
        }
        public void NavigateToMainPage()
        {
            Main.Content = new views.MainPage(this);
        }
        public void NavigateToLoginPage()
        {
            Main.Content = new views.LoginPage(this);
        }
        public void NavigateToSiginPage()
        {
            Main.Content = new views.SignInPage(this);
        }
        public void NavigateToAccountPage()
        {
            Main.Content = new views.AccountPage(this);
        }
        public void NavigateToAdminPage()
        {
            Main.Content = new views.AdminPage(this);
        }
    }
}
