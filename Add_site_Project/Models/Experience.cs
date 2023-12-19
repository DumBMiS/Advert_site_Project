using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class Experience
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string Localization { get; set; }
        public string EmplymentPeriod { get; set; }
        public string Duties { get; set; }
        public Experience()
        {

        }

        public Experience(int iD, int userID, string position, string companyName, string localization, string emplymentPeriod, string duties)
        {
            ID = iD;
            UserID = userID;
            Position = position;
            CompanyName = companyName;
            Localization = localization;
            EmplymentPeriod = emplymentPeriod;
            Duties = duties;
        }

        public Experience(string position, string companyName, string localization, string emplymentPeriod, string duties)
        {
            Position = position;
            CompanyName = companyName;
            Localization = localization;
            EmplymentPeriod = emplymentPeriod;
            Duties = duties;
        }

        public Experience(int userID, string position, string companyName, string localization, string emplymentPeriod, string duties)
        {
            UserID = userID;
            Position = position;
            CompanyName = companyName;
            Localization = localization;
            EmplymentPeriod = emplymentPeriod;
            Duties = duties;
        }
    }
}
