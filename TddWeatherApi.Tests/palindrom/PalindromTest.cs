using System;
using System.Collections.Generic;
using System.Text;
using TddWeatherApi.Utils;
using Xunit;

namespace TddWeatherApi.Tests.palindrom
{
    public class PalindromTest
    {
        [Fact]
        public void IsPalindromTest()
        {
            //Arrange
            string kayakStr = "kayak";
            Palindrom palindrom = new Palindrom();
            
            //Act
            var result = palindrom.isPalindrom(kayakStr);

            //Assert
            Assert.True(result);
        }
    }
}


















