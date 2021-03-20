using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WA.Common.MYSQLData
{
    [Table("weather")]
    public class WeatherInfo
    {
        //public List<ShortWeather> Tabs { get; set; }

        public DateTime CurrDate { get; set; }
        public DetailedWeather DetailedWeather { get; set; }
    }
}
