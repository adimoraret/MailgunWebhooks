using MailgunWebhooks.Models;
using MailgunWebhooks.Validators;

namespace MailgunWebhooks.Tests
{
    internal class WebhookInvalidRequestValidator : IWebhookRequestValidator
    {
        public bool HasValidSignature(WebhookRequest request)
        {
            return false;
        }
    }
}