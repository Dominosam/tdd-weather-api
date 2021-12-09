using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TddWeatherApi.AppInterfaces;
using TddWeatherApi.AppServices;
using TddWeatherApi.AppServices.Models;
using TddWeatherApi.Controllers;
using TddWeatherApi.Helpers;
using TddWeatherApi.Utils.Models;
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

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            });
            var mapper = config.CreateMapper();
            AutoMapperConfiguration.RegisterMappings();
            services.AddSingleton(mapper);

            var serviceProvider = services.BuildServiceProvider();

            _apiConnectionService = serviceProvider.GetService<IApiConnectionService>();
        }
        [Fact]
        public async Task GetWeather_WithInvalidStateModel_ReturnsNotFoundAsync()
        {
            //Arrange
            WeatherRequestsController weatherRequestsController = new WeatherRequestsController(_apiConnectionService);

            var cityName = "DefinitelyNotWarsaw";

            var apiConnectionParameters = new ApiConnectionParameters()
            {
                CityName = cityName,
                ApiKey = ApiKey,
                OpenWeatherApiURL = BaseURL
            };

            //Act
            var result = await weatherRequestsController.GetWeather(apiConnectionParameters);
            var notFoundResult = result as NotFoundObjectResult;

            //Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task GetWeather_WithValidStateModel_ReturnsOkAsync()
        {
            WeatherRequestsController weatherRequestsController = new WeatherRequestsController(_apiConnectionService);

            var cityName = "Warsaw";

            var apiConnectionParameters = new ApiConnectionParameters()
            {
                CityName = cityName,
                ApiKey = ApiKey,
                OpenWeatherApiURL = BaseURL
            };

            //Act
            var result = await weatherRequestsController.GetWeather(apiConnectionParameters);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
