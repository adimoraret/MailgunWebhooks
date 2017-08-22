using System;
using System.Security.Cryptography;
using System.Text;
using MailgunWebhooks.Models;

namespace MailgunWebhooks.Validators
{
    public class WebhookRequestValidator : IWebhookRequestValidator
    {
        private readonly string _apiKey;

        public WebhookRequestValidator(string apiKey)
        {
            _apiKey = apiKey;
        }
        public bool HasValidSignature(WebhookRequest request)
        {
            var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(_apiKey));
            var signature = hmac.ComputeHash(Encoding.ASCII.GetBytes(request.Timestamp + request.Token));
            var generatedSignature = BitConverter.ToString(signature).Replace("-", "");
            return generatedSignature.Equals(request.Signature, StringComparison.OrdinalIgnoreCase);
        }
    }
}