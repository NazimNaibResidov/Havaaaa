using System;

namespace WA.Common.MYSQLData
{
    public class HourDetails
    {
        public TimeSpan Time { get; set; }
        public double Temperature { get; set; }
        public string WindText { get; set; }
        public double Humidity { get; set; }
        public string IconSvg { get; set; }
    }
}
