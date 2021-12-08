using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TddWeatherApi.AppInterfaces;
using TddWeatherApi.AppServices;
using TddWeatherApi.AppServices.Models;
using TddWeatherApi.Controllers;
using Xunit;

namespace TddWeatherApi.Tests.ControllerTests
{
    public class WeatherRequestsControllerTests
    {
        private readonly IApiConnectionService _apiConnectionService;
        private readonly string BaseURL = "http://api.openweathermap.org/data/2.5";
        private readonly string ApiKey = "638a97f54d47a234a32247ca1e3ad366";

        public WeatherRequestsControllerTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IApiConnectionService, ApiConnectionService>();

            var serviceProvider = services.BuildServiceProvider();

            _apiConnectionService = serviceProvider.GetService<IApiConnectionService>();
        }
        [Fact]
        public void GetWeather_WithInvalidStateModel_ReturnsBadRequest()
        {
            //Arrange
            WeatherRequestsController weatherRequestsController = new WeatherRequestsController(_apiConnectionService);
            weatherRequestsController.ModelState.AddModelError("SessionName", "Required");

            var cityName = "Warsaw";

            var apiConnectionParameters = new ApiConnectionParameters()
            {
                CityName = cityName,
                ApiKey = ApiKey,
                OpenWeatherApiURL = BaseURL
            };

            //Act
            //var result = await weatherRequestsController.GetWeather(apiConnectionParameters);
            
        }
    }
}
