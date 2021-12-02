using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TddWeatherApi.AppServices.Models.Enums;

namespace TddWeatherApi.AppServices.Models
{
    public class ApiConnectionParameters
    {
        public string OpenWeatherApiURL { get; set; }
        public string ApiKey { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public ReturnFormat Mode { get; set; }
        public UnitOfMeasurement Units { get; set; }
        public string Lang { get; set; }
    }
}
