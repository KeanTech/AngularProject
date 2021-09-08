using System.Web.Http;
using ZBCTempInfoApi.App_Start;

namespace ZBCTempInfoApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
    
        }
    }
}
