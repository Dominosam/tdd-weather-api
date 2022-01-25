using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Specflow.Tests
{
    public class Calculator
    {
        public int FirstNumber { get; internal set; }
        public int SecondNumber { get; internal set; }
        public int Add()
        {
            return FirstNumber + SecondNumber;
        }
    }
}
