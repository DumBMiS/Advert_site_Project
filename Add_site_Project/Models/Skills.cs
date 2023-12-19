using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class Skills
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Skill { get; set; }
        public Skills()
        {

        }

        public Skills(int iD, int userID, string skill)
        {
            ID = iD;
            UserID = userID;
            Skill = skill;
        }

        public Skills(int userID, string skill)
        {
            UserID = userID;
            Skill = skill;
        }

        public Skills(string skill)
        {
            Skill = skill;
        }
    }
}
