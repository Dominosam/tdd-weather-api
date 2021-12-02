using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using TddWeatherApi.AppServices.Models;

namespace TddWeatherApi.AppInterfaces
{
    public interface IApiConnectionService
    {
        public Task<bool> HasConnection(ApiConnectionParameters apiConnectionParameters);
        public Task<ApiConnectionResponseModel> GetResponse(ApiConnectionParameters apiConnectionParameters);
        public string GetApiURI(ApiConnectionParameters apiConnectionParameters);
        public string MapNameValueCollectionToQueryString(NameValueCollection nameValueCollection);
        public string GetLocationParameter(string cityName = "", string stateCode = "", string countryCode = "");

    }
}
