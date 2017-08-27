using System.Diagnostics.CodeAnalysis;
using System.Web.Http;
using MailgunWebhooks.Mapper;

namespace MailgunWebhooks
{
    [ExcludeFromCodeCoverage]
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrapper.Register();
            AutoMapper.Mapper.Initialize(cfg => { cfg.AddProfile<MapperProfile>(); });
        }
    }
}
