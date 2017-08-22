using MailgunWebhooks.Models;

namespace MailgunWebhooks.Validators
{
    public interface IWebhookRequestValidator
    {
        bool HasValidSignature(WebhookRequest request);
    }
}