using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WA.Naib.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
            var host = ConfigurationManager.AppSettings["host"];
            if (!int.TryParse(ConfigurationManager.AppSettings["port"], out int port) || string.IsNullOrEmpty(host))
            {
                MessageBox.Show("Invalid Config");
                Shutdown();
            }

            // Start API

            ApiService.Program.StartService(host, port);

            // Start Grabber
            Service.Program.StartService();

            // Start Client
            MainWindow = new MainWindow();
            base.OnStartup(e);
            MainWindow.Show();
        }
    }
}
