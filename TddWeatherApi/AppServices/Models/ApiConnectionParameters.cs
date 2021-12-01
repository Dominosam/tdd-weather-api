using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace TddWeatherApi.AppServices.Models
{
    public class ApiConnectionParameters
    {
        public string OpenWeatherApiURL { get; set; }
        public string ApiKey { get; set; }
        public string CityName { get; set; }
    }
}
