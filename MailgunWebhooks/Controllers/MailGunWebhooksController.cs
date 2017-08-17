using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Results;
using MailgunWebhooks.Helper;
using MailgunWebhooks.Models;

namespace MailgunWebhooks.Controllers
{
    [RoutePrefix("api/mailgun/event")]
    public class MailGunWebhooksController : ApiController
    {
        private readonly IRequestParser _requestParser;

        public MailGunWebhooksController(IRequestParser requestParser)
        {
            _requestParser = requestParser;
        }

        [Route("deliver")]
        public IHttpActionResult PostDeliver(FormDataCollection formData)
        {
            var result = _requestParser.ProcessFormDataRequest<DeliverRequest>(formData, EventType.Deliver);
            return new StatusCodeResult(result, this);
        }

        [Route("unsubscribe")]
        public IHttpActionResult PostUnsubscribe(FormDataCollection formData)
        {
            var result = _requestParser.ProcessFormDataRequest<DeliverRequest>(formData, EventType.Unsubscribe);
            return new StatusCodeResult(result, this);
        }

        [Route("click")]
        public IHttpActionResult PostClick(FormDataCollection formData)
        {
            var result = _requestParser.ProcessFormDataRequest<DeliverRequest>(formData, EventType.Click);
            return new StatusCodeResult(result, this);
        }

        [Route("open")]
        public IHttpActionResult PostOpen(FormDataCollection formData)
        {
            var result = _requestParser.ProcessFormDataRequest<DeliverRequest>(formData, EventType.Open);
            return new StatusCodeResult(result, this);
        }

        [Route("drop")]
        public IHttpActionResult PostDrop()
        {
            var result = _requestParser.ProcessMultipartRequest<DropRequest>(Request, EventType.Drop);
            return new StatusCodeResult(result, this);
        }

        [Route("bounce")]
        public IHttpActionResult PostBounce()
        {
            var result = _requestParser.ProcessMultipartRequest<DropRequest>(Request, EventType.Bounce);
            return new StatusCodeResult(result, this);
        }

        [Route("spam")]
        public IHttpActionResult PostSpam()
        {
            var result = _requestParser.ProcessMultipartRequest<DropRequest>(Request, EventType.Spam);
            return new StatusCodeResult(result, this);
        }
    }
}