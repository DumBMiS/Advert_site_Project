using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class Education
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public String SchoolName { get; set; }
        public string Localization { get; set; }
        public string DegreeLevel { get; set; }
        public string FieldOfStudy { get; set; }
        public string EducationPeriod { get; set; }
        public Education()
        {

        }

        public Education(int iD, int userID, string schoolName, string localization, string degreeLevel, string fieldOfStudy, string educationPeriod)
        {
            ID = iD;
            UserID = userID;
            SchoolName = schoolName;
            Localization = localization;
            DegreeLevel = degreeLevel;
            FieldOfStudy = fieldOfStudy;
            EducationPeriod = educationPeriod;
        }

        public Education(int userID, string schoolName, string localization, string degreeLevel, string fieldOfStudy, string educationPeriod)
        {
            UserID = userID;
            SchoolName = schoolName;
            Localization = localization;
            DegreeLevel = degreeLevel;
            FieldOfStudy = fieldOfStudy;
            EducationPeriod = educationPeriod;
        }

        public Education(string schoolName, string localization, string degreeLevel, string fieldOfStudy, string educationPeriod)
        {
            SchoolName = schoolName;
            Localization = localization;
            DegreeLevel = degreeLevel;
            FieldOfStudy = fieldOfStudy;
            EducationPeriod = educationPeriod;
        }
    }
}
