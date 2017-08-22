namespace MailgunWebhooks.Models
{
    public class BounceRequest : WebhookRequest
    {
        public string Code { get; set; }
        public string Error { get; set; }
        public string Notification { get; set; }
        public string CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string MailingList { get; set; }
    }
}