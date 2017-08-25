using System;
using System.Security.Cryptography;
using System.Text;
using MailgunWebhooks.Models;

namespace MailgunWebhooks.Validators
{
    public class WebhookSignatureValidator : IWebhookSignatureValidator
    {
        private readonly string _apiKey;

        public WebhookSignatureValidator(string apiKey)
        {
            _apiKey = apiKey;
        }
        public bool IsValid(WebhookRequest request)
        {
            var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(_apiKey));
            var signature = hmac.ComputeHash(Encoding.ASCII.GetBytes(request.Timestamp + request.Token));
            var generatedSignature = BitConverter.ToString(signature).Replace("-", "");
            return generatedSignature.Equals(request.Signature, StringComparison.OrdinalIgnoreCase);
        }
    }
}