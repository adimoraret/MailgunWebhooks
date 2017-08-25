using MailgunWebhooks.Models;
using MailgunWebhooks.Validators;

namespace MailgunWebhooks.Tests
{
    internal class WebhookInvalidSignatureValidator : IWebhookSignatureValidator
    {
        public bool IsValid(WebhookRequest request)
        {
            return false;
        }
    }
}