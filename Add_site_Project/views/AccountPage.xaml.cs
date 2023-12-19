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
    /// Logika interakcji dla klasy AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        private MainWindow _mainWindow;
        BasicUserInfo userInfo =  Models.DataBase.GetUserInfo(App.LoggedUser.Id);
        CurrentWorkplace workplace = Models.DataBase.GetCurrentWorkplace(App.LoggedUser.Id);
        WorkSummary workSummary = Models.DataBase.GetWorkSummary(App.LoggedUser.Id);
        List<LanguagesKnowledge> languages = Models.DataBase.GetLanguagesKnowledge(App.LoggedUser.Id);
        List<Skills> skills = Models.DataBase.GetSkills(App.LoggedUser.Id);
        List<Experience> experiences = Models.DataBase.GetExperiences(App.LoggedUser.Id);
        List<Education> educations = Models.DataBase.GetEducations(App.LoggedUser.Id);
        List<Courses> courses = Models.DataBase.GetCourses(App.LoggedUser.Id);
        List<Links> links1 = Models.DataBase.GetLinks(App.LoggedUser.Id);
        public AccountPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            LoadBasicInfo();
            LoadCurrentWorkplace();
            LoadWorkSummary();
            LoadLanguagesKnowledge();
            LoadSkills();
            LoadExperience();
            LoadEducation();
            LoadCourses();
            LoadLinks();
            GoToAdminPanel();
        }

        //zaladownanie podstawowych informacji o uzytkowniku
        private void LoadBasicInfo()
        {
            Welcome.Content = "Witaj " + App.LoggedUser.Login + "!";

            string ImageUrl = userInfo.ProfilePicture;
            BitmapImage bitmapImage = new BitmapImage(new Uri(ImageUrl));
            ProfilePicture.Source = bitmapImage;
            LoginEntry.Text = App.LoggedUser.Login;
            NameEntry.Text = userInfo.Name;
            SurnameEntry.Text = userInfo.Surname;
            EmailEntry.Text = userInfo.Email;
            NumberEntry.Text = userInfo.PhoneNumber;
            AdressEntry.Text = userInfo.Adress;
            DateEntry.SelectedDate = userInfo.BirthDate;
            ProfilePictureEntry.Text = userInfo.ProfilePicture;
        }
        //zaladowanie aktualnego stanowsika pracy
        private void LoadCurrentWorkplace()
        {
            CurrentWorkEntry.Text = workplace.CurrentWork;
            DescriptionEntry.Text = workplace.Description;
        }
        //zaladownie podsumowania zawodowego
        private void LoadWorkSummary()
        {
            WorkSummaryEntry.Text = workSummary.Summary;
        }
        //zaladownie znajomosci jezykow
        private void LoadLanguagesKnowledge()
        {
            LanguageList.ItemsSource = languages;
        }
        //zaladownaie umiejetnosci
        private void LoadSkills()
        {
            SkillsList.ItemsSource = skills;
        }
        //zaladowanie doswiadczenia zawodowego
        private void LoadExperience()
        {
            ExperienceList.ItemsSource = experiences;
        }
        //zaladowanie edukacji
        private void LoadEducation()
        {
            EducationList.ItemsSource = educations;
        }
        //zaladowanie kursow
        private void LoadCourses()
        {
            CoursesList.ItemsSource = courses;
        }
        //zaladownaie linkow
        private void LoadLinks()
        {
            LinksList.ItemsSource = links1;
        }
        //powrot do strony glownej
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToMainPage();
        }
        //wejscie do adminpanelu
        private void GoToAdminPanel()
        {
            if(App.LoggedUser.Login == "Admin")
            {
                AdminPanel.Visibility = Visibility.Visible;
            }
        }
        //Edycja podstawowych informacji o uzytkoniku
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            bool succes = true;
            //walidacja
            if (string.IsNullOrWhiteSpace(LoginEntry.Text) || string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(SurnameEntry.Text) || string.IsNullOrWhiteSpace(NumberEntry.Text) || string.IsNullOrWhiteSpace(AdressEntry.Text) || string.IsNullOrWhiteSpace(DateEntry.Text) || string.IsNullOrWhiteSpace(ProfilePictureEntry.Text))
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
                if (!EmailEntry.Text.Contains('@') || !EmailEntry.Text.Contains('.'))
                {
                    ErrorAlert.Content = "Niepoprawny Email";
                    succes = false;
                    return;
                }
                if (NameEntry.Text.Length < 3 || NameEntry.Text.Length > 40)
                {
                    ErrorAlert.Content = "Imie nie może być krótsze niż 3 litery i dłuższe niż 40";
                    succes = false;
                    return;
                }
                if (!NameEntry.Text.All(char.IsLetter))
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
                if (!NumberEntry.Text.All(char.IsDigit) || NumberEntry.Text.Length != 9)
                {
                    ErrorAlert.Content = "Niepoprawny numer telefonu";
                    succes = false;
                    return;
                }
                if (AdressEntry.Text.Length > 45)
                {
                    ErrorAlert.Content = "Adres nie może być dłuższy ni 45 znaków";
                    succes = false;
                    return;
                }
                if (age < 18)
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
            int lastUserId = users.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
            //Dodawanie do bazy
            if (succes = true)
            {
                var user = new User();
                user.Login = login;
                user.Password = App.LoggedUser.Password;

                Models.DataBase.EditUser(user, App.LoggedUser.Id);
                ErrorAlert.Content = "";

                var userInfo = new BasicUserInfo();
                userInfo.Name = NameEntry.Text;
                userInfo.Surname = SurnameEntry.Text;
                userInfo.Email = EmailEntry.Text;
                userInfo.Adress = AdressEntry.Text;
                userInfo.Email = EmailEntry.Text;
                userInfo.BirthDate = (DateTime)DateEntry.SelectedDate;
                userInfo.PhoneNumber = NumberEntry.Text;
                userInfo.ProfilePicture = ProfilePictureEntry.Text;
                userInfo.UserID = lastUserId;
                Models.DataBase.EditUserInfo(userInfo, App.LoggedUser.Id);

                user.Id = App.LoggedUser.Id;
                App.LoggedUser = user;
                _mainWindow.NavigateToAccountPage();
            }
        }
        //zmiana aktualnego stanowiska pracy
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            bool succes = true;
            if(string.IsNullOrWhiteSpace(CurrentWorkEntry.Text))
            {
                CWerrorAlert.Content = "Podaj nazwe aktualnego stanowiska pracy";
                succes = false;
                return;
            }
            else
            {
                if(CurrentWorkEntry.Text.Length > 50)
                {
                    CWerrorAlert.Content = "Nazwa jest za długa(maks. 50 znaków)";
                    succes = false;
                    return;
                }
                if(DescriptionEntry.Text.Length >200)
                {
                    CWerrorAlert.Content = "Opis jest za długi(maks. 200 znaków";
                    succes = false;
                    return;
                }
            }
            if(succes)
            {
                CurrentWorkplace workplace = new CurrentWorkplace();
                workplace.CurrentWork = CurrentWorkEntry.Text;
                workplace.Description = DescriptionEntry.Text;

                Models.DataBase.EditCurrentWorkplace(workplace, App.LoggedUser.Id);
            }
        }
        //edycja podsumowania zawodowego
        private void ChangeWorkSummary_Click(object sender, RoutedEventArgs e)
        {
            WorkSummary worksummary = new WorkSummary();
            worksummary.Summary = WorkSummaryEntry.Text;

            Models.DataBase.EditWorkSummary(worksummary, App.LoggedUser.Id); ;
        }
        //stworzenie formularza na dodanie jezyka
        private void AddLanguage_Click(object sender, RoutedEventArgs e)
        {
            InputsStackPanel.Children.RemoveRange(2, 6);
            LoginEntry.Text = "";
            NameEntry.Text = "";
            Edit.Content = "Dodaj";
            Edit.Click -= Edit_Click;
            Edit.Click += AddLanguages;
        }
        //dodanie jezyka
        private void AddLanguages(object sender, RoutedEventArgs e)
        {
            LanguagesKnowledge languagesKnowledge = new LanguagesKnowledge(LoginEntry.Text, NameEntry.Text);
            languagesKnowledge.UserID = App.LoggedUser.Id;
            Models.DataBase.AddLanguageKnowledge(languagesKnowledge);
            _mainWindow.NavigateToAccountPage();
        }
        //formularz na edycje jezyka
        private void EditLanguage_Click(object sender, RoutedEventArgs e)
        {
            LanguagesKnowledge languages = new LanguagesKnowledge();
            languages = LanguageList.SelectedItem as LanguagesKnowledge;
            if (languages != null)
            {
                InputsStackPanel.Children.RemoveRange(2, 6);
                LoginEntry.Text = languages.Language;
                NameEntry.Text = languages.LevelOfKnowledge;
                Edit.Click -= Edit_Click;
                Edit.Click += EditLanguages;
            }


        }
        //edycja jezyka
        private void EditLanguages(object sender, RoutedEventArgs e)
        {
            LanguagesKnowledge languages = new LanguagesKnowledge();
            languages = LanguageList.SelectedItem as LanguagesKnowledge;

            LanguagesKnowledge languagesKnowledge = new LanguagesKnowledge(LoginEntry.Text, NameEntry.Text);
            Models.DataBase.EditLanguageKnowledge(languagesKnowledge, languages.ID);
            _mainWindow.NavigateToAccountPage();

        }
        //usuwanie jezyka
        private void DeleteLanguage_Click(object sender, RoutedEventArgs e)
        {
            LanguagesKnowledge language = new LanguagesKnowledge();
            language = LanguageList.SelectedItem as LanguagesKnowledge;
            if(language != null)
            {
                Models.DataBase.DeleteLanguageKnowledge(language.ID);
                _mainWindow.NavigateToAccountPage();
            }
        }
        //formularz na umiejetnosci
        private void AddSkill_Click(object sender, RoutedEventArgs e)
        {
            InputsStackPanel.Children.RemoveRange(1, 7);
            LoginEntry.Text = "";
            Edit.Content = "Dodaj";
            Edit.Click -= Edit_Click;
            Edit.Click += AddSkills;
        }
        //dodawanie umiejetnosci
        private void AddSkills(object sender, RoutedEventArgs e)
        {
            Skills skills = new Skills(App.LoggedUser.Id, LoginEntry.Text);
            Models.DataBase.AddSkills(skills);
            _mainWindow.NavigateToAccountPage();
        }
        //formularz na edycje umiejetnosci
        private void EditSkill_Click(object sender, RoutedEventArgs e)
        {

            Skills skills = new Skills();
            skills = SkillsList.SelectedItem as Skills;
            if (skills != null)
            {
                InputsStackPanel.Children.RemoveRange(1, 7);
                LoginEntry.Text = skills.Skill;
                Edit.Click -= Edit_Click;
                Edit.Click += EditSkills;
            }
        }
        //edycja umiejetnosci
        private void EditSkills(object sender, RoutedEventArgs e)
        {
            Skills skill = new Skills(LoginEntry.Text);
            Skills skills = SkillsList.SelectedItem as Skills;

            Models.DataBase.EditSkills(skill, skills.ID);
            _mainWindow.NavigateToAccountPage();
        }
        //usuwanie umiejetnosci
        private void DeleteSkill_Click(object sender, RoutedEventArgs e)
        {
            Skills skills = SkillsList.SelectedItem as Skills;
            if (skills != null)
            {
                Models.DataBase.DeleteSkills(skills.ID);
                _mainWindow.NavigateToAccountPage();
            }

        }
        //usuwanie doswiadczenia
        private void DeleteExperience_Click(object sender, RoutedEventArgs e)
        {
            Experience experience = new Experience();
            experience = ExperienceList.SelectedItem as Experience;
            if (experience != null)
            {
                Models.DataBase.DeleteExperience(experience.ID);

                _mainWindow.NavigateToAccountPage();
            }
        }
        //formularz edycji doswiadczenia
        private void EditExperience_Click(object sender, RoutedEventArgs e)
        {
            Experience experience = new Experience();
            experience = ExperienceList.SelectedItem as Experience;
            if (experience != null)
            {
                InputsStackPanel.Children.RemoveRange(5, 3);
                LoginEntry.Text = experience.Position;
                NameEntry.Text = experience.CompanyName;
                SurnameEntry.Text = experience.Localization;
                EmailEntry.Text = experience.EmplymentPeriod;
                NumberEntry.Text = experience.Duties;
                Edit.Click -= Edit_Click;
                Edit.Click += EditExperiences;
            }

        }
        //edycja doswiadczenia zawodowego
        private void EditExperiences(object sender, RoutedEventArgs e)
        {
            Experience experience = new Experience(LoginEntry.Text, NameEntry.Text, SurnameEntry.Text, EmailEntry.Text, NumberEntry.Text);
            Experience experience1 = ExperienceList.SelectedItem as Experience;

            Models.DataBase.EditExperience(experience, experience1.ID);

            _mainWindow.NavigateToAccountPage();
        }
        //formularz dodawania doswiadczenia
        private void AddExperience_Click(object sender, RoutedEventArgs e)
        {
            InputsStackPanel.Children.RemoveRange(5, 3);
            LoginEntry.Text = "";
            NameEntry.Text = "";
            SurnameEntry.Text = "";
            EmailEntry.Text = "";
            NumberEntry.Text = "";

            Edit.Content = "Dodaj";
            Edit.Click -= Edit_Click;
            Edit.Click += AddExperiences;
        }
        //dodawanie doswiadczenia
        private void AddExperiences(object sender, RoutedEventArgs e)
        {
            Experience experience = new Experience(App.LoggedUser.Id, LoginEntry.Text, NameEntry.Text, SurnameEntry.Text, EmailEntry.Text, NumberEntry.Text);
            Models.DataBase.AddExperience(experience);

            _mainWindow.NavigateToAccountPage();
        }
        //formularz na dodawanie edukacji
        private void AddEducation_Click(object sender, RoutedEventArgs e)
        {
            InputsStackPanel.Children.RemoveRange(5,3);

            LoginEntry.Text = "";
            NameEntry.Text = "";
            SurnameEntry.Text = "";
            EmailEntry.Text = "";
            NumberEntry.Text = "";

            Edit.Content = "Dodaj";
            Edit.Click -= Edit_Click;
            Edit.Click += AddEducations;
        }
        //dodawanie edukacji
        private void AddEducations(object sender, RoutedEventArgs e)
        {
            Education education = new Education(App.LoggedUser.Id, LoginEntry.Text, NameEntry.Text, SurnameEntry.Text, EmailEntry.Text, NumberEntry.Text);
            Models.DataBase.AddEducation(education);

            _mainWindow.NavigateToAccountPage();
        }
        //formularz edycja eduakcji
        private void EditEducation_Click(object sender, RoutedEventArgs e)
        {
            Education education = EducationList.SelectedItem as Education;

            if(education != null)
            {
                InputsStackPanel.Children.RemoveRange(5, 3);
                LoginEntry.Text = education.SchoolName;
                NameEntry.Text = education.Localization;
                SurnameEntry.Text = education.DegreeLevel;
                EmailEntry.Text = education.FieldOfStudy;
                NumberEntry.Text = education.EducationPeriod;

                Edit.Click -= Edit_Click;
                Edit.Click += EditEducations;
            }

        }
        private void EditEducations(object sender, RoutedEventArgs e)
        {
            Education education = new Education(LoginEntry.Text, NameEntry.Text, SurnameEntry.Text, EmailEntry.Text, NumberEntry.Text);
            Education education1 = EducationList.SelectedItem as Education;

            Models.DataBase.EditEducation(education, education1.ID);

            _mainWindow.NavigateToAccountPage();
        }
        private void DeleteEducation_Click(object sender, RoutedEventArgs e)
        {
            Education education = EducationList.SelectedItem as Education;
            if (education != null)
            {
                Models.DataBase.DeleteEducation(education.ID);

                _mainWindow.NavigateToAccountPage();
            }
        }
        //usuwanie kursu
        private void DeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            Courses course = CoursesList.SelectedItem as Courses;

            if(course !=null)
            {
                Models.DataBase.DeleteCourses(course.ID);

                _mainWindow.NavigateToAccountPage();
            }
        }
        //formularz na edycje kursu
        private void EditCourse_Click(object sender, RoutedEventArgs e)
        {
            Courses courses = CoursesList.SelectedItem as Courses;

            if(courses != null)
            {
                InputsStackPanel.Children.RemoveRange(3, 5);

                LoginEntry.Text = courses.CourseName;
                NameEntry.Text = courses.Organizer;
                SurnameEntry.Text = courses.CoursePeriod;

                Edit.Click -= Edit_Click;
                Edit.Click += EditCourses;
            }
        }
        private void EditCourses(object sender, RoutedEventArgs e)
        {
            Courses course = CoursesList.SelectedItem as Courses;
            Courses courses = new Courses(LoginEntry.Text, NameEntry.Text, SurnameEntry.Text);

            Models.DataBase.EditCourses(courses, course.ID);

            _mainWindow.NavigateToAccountPage();
        }
        //formularz na dodanie kursu
        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            InputsStackPanel.Children.RemoveRange(3, 5);
            LoginEntry.Text = "";
            NameEntry.Text = "";
            SurnameEntry.Text = "";

            Edit.Content = "Dodaj";
            Edit.Click -= Edit_Click;
            Edit.Click += AddCourses;
        }
        //dodawanie kursow
        private void AddCourses(object sender, RoutedEventArgs e)
        {
            Courses course = new Courses(App.LoggedUser.Id, LoginEntry.Text, NameEntry.Text, SurnameEntry.Text);
            Models.DataBase.AddCourses(course);

            _mainWindow.NavigateToAccountPage();

        }
        //formularz na dodanie linkow
        private void AddLink_Click(object sender, RoutedEventArgs e)
        {
            InputsStackPanel.Children.RemoveRange(1, 7);

            LoginEntry.Text = "";
            Edit.Content = "Dodaj";
            Edit.Click -= Edit_Click;
            Edit.Click += AddLinks;
        }
        //dodawanie linkow
        private void AddLinks(object sender, RoutedEventArgs e)
        {
            Links links = new Links(App.LoggedUser.Id, LoginEntry.Text);

            Models.DataBase.AddLinks(links);

            _mainWindow.NavigateToAccountPage();
        }
        //formularz na edycje linkow
        private void EditLink_Click(object sender, RoutedEventArgs e)
        {
            Links links = LinksList.SelectedItem as Links;
            if(links != null)
            {
                InputsStackPanel.Children.RemoveRange(1, 7);
                LoginEntry.Text = links.Link;

                Edit.Click -= Edit_Click;
                Edit.Click += EditLinks;
            }
        }
        //edycja linkow
        private void EditLinks(object sender, RoutedEventArgs e)
        {
            Links link = new Links(LoginEntry.Text);
            Links links = LinksList.SelectedItem as Links;

            Models.DataBase.EditLinks(link, links.ID);

            _mainWindow.NavigateToAccountPage();
        }
        //usuwanie linkow
        private void DeleteLink_Click(object sender, RoutedEventArgs e)
        {
            Links links = LinksList.SelectedItem as Links;
            if(links != null)
            {
                Models.DataBase.DeleteLinks(links.ID);

                _mainWindow.NavigateToAccountPage();
            }
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToAdminPage();
        }
    }
}

