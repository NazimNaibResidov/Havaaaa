using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WA.ACore.Core;
using WA.Common.ApiClient;
using WA.Common.Visual;

namespace WA.ACore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public MainVM MainVM { get; }

        private readonly UIElement _weatherControl;
        private readonly IVisualComponent _wcInterface;
        private readonly IApiClient _apiClient;

        public WeatherForecastController()
        {
            var host = ConfigurationManager.AppSettings["host"];
            if (!int.TryParse(ConfigurationManager.AppSettings["port"], out int port) || string.IsNullOrEmpty(host))
            {
              
               
                return;
            }

            

            _apiClient = Ioc.Resolve<IApiClient>();
            _apiClient.Open(host, port);
            MainVM = new MainVM(_apiClient);

            DataContext = MainVM;

            var wc = Ioc.Resolve<IVisual>().GetVisualComponent();
            _wcInterface = wc;
            if (wc.IsWpfCompatible)
            {
                _weatherControl = (UIElement)wc.Control;
            }
            else
            {
                _weatherControl = new WindowsFormsHost() { Child = (System.Windows.Forms.Control)wc.Control };
            }
            Body.Content = _weatherControl;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
