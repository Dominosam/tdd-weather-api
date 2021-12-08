using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TddWeatherApi.AppServices.Models.DTOs
{
    public class ApiConnectionResponseModelDto
    {
        public ResponseModelCoordDTO coord { get; set; }
        public ResponseModelWeatherDto[] weather { get; set; }
        public string _base { get; set; }
        public ResponseModelMainDto main { get; set; }
        public int visibility { get; set; }
        public ResponseModelWindDto wind { get; set; }
        public ResponseModelCloudsDto clouds { get; set; }
        public int dt { get; set; }
        public ResponseModelSysDto sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

    }
}
