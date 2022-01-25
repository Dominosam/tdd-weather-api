using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddWeatherApi.Utils.Interfaces;

namespace TddWeatherApi.Utils
{
    public class Calculator : ICalculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}


