namespace MailgunWebhooks.Models
{
    public class OpenRequest : WebhookRequest
    {
        public string Ip { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string UserAgent { get; set; }
        public string DeviceType { get; set; }
        public string ClientType { get; set; }
        public string ClientName { get; set; }
        public string ClientOs { get; set; }
        public string CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Tag { get; set; }
        public string MailingList { get; set; }
    }
}