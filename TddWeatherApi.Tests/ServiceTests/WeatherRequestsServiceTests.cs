using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TddWeatherApi.AppInterfaces;
using TddWeatherApi.AppServices;
using Xunit;

namespace TddWeatherApi.Tests.ServiceTests
{
    public class WeatherRequestsServiceTests
    {
        private readonly IWeatherRequestsService _weatherRequestsService;

        public WeatherRequestsServiceTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IWeatherRequestsService, WeatherRequestsService>();

            var serviceProvider = services.BuildServiceProvider();
            _weatherRequestsService = serviceProvider.GetService<IWeatherRequestsService>();
        }
 
    }
}
