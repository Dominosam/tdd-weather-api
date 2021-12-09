using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddWeatherApi.AppServices.Models;

namespace TddWeatherApi.Utils.Models
{

    public class ApiMessageModel
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }


        public ApiMessageModel(int statusCode, string message = null, List<string> errors = null)
        {
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Errors = errors;
            StatusCode = statusCode;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "400 Bad request";
                case 404:
                    return "404 Not found";
                case 500:
                    return "500 Internal Server Error";
                default:
                    return null;
            }
        }
    }
}
