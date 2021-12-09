using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TddWeatherApi.AppInterfaces;
using TddWeatherApi.AppServices.Models;
using TddWeatherApi.Utils.Models;

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

        #region

        internal const string GET_WEATHER_FORECAST_BY_CONNECTION_PARAMETERS = "GetRequestedWeatherForecast";

        #endregion


        [ProducesResponseType(typeof(ApiResponseMessageModel<ApiConnectionResponseModel>), 200)]
        [ProducesResponseType(typeof(ApiMessageModel), 400)]
        [ProducesResponseType(typeof(ApiMessageModel), 404)]
        [ProducesResponseType(typeof(ApiMessageModel), 500)]
        [HttpPost("Local", Name = GET_WEATHER_FORECAST_BY_CONNECTION_PARAMETERS)]
        public async Task<IActionResult> GetWeather(ApiConnectionParameters apiConnectionParameters)
        {
            var responseModel = await _apiConnectionService.GetResponse(apiConnectionParameters);

            if(responseModel == null)
            {
                return NotFound(new ApiMessageModel(404, "Weather forecast not found for given parameters"));
            }
            return Ok(new ApiResponseMessageModel<ApiConnectionResponseModel>(responseModel, "Fingers crossed for a sunny day!"));
        }
    }
}
