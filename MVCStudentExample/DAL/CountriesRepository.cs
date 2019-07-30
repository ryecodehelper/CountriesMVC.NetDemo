using CountriesMVC.NETDemo.DAL;
using CountriesMVC.NETDemo.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountriesMVC.NETDemo.DAL
{
    public class CountriesRepository
    {
        private CountriesContext dbcc;
        public CountriesRepository(CountriesContext countriesContext)
        {
            this.dbcc = countriesContext;
        }
        public List<ChartViewModel> getPopulationbyCountry()
        {
            var countryList = dbcc.Countries.Select(c => new ChartViewModel { id = c.ID, name = c.Name, count = 0 }).OrderBy(c => c.name).ToList();
            var citiesList = dbcc.viewCountries_AllCitiesAndCountries.ToList();
            foreach (var country in countryList)
            {
                var cityFromList = citiesList.Where(c => c.CountryID == country.id && c.Population != null).ToList();
                if (cityFromList.Any())
                {
                    var count = 0;
                    foreach (var city in cityFromList)
                    {
                        count += (int)city.Population;
                    }
                    country.count = count;
                }
            }
            return countryList;
        } 

        public IEnumerable getBarChartData()
        {
            var list = dbcc.viewCountries_AllCitiesAndCountries.Select(c => new { Name = c.CityName + ", " + c.CountryName, Population = c.Population, }).OrderByDescending(c => c.Population).ToList();
            return list.Take(10);
        }
        
        public IEnumerable getTableChartData()
        {
           
            return getPopulationbyCountry().OrderByDescending(c => c.count).Take(20);
        }
        public IEnumerable getPieChartData()
        {
            var list = dbcc.viewCountries_AllCitiesAndCountries.Select(c => new { Name = c.CityName + ", " + c.CountryName, Population = c.Population, }).OrderByDescending(c => c.Population).Take(10).ToList();

            return list;
        }
    }
}