using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using TddWeatherApi.AppInterfaces;
using TddWeatherApi.AppServices;
using TddWeatherApi.AppServices.Models;
using Xunit;

namespace TddWeatherApi.Tests.ServiceTests
{
    public class ApiConnectionServiceTests
    {
        private readonly IApiConnectionService _apiConnectionService;
        private readonly string BaseURL = "api.openweathermap.org/data/2.5";
        private readonly string ApiKey = "638a97f54d47a234a32247ca1e3ad366";

        public ApiConnectionServiceTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IApiConnectionService, ApiConnectionService>();

            var serviceProvider = services.BuildServiceProvider();
            _apiConnectionService = serviceProvider.GetService<IApiConnectionService>();

        }


        [Fact]
        public void GetApiURI_WithGivenParameters_ReturnsApiURI()
        {
            var cityName = "Warsaw";

            var apiConnectionParameters = new ApiConnectionParameters()
            {
                CityName = cityName,
                ApiKey = ApiKey,
                OpenWeatherApiURL = BaseURL
            };

            //Arrange
            var expectedURI = string.Format("{0}{1}&appid={2}", BaseURL, "/weather?q=" + cityName, ApiKey);

            //Act
            string builtURI = _apiConnectionService.GetApiURI(apiConnectionParameters);

            //Assert
            Assert.Equal(expectedURI, builtURI);
        }

        [Fact]
        public void GetQueryString_WithGivenNameValueCollection_ReturnsJoinedQuery()
        {
            var cityName = "Warsaw";
            NameValueCollection nameValueCollection = new NameValueCollection()
            {
                {"q", cityName },
                {"appid", ApiKey }
            };

            //Arrange
            var expectedQueryString = string.Format("q={0}&appid={1}", cityName, ApiKey);

            //Act
            string builtQueryString = _apiConnectionService.MapNameValueCollectionToQueryString(nameValueCollection);

            //Assert
            Assert.Equal(expectedQueryString, builtQueryString);
        }

        [Fact]
        public void GetLocationParameter_WithGivenLocationParameters_ReturnsParameter()
        {
            var cityName = "Warsaw";
            var stateCode = "PL-14";
            var countryCode = "PL";

            //Arrange
            var expectedFullParameter = string.Format("{0},{1},{2}",
                cityName, stateCode, countryCode);

            var expectedSingleParameter = string.Format("{0}",
                cityName);

            //Act
            string builtFullParameter = _apiConnectionService.GetLocationParameter(cityName, stateCode, countryCode);
            string builtSingleParameter = _apiConnectionService.GetLocationParameter(cityName: cityName);

            //Assert
            Assert.Equal(expectedFullParameter, builtFullParameter);
            Assert.Equal(expectedSingleParameter, builtSingleParameter);
        }

        [Fact]
        public void GetApiURI_WithGivenSpecificParameters_ReturnsApiURI()
        {
            var cityName = "Warsaw";
            var stateCode = "PL-14";
            var countryCode = "PL";

            var apiConnectionParameters = new ApiConnectionParameters()
            {
                CityName = cityName,
                ApiKey = ApiKey,
                OpenWeatherApiURL = BaseURL,
                StateCode = stateCode,
                CountryCode = countryCode,
                Mode = AppServices.Models.Enums.ReturnFormat.JSON,
                Units = AppServices.Models.Enums.UnitOfMeasurement.Metric,
                Lang = "en"
            };

            //Arrange
            var expectedURI = string.Format("{0}{1}{2}%2c{3}%2c{4}&units={5}&lang={6}&appid={7}",
                BaseURL, "/weather?q=", cityName, stateCode, countryCode, "metric", "en", ApiKey);

            //Act
            string builtURI = _apiConnectionService.GetApiURI(apiConnectionParameters);

            //Assert
            Assert.Equal(expectedURI, builtURI);
        }

        [Fact]
        public void GetResponse_WithGivenParameters_ReturnsApiResponse()
        {
            var cityName = "Warsaw";
            var stateCode = "PL-14";
            var countryCode = "PL";

            var apiConnectionParameters = new ApiConnectionParameters()
            {
                CityName = cityName,
                ApiKey = ApiKey,
                OpenWeatherApiURL = BaseURL,
                StateCode = stateCode,
                CountryCode = countryCode,
                Mode = AppServices.Models.Enums.ReturnFormat.JSON,
                Units = AppServices.Models.Enums.UnitOfMeasurement.Metric,
                Lang = "en"
            };

            var expectedConnectionResponse = new ApiConnectionResponseModel()
            {

            };
        }
    }
}
