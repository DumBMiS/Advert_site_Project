using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class BasicUserInfo
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfilePicture { get; set; }

        public BasicUserInfo(int iD, int userID, string name, string surname, string email, string phoneNumber, string adress, DateTime birthDate, string profilePicture)
        {
            ID = iD;
            UserID = userID;
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = adress;
            BirthDate = birthDate;
            ProfilePicture = profilePicture;
        }
        public BasicUserInfo()
        {

        }
    }
}
