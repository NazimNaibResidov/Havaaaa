using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA.Common.DataLayer;
using WA.Common.WeatherGrabber;

namespace WA.MainData.Core
{
    public class Helpers
    {
        private static IStorage _storage;

        public Helpers(IStorage storage)
        {
            _storage = storage;
        }

        public static List<string> GetAvailableCitiesForTomorrow(DateTime today)
        {
            return _storage.GetCitiesForTomorrow(today).Select(c => c.Name).ToList();
        }

        public static WeatherInfo GetWeatherInfo(string cityName, DateTime today)
        {
            return _storage.GetWeatherForTomorowByCityName(cityName, today);
        }
    }
}
