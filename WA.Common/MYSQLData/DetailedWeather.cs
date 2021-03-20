using System;
using System.Collections.Generic;

namespace WA.Common.MYSQLData
{
    public class DetailedWeather
    {
        public SortedDictionary<TimeSpan, HourDetails> WeatherByHours { get; set; }
    }
}
