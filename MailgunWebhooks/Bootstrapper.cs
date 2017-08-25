using System.Web.Http;
using MailgunWebhooks.Helper;
using MailgunWebhooks.Validators;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace MailgunWebhooks
{

    public static class Bootstrapper
    {
        public static void Register()
        {
            var apiKey = System.Configuration.ConfigurationManager.AppSettings["MailgunKey"];

            var container = new Container();
            container.Register<IRequestParser, RequestParser>();
            container.Register<IWebhookSignatureValidator>(() => new WebhookSignatureValidator(apiKey));

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}