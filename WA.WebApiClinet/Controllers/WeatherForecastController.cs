using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Win32.SafeHandles;

namespace WA.WebApiClinet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public IActionResult Add()
        {

        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeAccessTokenHandle phToken);
        const int LOGON32_PROVIDER_DEFAULT = 0;
        //This parameter causes LogonUser to create a primary token.   
        const int LOGON32_LOGON_INTERACTIVE = 2;
        public IActionResult About()
        {
            SafeAccessTokenHandle safeAccessTokenHandle;
            bool returnValue = LogonUser("username", "domain", "password",
                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                out safeAccessTokenHandle);
            WindowsIdentity.RunImpersonated(safeAccessTokenHandle, () =>
            {
                NTLMWebServiceSoapClient client = new NTLMWebServiceSoapClient(NTLMWebServiceSoapClient.EndpointConfiguration.NTLMWebServiceSoap);
                var result = client.HelloWorldAsync().Result;
                ViewData["Message"] = result.Body.HelloWorldResult;
            });

            return View();
        }
    }
}
