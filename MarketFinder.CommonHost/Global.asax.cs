using System.Web;
using System.Web.Http;

namespace MarketFinder.CommonHost
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
