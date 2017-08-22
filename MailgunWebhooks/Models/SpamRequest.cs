namespace MailgunWebhooks.Models
{
    public class SpamRequest : WebhookRequest
    {
        public string CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Tag { get; set; }
        public string MailingList { get; set; }
    }
}