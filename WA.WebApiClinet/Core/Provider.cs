using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA.Common.API;
using WA.Common.DataLayer;

namespace WA.WebApiClinet.Core
{
    public class Provider : IApi
    {
        
        public void Bind(string host, int port, IStorage storage)
        {
            throw new NotImplementedException();
        }

        public void UnBind()
        {
            throw new NotImplementedException();
        }
    }
}
