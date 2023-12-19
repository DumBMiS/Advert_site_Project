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
    /// Logika interakcji dla klasy AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private MainWindow _mainWindow;
        List<Offers> Offers = new List<Offers>();
        public AdminPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoadOffers();
        }
        //zaladuj oferty
        private void LoadOffers()
        {
            OffersList.ItemsSource = Models.DataBase.GetOffers();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Offers offers = new Offers();
            offers.Position = Entry1.Text;
            offers.Company = Entry2.Text;
            offers.EndDate = Entry3.Text;
            offers.Localization = Entry4.Text;
            offers.Price = Entry5.Text;
            offers.Category = Entry6.Text;

            Models.DataBase.AddOffer(offers);

            _mainWindow.NavigateToAdminPage();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToAccountPage();
        }
    }
}
