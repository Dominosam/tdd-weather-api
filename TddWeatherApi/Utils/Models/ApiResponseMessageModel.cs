using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TddWeatherApi.Utils.Models
{
    public class ApiResponseMessageModel<T>
    {
        public string Message { get; set; }
        public T Result { get; set; }

        public ApiResponseMessageModel(T result, string message = "")
        {
            Message = message  == String.Empty ? "Success" : message;
            Result = result;
        }
    }
}
