using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddWeatherApi.AppInterfaces;

namespace TddWeatherApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Weather/Requests")]
    [ApiVersion("1.0")]
    [ApiController]
    public class WeatherRequestsController : ControllerBase
    {
        private readonly IWeatherRequestsService _weatherRequestsService;
    }
}
