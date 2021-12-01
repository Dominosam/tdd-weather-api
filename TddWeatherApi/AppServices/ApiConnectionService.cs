using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TddWeatherApi.AppInterfaces;
using TddWeatherApi.AppServices.Models;

namespace TddWeatherApi.AppServices
{
    public class ApiConnectionService : IApiConnectionService
    {
        public string GetApiURI(ApiConnectionParameters apiConnectionParameters)
        {
            var paramatersCollection = new NameValueCollection();


            if (!string.IsNullOrWhiteSpace(apiConnectionParameters.CityName))
            {
                paramatersCollection["q"] = apiConnectionParameters.CityName;
            }

            if (!string.IsNullOrWhiteSpace(apiConnectionParameters.ApiKey))
            {
                paramatersCollection["appid"] = apiConnectionParameters.ApiKey; 
            }
            var xd = ConfigurationManager.AppSettings["BaseURL"];

            return apiConnectionParameters.OpenWeatherApiURL + "/weather?" + MapNameValueCollectionToQueryString(paramatersCollection);
        }

        public Task<ApiConnectionResponseModel> GetResponse(ApiConnectionParameters apiConnectionParameters)
        {
            //var xd = new NameValueCollection();
            throw new NotImplementedException();
        }

        public Task<bool> HasConnection(ApiConnectionParameters apiConnectionParameters)
        {
            throw new NotImplementedException();
        }

        public string MapNameValueCollectionToQueryString(NameValueCollection nameValueCollection)
        {
            return string.Join("&", nameValueCollection.AllKeys.Select(nv => nv + "=" + HttpUtility.UrlEncode(nameValueCollection[nv])));
        }
    }
}
