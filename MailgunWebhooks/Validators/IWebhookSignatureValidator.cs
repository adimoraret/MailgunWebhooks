using MailgunWebhooks.Models;

namespace MailgunWebhooks.Validators
{
    public interface IWebhookSignatureValidator
    {
        bool IsValid(WebhookRequest request);
    }
}