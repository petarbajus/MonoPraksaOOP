using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject
{
    internal class City
    {
        public string? CityName { get; set; }
        public string? CityCode { get; set; } 
        public string? Country { get; set; }

        public City(string? cityName) : this(cityName, "000", "Croatia")
        {
        }
        public City()
        {
            CityName = "New York";
            CityCode = "917";
            Country = "USA";
        }

        public City(string? cityName, string? cityCode, string? country)
        {
            CityName = cityName;
            CityCode = cityCode;
            Country = country;
        }


    }
}
