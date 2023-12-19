using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class LanguagesKnowledge
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Language { get; set; }
        public string LevelOfKnowledge { get; set; }
        public LanguagesKnowledge()
        {

        }

        public LanguagesKnowledge(string language, string levelOfKnowledge)
        {
            Language = language;
            LevelOfKnowledge = levelOfKnowledge;
        }

        public LanguagesKnowledge(int iD, int userID, string language, string levelOfKnowledge)
        {
            ID = iD;
            UserID = userID;
            Language = language;
            LevelOfKnowledge = levelOfKnowledge;
        }
    }
}
