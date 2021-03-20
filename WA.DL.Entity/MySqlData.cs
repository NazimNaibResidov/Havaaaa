using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WA.Common.WeatherGrabber;

namespace WA.DL.Entity
{
   public class MySqlDataContext:DbContext
    {
        public MySqlDataContext(DbContextOptions<MySqlDataContext> options)
        {
         
        }
        public DbSet<CityInfo> MyProperty { get; set; }
        public DbSet<DetailedWeather> DetailedWeathers { get; set; }
        public DbSet<ShortWeather> ShortWeathers { get; set; }
        public DbSet<WeatherInfo>  WeatherInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var @string= "server=localhost; port=3306; database=test; user=root; password=Wxp@Mysql; Persist Security Info=False; Connect Timeout=300";
            optionsBuilder.UseMySql(@string, ServerVersion.AutoDetect(@string));
          
        }
    }
}
