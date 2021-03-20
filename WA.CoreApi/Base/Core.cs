using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WA.Common.API;
using WA.Common.DataLayer;
using WA.IOC;

namespace WA.CoreApi.Base
{
    public static class Core
    {
       
        public static void Load(this IConfiguration configuration)
        {
        
             var host = configuration.GetSection("host").Value;
            if (!int.TryParse(configuration.GetSection("port").Value, out int port) || string.IsNullOrEmpty(host))
            {
                Console.WriteLine("InvalidConfig");
                Console.ReadLine();
            }
            else
            {
                Services.StartService(host, port);
                Console.ReadLine();
                Services.StopService();
            }
            
        }
     
    }
}
