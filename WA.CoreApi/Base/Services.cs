using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA.Common.API;
using WA.Common.DataLayer;
using WA.IOC;

namespace WA.CoreApi.Base
{
    public static class Services
    {
        private static IApi _api;
        public static void StopService()
        {
            _api?.UnBind();
        }

        public static void StartService(string host, int port)
        {
            _api = Ioc.Resolve<IApi>();
            var storage = Ioc.Resolve<IStorage>();
            _api.Bind(host, port, storage);
        }
    }
}
