using MailgunWebhooks.Models;
using MailgunWebhooks.Validators;

namespace MailgunWebhooks.Tests
{
    internal class WebhookValidSignatureValidator : IWebhookSignatureValidator
    {
        public bool IsValid(WebhookRequest request)
        {
            return true;
        }
    }
}