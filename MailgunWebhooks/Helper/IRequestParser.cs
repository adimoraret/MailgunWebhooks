using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using MailgunWebhooks.Models;

namespace MailgunWebhooks.Helper
{
    public interface IRequestParser
    {
        HttpStatusCode ProcessFormDataRequest<T>(IEnumerable<KeyValuePair<string, string>> formData) where T : WebhookRequest;

        HttpStatusCode ProcessMultipartRequest<T>(HttpRequestMessage request) where T : WebhookRequest;
    }
}
