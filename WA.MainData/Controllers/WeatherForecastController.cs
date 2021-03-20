using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WA.Common.ApiClient;
using WA.Common.DataLayer;
using WA.Common.WeatherGrabber;
using WA.MainData.Core;

namespace WA.MainData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase, IApiClient
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAvailableCitiesForTomorrow()
        {
           return Helpers.GetAvailableCitiesForTomorrow(DateTime.Now);
        }

        public WeatherInfo GetWeatherInfo(string cityName)
        {
            return Helpers.GetWeatherInfo(cityName, DateTime.Today);
        }

        public void Open(string host, int port)
        {
            throw new NotImplementedException();
        }
    }
}
