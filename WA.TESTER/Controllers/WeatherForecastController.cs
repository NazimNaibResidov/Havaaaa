using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WA.Common.DataLayer;
using WA.Common.WeatherGrabber;

namespace WA.TESTER.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IStorage _storage;
        public WeatherForecastController(IStorage storage)
        {
            this._storage = storage;
        }
        [HttpGet]
        public List<string> GetAvailableCitiesForTomorrow(DateTime today)
        {
            return _storage.GetCitiesForTomorrow(today).Select(c => c.Name).ToList();
        }
        [HttpGet]
        public WeatherInfo GetWeatherInfo(string cityName, DateTime today)
        {
            return _storage.GetWeatherForTomorowByCityName(cityName, today);
        }
        public void Bind(string host, int port, IStorage storage)
        {
            
            var config =  new ServiceHost(new WeatherForecastController(storage), new Uri($"http://{host}:{port}"));

          
            config.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });
            // concurrencyMode
            var behavior = config.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            behavior.ConcurrencyMode = ConcurrencyMode.Multiple;
            behavior.UseSynchronizationContext = false;
            behavior.InstanceContextMode = InstanceContextMode.Single;

            config.Open();
        }
    }
}
