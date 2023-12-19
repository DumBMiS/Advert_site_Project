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
    /// Logika interakcji dla klasy SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        private MainWindow _mainWindow;
        public SignInPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
        //Rejestracja
        private async void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            bool succes = true;
            //walidacja
            if (string.IsNullOrWhiteSpace(LoginEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Password) || string.IsNullOrWhiteSpace(RepasswordEntry.Password) || string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(SurnameEntry.Text) || string.IsNullOrWhiteSpace(PhoneNumeberEntry.Text) || string.IsNullOrWhiteSpace(AdressEntry.Text) || string.IsNullOrWhiteSpace(DateEntry.Text) || string.IsNullOrWhiteSpace(ProfilePictureEntry.Text))
            {
                ErrorAlert.Content = "Uzupełnij wszystkie pola!";
                succes = false;
                return;
            }
            else
            {
                int birthYear = DateEntry.SelectedDate.Value.Year;
                int currentYear = DateTime.Now.Year;
                int age = currentYear - birthYear;
                ErrorAlert.Content = "";
                if (!(LoginEntry.Text.All(char.IsLetterOrDigit)) || LoginEntry.Text.Length < 3 || LoginEntry.Text.Length > 25)
                {
                    ErrorAlert.Content = "Login musi mieć od 3 do 25 znaków i moze zawierać tylko litery i liczby";
                    succes = false;
                    return;
                }
                if(!PasswordEntry.Password.All(char.IsLetterOrDigit) || PasswordEntry.Password.Length < 8 || PasswordEntry.Password.Length > 40)
                {
                    ErrorAlert.Content = "Hasło musi składać się wyłącznie z liter i liczby, oraz musi być dłuższe niż 8 znaków lecz krótsze niz 40";
                    succes = false;
                    return;
                }
                if(PasswordEntry.Password != RepasswordEntry.Password)
                {
                    ErrorAlert.Content = "Hasła różnią się od siebie";
                    succes=false;
                    return;
                }
                if(!EmailEntry.Text.Contains('@') || !EmailEntry.Text.Contains('.'))
                {
                    ErrorAlert.Content = "Niepoprawny Email";
                    succes = false;
                    return;
                }
                if(NameEntry.Text.Length < 3 || NameEntry.Text.Length > 40)
                {
                    ErrorAlert.Content = "Imie nie może być krótsze niż 3 litery i dłuższe niż 40";
                    succes = false;
                    return;
                }
                if(!NameEntry.Text.All(char.IsLetter))
                {    
                    ErrorAlert.Content = "Imie nie moze zawierać liczb ani znaków specjalnych";
                    succes = false;
                    return;
                }
                if (!SurnameEntry.Text.All(char.IsLetter))
                {
                    ErrorAlert.Content = "Nazwisko nie moze zawierać liczb ani znaków specjalnych";
                    succes = false;
                    return;
                }
                if (SurnameEntry.Text.Length < 3 || SurnameEntry.Text.Length > 40)
                {
                    ErrorAlert.Content = "Nazwisko nie może być krótsze niż 3 litery i dłuższe niż 40";
                    succes = false;
                    return;
                }
                if(!PhoneNumeberEntry.Text.All(char.IsDigit) || PhoneNumeberEntry.Text.Length != 9)
                {
                    ErrorAlert.Content = "Niepoprawny numer telefonu";
                    succes = false;
                    return;
                }
                if(AdressEntry.Text.Length > 45 )
                {
                    ErrorAlert.Content = "Adres nie może być dłuższy ni 45 znaków";
                    succes = false;
                    return;
                }
                if(age < 18)
                {
                    ErrorAlert.Content = "Aby założyc konto musisz byc pełnoletni/a";
                    succes = false;
                    return;
                }
            }
            var login = LoginEntry.Text;
            var users = Models.DataBase.GetUsers();
            //Sprawdzanie czy User o danym loginie juz istnieje
            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    succes = false;
                    ErrorAlert.Content = "Użytkownik o danej nazwie użytkownika już istnieje";
                    break;
                }
            }
            int lastUserId = users.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault() + 1;
            //Dodawanie do bazy
            if(succes = true)
            {
                CurrentWorkplace workplace = new CurrentWorkplace();
                WorkSummary workSummary = new WorkSummary();
                var user = new User();
                user.Login = login;
                user.Password = PasswordEntry.Password;
                
                Models.DataBase.AddUser(user);
                ErrorAlert.Content = "";

                var userInfo = new BasicUserInfo();
                userInfo.Name = NameEntry.Text;
                userInfo.Surname = SurnameEntry.Text;
                userInfo.Email = EmailEntry.Text;
                userInfo.Adress = AdressEntry.Text;
                userInfo.Email = EmailEntry.Text;
                userInfo.BirthDate = (DateTime)DateEntry.SelectedDate;
                userInfo.PhoneNumber = PhoneNumeberEntry.Text;
                userInfo.ProfilePicture = ProfilePictureEntry.Text;
                userInfo.UserID = lastUserId;

                Models.DataBase.AddBasicUserInfo(userInfo);

                workplace.UserID = lastUserId;
                workplace.CurrentWork = "BRAK";
                workplace.Description = "";
                Models.DataBase.AddCurrentWorkplace(workplace);

                workSummary.UserID = lastUserId;
                workSummary.Summary = "";
                Models.DataBase.AddWorkSummary(workSummary);

                _mainWindow.NavigateToLoginPage();
            }    

        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToLoginPage();
        }
    }
}
