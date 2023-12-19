using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class CurrentWorkplace
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CurrentWork { get; set; }
        public string Description { get; set; }
        public CurrentWorkplace()
        {

        }
        public CurrentWorkplace(int iD, int userID, string currentWork, string description)
        {
            ID = iD;
            UserID = userID;
            CurrentWork = currentWork;
            Description = description;
        }
        public CurrentWorkplace(int userID, string currentWork, string description)
        {
            UserID = userID;
            CurrentWork = currentWork;
            Description = description;
        }
    }
}
