using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MailgunWebhooks.Validators;

namespace MailgunWebhooks.Helper
{
    internal class RequestParser : IRequestParser
    {
        public HttpStatusCode ProcessFormDataRequest<T>(IEnumerable<KeyValuePair<string, string>> formData, EventType eventType)
        {
            var data = ConvertToDictionary(formData);
            return ProcessRequest<T>(data);
        }

        public HttpStatusCode ProcessMultipartRequest<T>(HttpRequestMessage request, EventType eventType)
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
            var fullPath = HttpContext.Current.Server.MapPath("~/App_Data");
            var multipartProvider = new MultipartFormDataStreamProvider(fullPath);
            var content = await request.Content.ReadAsMultipartAsync(multipartProvider);
            return content.FormData;
        }

        private  HttpStatusCode ProcessRequest<T>(IDictionary<string, string> requestBody)
        {
            var request = AutoMapper.Mapper.Map<T>(requestBody);
            IWebhookRequestValidator validator = new WebhookRequestValidator();
            if (validator.HasValidSignature(request)) {
                return HttpStatusCode.NotAcceptable;
            }
            return HttpStatusCode.OK;
        }

    }
}