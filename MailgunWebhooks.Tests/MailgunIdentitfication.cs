namespace MailgunWebhooks.Tests
{
    internal class MailgunIdentitfication
    {
        public string Timestamp { get; set; }
        public string Token { get; set; }
        public string Signature { get; set; }
    }
}