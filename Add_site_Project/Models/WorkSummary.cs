using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class WorkSummary
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Summary { get; set; }
        public WorkSummary()
        {

        }

        public WorkSummary(int iD, int userID, string summary)
        {
            ID = iD;
            UserID = userID;
            Summary = summary;
        }
    }
}
