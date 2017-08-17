using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace MailgunWebhooks.Helper
{
    public interface IRequestParser
    {
        HttpStatusCode ProcessFormDataRequest<T>(IEnumerable<KeyValuePair<string, string>> formData, EventType eventType);

        HttpStatusCode ProcessMultipartRequest<T>(HttpRequestMessage request, EventType eventType);
    }
}
