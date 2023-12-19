using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class Courses
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CourseName { get; set; }
        public string Organizer { get; set; }
        public string CoursePeriod { get; set; }
        public Courses()
        {

        }

        public Courses(string courseName, string organizer, string coursePeriod)
        {
            CourseName = courseName;
            Organizer = organizer;
            CoursePeriod = coursePeriod;
        }

        public Courses(int userID, string courseName, string organizer, string coursePeriod)
        {
            UserID = userID;
            CourseName = courseName;
            Organizer = organizer;
            CoursePeriod = coursePeriod;
        }

        public Courses(int iD, int userID, string courseName, string organizer, string coursePeriod)
        {
            ID = iD;
            UserID = userID;
            CourseName = courseName;
            Organizer = organizer;
            CoursePeriod = coursePeriod;
        }
    }
}
