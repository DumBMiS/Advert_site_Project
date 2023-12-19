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
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private MainWindow _mainWindow;
        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            IsLogged();
            _mainWindow = mainWindow;
            LoadOffers();
        }
        //zaladowanie ofert
        private void LoadOffers()
        {
            OffersList.ItemsSource = Models.DataBase.GetOffers();
        }
        //sprawdzanie czy uzytkownik jest zalogowany
        private void IsLogged()
        {
            if(App.LoggedUser != null)
            {
                Account.Visibility = Visibility.Visible;
                login.Content = "Wyloguj";
                login.Click -= login_Click;
                login.Click += logout_Click;
            }
        }
        //przejscie do strony logowania/rejestracji
        private void login_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToLoginPage();
        }
        //wylogowanie
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            App.LoggedUser = null;
            _mainWindow.NavigateToMainPage();
        }
        //przejscie do profilu uzytkownika
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToAccountPage();
        }
    }
}
