using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TddWeatherApi.Utils
{
    public class Palindrom
    {
        public bool isPalindrom(string value)
        {
            return value.SequenceEqual(value.Reverse());
        }
    }
}
