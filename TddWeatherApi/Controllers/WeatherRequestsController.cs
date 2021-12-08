using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddWeatherApi.AppInterfaces;
using TddWeatherApi.AppServices.Models;

namespace TddWeatherApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Weather/Requests")]
    [ApiVersion("1.0")]
    [ApiController]
    public class WeatherRequestsController : ControllerBase
    {
        private IApiConnectionService _apiConnectionService;

        public WeatherRequestsController(IApiConnectionService apiConnectionService)
        {
            _apiConnectionService = apiConnectionService;
        }

        public Task GetWeather(ApiConnectionParameters apiConnectionParameters)
        {
            throw new NotImplementedException();
        }
    }
}
