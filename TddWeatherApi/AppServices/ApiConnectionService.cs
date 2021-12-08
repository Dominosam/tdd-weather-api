using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TddWeatherApi.AppInterfaces;
using TddWeatherApi.AppServices.Models;
using TddWeatherApi.AppServices.Models.DTOs;
using TddWeatherApi.Helpers;

namespace TddWeatherApi.AppServices
{
    public class ApiConnectionService : IApiConnectionService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IMapper _mapper;

        public ApiConnectionService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public string GetApiURI(ApiConnectionParameters apiConnectionParameters)
        {
            var paramatersCollection = new NameValueCollection();

            if (!string.IsNullOrWhiteSpace(apiConnectionParameters.CityName) || !string.IsNullOrWhiteSpace(apiConnectionParameters.StateCode) || !string.IsNullOrWhiteSpace(apiConnectionParameters.CountryCode))
            {
                paramatersCollection["q"] = GetLocationParameter(apiConnectionParameters.CityName, apiConnectionParameters.StateCode, apiConnectionParameters.CountryCode);
            }

            if(apiConnectionParameters.Mode != Models.Enums.ReturnFormat.JSON){
                paramatersCollection["mode"] = Enum.GetName(typeof(Models.Enums.ReturnFormat), apiConnectionParameters.Mode);
            }

            if (apiConnectionParameters.Units != Models.Enums.UnitOfMeasurement.Standard) 
            {
                paramatersCollection["units"] = Enum.GetName(typeof(Models.Enums.UnitOfMeasurement), apiConnectionParameters.Units).ToLower();
            }

            if (!string.IsNullOrWhiteSpace(apiConnectionParameters.Lang))
            {
                paramatersCollection["lang"] = apiConnectionParameters.Lang;
            }

            if (!string.IsNullOrWhiteSpace(apiConnectionParameters.ApiKey))
            {
                paramatersCollection["appid"] = apiConnectionParameters.ApiKey;
            }

            return apiConnectionParameters.OpenWeatherApiURL + "/weather?" + MapNameValueCollectionToQueryString(paramatersCollection);
        }

        public async Task<ApiConnectionResponseModel> GetResponse(ApiConnectionParameters apiConnectionParameters)
        {
            ApiConnectionResponseModel result = null;
            var httpRequest = new HttpRequestMessage();
            var connectionUri = new Uri(GetApiURI(apiConnectionParameters));
            httpRequest.RequestUri = connectionUri;

            var response = _httpClient.SendAsync(httpRequest);
            try
            {
                var stringContent = await response.Result.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<ApiConnectionResponseModelDto>(stringContent);
                result = AutoMapperConfiguration.Mapper.Map<ApiConnectionResponseModelDto, ApiConnectionResponseModel>(dto);
            }
            finally
            {
                response.Dispose();
            }
            return result;
        }

        public Task<bool> HasConnection(ApiConnectionParameters apiConnectionParameters)
        {
            throw new NotImplementedException();
        }

        public string MapNameValueCollectionToQueryString(NameValueCollection nameValueCollection)
        {
            return String.Join("&", nameValueCollection.AllKeys.Select(
                    nv => nv + "=" + HttpUtility.UrlEncode(nameValueCollection[nv])
                ));
        }

        public string GetLocationParameter(string cityName = "", string stateCode = "", string countryCode = "")
        {
            return String.Join(",", new List<string>() { cityName ?? "", stateCode ?? "", countryCode ?? "" }.Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}
