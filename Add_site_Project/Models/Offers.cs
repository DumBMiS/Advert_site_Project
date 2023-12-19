using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_site_Project.Models
{
    public class Offers
    {
        public int id { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string EndDate { get; set; }
        public string Localization { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public Offers()
        {

        }

        public Offers(int id, string position, string company, string endDate, string localization, string price, string category)
        {
            this.id = id;
            Position = position;
            Company = company;
            EndDate = endDate;
            Localization = localization;
            Price = price;
            Category = category;
        }

        public Offers(string position, string company, string endDate, string localization, string price, string category)
        {
            Position = position;
            Company = company;
            EndDate = endDate;
            Localization = localization;
            Price = price;
            Category = category;
        }
    }
}
