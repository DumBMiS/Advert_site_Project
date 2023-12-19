using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class Links
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Link { get; set; }
        public Links()
        {
                
        }

        public Links(int iD, int userID, string link)
        {
            ID = iD;
            UserID = userID;
            Link = link;
        }

        public Links(int userID, string link)
        {
            UserID = userID;
            Link = link;
        }

        public Links(string link)
        {
            Link = link;
        }
    }
}
