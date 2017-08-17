namespace MailgunWebhooks.Validators
{
    public interface IWebhookRequestValidator
    {
        bool HasValidSignature(object request);
    }
}