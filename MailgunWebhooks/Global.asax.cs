using System.Web.Http;

namespace MailgunWebhooks
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrapper.Register();
        }
    }
}
