using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TddWeatherApi.Utils;
using TddWeatherApi.Utils.Interfaces;
using Xunit;

namespace TddWeatherApi.Tests.UtilsTests
{
    public class CalculatorTest
    {
        [Fact]
        public void Add_With2And3_Returns5()
        {
            //Arrange
            var calculator = new Mock<ICalculator>();
            calculator.Setup(x => x.Add(2,3)).Returns(5);

            //Act
            //Assert
            Assert.Equal(5, calculator.Object.Add(2,3));
        }
    }
}




