namespace MailgunWebhooks.Models
{
    public class DropRequest : WebhookRequest
    {
        public string Reason { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}