namespace MailgunWebhooks.Models
{
    public class WebhookRequest
    {
        public string MessageId { get; set; }
        public string MessageHeaders { get; set; }
        public string Event { get; set; }
        public string Recipient { get; set; }
        public string Domain { get; set; }
        public string Timestamp { get; set; }
        public string Token { get; set; }
        public string Signature { get; set; }
        public string BodyPlain { get; set; }
    }
}