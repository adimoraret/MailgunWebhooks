using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MailgunWebhooks.Models;
using MailgunWebhooks.Validators;

namespace MailgunWebhooks.Helper
{
    internal class RequestParser : IRequestParser
    {
        private readonly IWebhookSignatureValidator _webhookSignatureValidator;

        public RequestParser(IWebhookSignatureValidator webhookSignatureValidator)
        {
            _webhookSignatureValidator = webhookSignatureValidator;
        }

        public HttpStatusCode ProcessFormDataRequest<T>(IEnumerable<KeyValuePair<string, string>> formData) where T : WebhookRequest
        {
            var data = ConvertToDictionary(formData);
            return ProcessRequest<T>(data);
        }

        public HttpStatusCode ProcessMultipartRequest<T>(HttpRequestMessage request) where T : WebhookRequest
        {
            var formData = ExtractFormData(request);
            var data =  ConvertToDictionary(formData.Result);
            return ProcessRequest<T>(data);
        }

        private IDictionary<string, string> ConvertToDictionary(IEnumerable<KeyValuePair<string, string>> formData)
        {
            return formData?.ToDictionary(item => item.Key, item => item.Value);
        }

        private IDictionary<string,string> ConvertToDictionary(NameValueCollection formData)
        {
            return formData.AllKeys.ToDictionary(key => key, key => formData[key],
                StringComparer.InvariantCultureIgnoreCase);
        }

        private async Task<NameValueCollection> ExtractFormData(HttpRequestMessage request)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            var multipartProvider = new MultipartFormDataStreamProvider(fullPath);
            var content = await request.Content.ReadAsMultipartAsync(multipartProvider);
            return content.FormData;
        }

        private  HttpStatusCode ProcessRequest<T>(IDictionary<string, string> requestBody) where T : WebhookRequest
        {
            var request = AutoMapper.Mapper.Map<T>(requestBody);
            if (!_webhookSignatureValidator.IsValid(request)) {
                return HttpStatusCode.NotAcceptable;
            }
            return HttpStatusCode.OK;
        }

    }
}