using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Data.Sqlite;

namespace Add_site_Project.Models
{
    public class DataBase
    {
        private static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AdvertisementSystemDataBase.db");
        //Wszystkie zapytania tworzace tabele
        public async static void Connection()
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var UserTableQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS User(ID INTEGER PRIMARY KEY AUTOINCREMENT, Login VARCHAR(50), Password VARCHAR(50))", connection);
            UserTableQuery.ExecuteReader();
            var BasicInfoQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS BasicUserInfo(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, Name VARCHAR(50), Surname VARCHAR(50), Email VARCHAR(50), PhoneNumber VARCHAR(50), Adress VARCHAR(50), BirthDate VARCHAR(50), ProfilePicture VARCHAR(255))", connection);
            BasicInfoQuery.ExecuteReader();
            var CurrentWorkplaceQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS CurrentWorkplace(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, CurrentWork VARCHAR(50), Description VARCHAR(200))", connection);
            CurrentWorkplaceQuery.ExecuteReader();
            var WorkSummaryQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS WorkSummary(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, Summary VARCHAR(200))", connection);
            WorkSummaryQuery.ExecuteReader();
            var LanguagesQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS LanguagesKnowledge(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, Language VARCHAR(25), LevelOfKnowledge VARCHAR(25))", connection);
            LanguagesQuery.ExecuteReader();
            var SkillsQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS Skills(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, Skill VARCHAR(50))", connection);
            SkillsQuery.ExecuteReader();
            var ExperienceQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS Experience(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, Position VARCHAR(50), CompanyName VARCHAR(50), Localization VARCHAR(50), EmploymentPeriod VARCHAR(50), Duties VARCHAR(50))",connection);
            ExperienceQuery.ExecuteReader();
            var EducationQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS Education(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, SchoolName VARCHAR(50), Localization VARCHAR(50), DegreeLevel VARCHER(50), FieldOfStudy VARCHER(50), EducationPeriod VARCHAR(50))", connection);
            EducationQuery.ExecuteReader();
            var CoursesQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS Courses(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, CourseName VARCHAR(50), Organizer VARCHAR(50), CoursePeriod VARCHAR(50))", connection);
            CoursesQuery.ExecuteReader();
            var LinksQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS Links(ID INTEGER PRIMARY KEY AUTOINCREMENT, UserID INT, Link VARCHAR(255))", connection);
            LinksQuery.ExecuteReader();
            var OffersQuery = new SqliteCommand("CREATE TABLE IF NOT EXISTS Offers(ID INTEGER PRIMARY KEY AUTOINCREMENT, Position VARCHAR(50), Company VARCHAR(50), EndDate VARCHAR(50), Localization VARCHAR(50), Price VARCHAR(50), Category VARCHAR(50))", connection);
            OffersQuery.ExecuteReader();
        }
        //Dodawanie uzytkownika
        public static void AddUser(User user)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO User(Login, Password) VALUES(@Login, @Password)", connection);
            query.Parameters.AddWithValue("@Login", user.Login);
            query.Parameters.AddWithValue("@Password", user.Password);
            query.ExecuteReader();
        }
        //Wyswietlanie tabeli User
        public static List<User> GetUsers()
        {
            List<User> ListOfUsers = new List<User>();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM User", connection);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                User user = new User(read.GetInt32(0), read.GetString(1), read.GetString(2));
                ListOfUsers.Add(user);
            }
            return ListOfUsers;
        }
        //Wyswietlenie konkretnergo uzytkownika
        public static User GetUser(int id)
        {
            User User = new User();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM User WHERE ID=@ID");
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader read = query.ExecuteReader();
            while(read.Read())
            {
                User user = new User(read.GetInt32(0), read.GetString(1), read.GetString(2));
                User = user;
            }
            return User;

        }
        //edycja uzytkownika
        public static void EditUser(User user, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE User SET Login=@login, Password=@password WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@login", user.Login);
            query.Parameters.AddWithValue("@password", user.Password);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //Dodawanie podstawowych informacji uzytkownika
        public static void AddBasicUserInfo(BasicUserInfo userInfo)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO BasicUserInfo(UserID, Name, Surname, Email, PhoneNumber, Adress, BirthDate, ProfilePicture) VALUES (@UserID, @Name, @Surname, @Email, @PhoneNumber, @Adress, @BirthDate, @ProfilePicture)", connection);
            query.Parameters.AddWithValue("@UserID", userInfo.UserID);
            query.Parameters.AddWithValue("@Name", userInfo.Name);
            query.Parameters.AddWithValue("@Surname", userInfo.Surname);
            query.Parameters.AddWithValue("@Email", userInfo.Email);
            query.Parameters.AddWithValue("@PhoneNumber", userInfo.PhoneNumber);
            query.Parameters.AddWithValue("@Adress", userInfo.Adress);
            query.Parameters.AddWithValue("@BirthDate", userInfo.BirthDate);
            query.Parameters.AddWithValue("@ProfilePicture", userInfo.ProfilePicture);
            query.ExecuteReader();
        }
        //wywolywanie podstawowych informacji uzytkownika z bazy
        public static BasicUserInfo GetUserInfo(int id)
        {

            BasicUserInfo user = new BasicUserInfo();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM BasicUserInfo WHERE UserID=@id", connection);
            query.Parameters.AddWithValue("@id", id);
            SqliteDataReader read = query.ExecuteReader();
            while (read.Read())
            {
                BasicUserInfo basicUserInfo = new BasicUserInfo(read.GetInt32(0),read.GetInt32(1), read.GetString(2), read.GetString(3), read.GetString(4), read.GetString(5), read.GetString(6), read.GetDateTime(7), read.GetString(8));
                user = basicUserInfo;
            }
            return user;
        }
        //edycja podstawowych informacji uzytkownika
        public static void EditUserInfo(BasicUserInfo userInfo, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE BasicUserInfo SET Name=@Name, Surname=@Surname, Email=@Email, PhoneNumber=@PhoneNumber, Adress=@Adress, BirthDate=@BirthDate, ProfilePicture=@ProfilePicture WHERE UserId=@ID", connection);
            query.Parameters.AddWithValue("@Name", userInfo.Name);
            query.Parameters.AddWithValue("@Surname", userInfo.Surname);
            query.Parameters.AddWithValue("@Email", userInfo.Email);
            query.Parameters.AddWithValue("@PhoneNumber", userInfo.PhoneNumber);
            query.Parameters.AddWithValue("@Adress", userInfo.Adress);
            query.Parameters.AddWithValue("@BirthDate", userInfo.BirthDate);
            query.Parameters.AddWithValue("@ProfilePicture", userInfo.ProfilePicture);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //dodawanie aktualnego miejsca pracy
        public static void AddCurrentWorkplace(CurrentWorkplace currentWorkplace)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO CurrentWorkplace(UserID, CurrentWork, Description) VALUES(@UserID, @CurrentWork, @Description)",connection);
            query.Parameters.AddWithValue("@UserID", currentWorkplace.UserID);
            query.Parameters.AddWithValue("@CurrentWork", currentWorkplace.CurrentWork);
            query.Parameters.AddWithValue("@Description", currentWorkplace.Description);
            query.ExecuteReader();
        }
        //wyswietlenie aktualnego miejsca pracy danego uzytkownika
        public static CurrentWorkplace GetCurrentWorkplace(int id)
        {
            CurrentWorkplace workplace = new CurrentWorkplace();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM CurrentWorkplace WHERE UserID=@ID",connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                CurrentWorkplace current = new CurrentWorkplace(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));
                workplace = current;
            }
            return workplace;
        }
        //edycja aktualne miejsca pracy
        public static void EditCurrentWorkplace(CurrentWorkplace workplace, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE CurrentWorkplace SET CurrentWork=@CurrentWork, Description=@Description WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@CurrentWork", workplace.CurrentWork);
            query.Parameters.AddWithValue("@Description", workplace.Description);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //dodawanie podsumowania zawodowego
        public static void AddWorkSummary(WorkSummary workSummary)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO WorkSummary (UserID, Summary) VALUES(@UserID,@Summary)", connection);
            query.Parameters.AddWithValue("@Summary", workSummary.Summary);
            query.Parameters.AddWithValue("@UserID", workSummary.UserID);
            query.ExecuteReader();
        }
        //wyswietlanie podsumowania zawodowego danego uzytkownika
        public static WorkSummary GetWorkSummary(int id)
        {
            WorkSummary workSummary = new WorkSummary();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM WorkSummary WHERE UserID = @ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                WorkSummary summary = new WorkSummary(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                workSummary = summary;
            }
            return workSummary;
        }
        //Edycja podsumowania zawodowego
        public static void EditWorkSummary(WorkSummary summary, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE WorkSummary SET Summary=@Summary WHERE UserID=@ID",connection);
            query.Parameters.AddWithValue("@Summary", summary.Summary);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //Dodanie znajmosci jezykowej
        public static void AddLanguageKnowledge(LanguagesKnowledge knowledge)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO LanguagesKnowledge(UserID, Language, LevelOfKnowledge) VALUES(@UserID, @Language, @LevelOfKnowledge)", connection);
            query.Parameters.AddWithValue("@UserID",knowledge.UserID);
            query.Parameters.AddWithValue("@Language",knowledge.Language);
            query.Parameters.AddWithValue("@LevelOfKnowledge",knowledge.LevelOfKnowledge);
            query.ExecuteReader();
        }
        //Wyswietlanie znajomosci jezykowej danego uzytkownika
        public static List<LanguagesKnowledge> GetLanguagesKnowledge(int id)
        {
            List<LanguagesKnowledge> languages = new List<LanguagesKnowledge>();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM LanguagesKnowledge WHERE UserID=@UserID",connection);
            query.Parameters.AddWithValue("@UserID", id);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                LanguagesKnowledge languagesKnowledge = new LanguagesKnowledge(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));
                languages.Add(languagesKnowledge);
            }
            return languages;
        }
        //Edycja znajomosci jezykowej
        public static void EditLanguageKnowledge(LanguagesKnowledge languagesKnowledge, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE LanguagesKnowledge SET Language=@Language, LevelOfKnowledge=@LevelOfKnowledge WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@Language", languagesKnowledge.Language);
            query.Parameters.AddWithValue("@LevelOfKnowledge", languagesKnowledge.LevelOfKnowledge);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //Usuwanie jezyka
        public static void DeleteLanguageKnowledge(int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM LanguagesKnowledge WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //Dodawanie umiejetnosci
        public static void AddSkills(Skills skills)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Skills (UserID, Skill) VALUES(@UserID, @Skill)",connection);
            query.Parameters.AddWithValue("@UserID", skills.UserID);
            query.Parameters.AddWithValue("@Skill", skills.Skill);
            query.ExecuteReader();
        }
        //wyswietlanie umiejetnosci
        public static List<Skills> GetSkills(int id)
        {
            List<Skills> skills = new List<Skills>();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Skills WHERE UserID=@ID",connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                Skills skill = new Skills(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                skills.Add(skill);
            }
            return skills;
        }
        //Edycja umiejetnosci
        public static void EditSkills(Skills skills, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Skills SET Skill=@Skill WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@Skill", skills.Skill);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //Usuwanie Umiejetnosci
        public static void DeleteSkills(int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Skills WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //dodawanie doswiadczenia zawodowego
        public static void AddExperience(Experience experience)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Experience(UserID, Position, CompanyName, Localization, EmploymentPeriod, Duties) VALUES(@UserID, @Position, @CompanyName, @Localization, @EmploymentPeriod, @Duties)", connection);
            query.Parameters.AddWithValue("@UserID", experience.UserID);
            query.Parameters.AddWithValue("@Position", experience.Position);
            query.Parameters.AddWithValue("@CompanyName", experience.CompanyName);
            query.Parameters.AddWithValue("@Localization", experience.Localization);
            query.Parameters.AddWithValue("@EmploymentPeriod", experience.EmplymentPeriod);
            query.Parameters.AddWithValue("@Duties", experience.Duties);
            query.ExecuteReader();
        }
        //wyswietlanie doswiadczenia zawodowego
        public static List<Experience> GetExperiences(int id)
        {
            List<Experience> experiences = new List<Experience>();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Experience WHERE UserID=@ID",connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                Experience experience = new Experience(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                experiences.Add(experience);
            }
            return experiences;
        }
        //edycja doswiadczenia zawodowego
        public static void EditExperience(Experience experience, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Experience SET Position=@Position, CompanyName=@CompanyName, Localization=@Localization, EmploymentPeriod=@EmploymentPeriod, Duties=@Duties WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@Position", experience.Position);
            query.Parameters.AddWithValue("@CompanyName", experience.CompanyName);
            query.Parameters.AddWithValue("@Localization", experience.Localization);
            query.Parameters.AddWithValue("@EmploymentPeriod", experience.EmplymentPeriod);
            query.Parameters.AddWithValue("@Duties", experience.Duties);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteNonQuery();
        }
        //usuwanie doswiadczenia zawodowego
        public static void DeleteExperience(int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Experience WHERE ID=@ID",connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //dodawanie edukacji
        public static void AddEducation(Education education)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Education(UserID, SchoolName, Localization, DegreeLevel, FieldOfStudy, EducationPeriod) VALUES(@UserID, @SchoolName, @Localization, @DegreeLevel, @FieldOfStudy, @EducationPeriod)", connection);
            query.Parameters.AddWithValue("@UserID", education.UserID);
            query.Parameters.AddWithValue("@SchoolName", education.SchoolName);
            query.Parameters.AddWithValue("@Localization", education.Localization);
            query.Parameters.AddWithValue("@DegreeLevel", education.DegreeLevel);
            query.Parameters.AddWithValue("@FieldOfStudy", education.FieldOfStudy);
            query.Parameters.AddWithValue("@EducationPeriod", education.EducationPeriod);
            query.ExecuteReader();
        }
        //wyswietlanie edukacji
        public static List<Education> GetEducations(int ID)
        {
            List<Education> educations = new List<Education>();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Education WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", ID);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                Education education = new Education(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                educations.Add(education);
            }
            return educations;
        }
        //edycja edukacja
        public static void EditEducation(Education education, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Education SET SchoolName=@SchoolName, Localization=@Localization, DegreeLevel=@DegreeLevel, FieldOfStudy=@FieldOfStudy, EducationPeriod=@EducationPeriod WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@SchoolName", education.SchoolName);
            query.Parameters.AddWithValue("@Localization", education.Localization);
            query.Parameters.AddWithValue("@DegreeLevel", education.DegreeLevel);
            query.Parameters.AddWithValue("@FieldOfStudy", education.FieldOfStudy);
            query.Parameters.AddWithValue("@EducationPeriod", education.EducationPeriod);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //usuwanie edukacji
        public static void DeleteEducation(int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Education WHERE ID=@ID",connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //dodawanie kursow
        public static void AddCourses(Courses courses)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Courses(UserID, CourseName, Organizer, CoursePeriod) VALUES(@UserID, @CourseName, @Organizer, @CoursePeriod)", connection);
            query.Parameters.AddWithValue("@UserID", courses.UserID);
            query.Parameters.AddWithValue("@CourseName", courses.CourseName);
            query.Parameters.AddWithValue("@Organizer", courses.Organizer);
            query.Parameters.AddWithValue("@CoursePeriod", courses.CoursePeriod);
            query.ExecuteReader();
        }
        //wyswietlanie kursow
        public static List<Courses> GetCourses(int id)
        {
            List<Courses> courses = new List<Courses>();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Courses WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                Courses course = new Courses(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                courses.Add(course);
            }
            return courses;
        }
        //edycja kursow
        public static void EditCourses(Courses courses, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Courses SET CourseName=@CourseName, Organizer=@Organizer, CoursePeriod=@CoursePeriod WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@CourseName", courses.CourseName);
            query.Parameters.AddWithValue("@Organizer", courses.Organizer);
            query.Parameters.AddWithValue("@CoursePeriod", courses.CoursePeriod);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //usuwanie kursow
        public static void DeleteCourses(int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Courses WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //dodawanie linkow
        public static void AddLinks(Links link)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Links(UserID, Link) VALUES(@UserID, @Link)", connection);
            query.Parameters.AddWithValue("@UserID", link.UserID);
            query.Parameters.AddWithValue("@Link", link.Link);
            query.ExecuteReader();
        }
        //wyswietlanie linkow
        public static List<Links> GetLinks(int id)
        {
            List<Links> links = new List<Links>();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Links WHERE UserID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                Links link = new Links(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                links.Add(link);
            }
            return links;
        }
        //edycja linkow
        public static void EditLinks(Links links, int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("UPDATE Links SET Link=@Link WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@Link", links.Link);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //usuwanie linkow
        public static void DeleteLinks(int id)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("DELETE FROM Links WHERE ID=@ID", connection);
            query.Parameters.AddWithValue("@ID", id);
            query.ExecuteReader();
        }
        //dodawanie ofert
        public static void AddOffer(Offers offer)
        {
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("INSERT INTO Offers(Position, Company, EndDate, Localization, Price, Category) VALUES(@Position, @Company, @EndDate, @Localization, @Price, @Category)", connection);
            query.Parameters.AddWithValue("@Position", offer.Position);
            query.Parameters.AddWithValue("@Company", offer.Company);
            query.Parameters.AddWithValue("@EndDate", offer.EndDate);
            query.Parameters.AddWithValue("@Localization", offer.Localization);
            query.Parameters.AddWithValue("@Price", offer.Price);
            query.Parameters.AddWithValue("@Category", offer.Category);
            query.ExecuteReader();
        }
        //wyswietlanie ofert
        public static List<Offers> GetOffers()
        {
            List<Offers> offers = new List<Offers>();
            var connection = new SqliteConnection($"Filename={dbPath}");
            connection.Open();
            var query = new SqliteCommand("SELECT * FROM Offers", connection);
            SqliteDataReader reader = query.ExecuteReader();
            while(reader.Read())
            {
                Offers offer = new Offers(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                offers.Add(offer);
            }
            return offers;
        }

    }
}
