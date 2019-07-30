using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesMVC.NETDemo.DAL.Models
{
    public class ChartViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cityName { get; set; }
        public string countryName { get; set; }

        public int population { get; set; }
        public int count { get; set; }

    }
}