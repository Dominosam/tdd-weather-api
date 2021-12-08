using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace TddWeatherApi.AppServices.Models
{

    public class ApiConnectionResponseModel
    {
        public Coordinates Coordinates { get; set; }
        public GeneralWeatherData GeneralWeatherData { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
