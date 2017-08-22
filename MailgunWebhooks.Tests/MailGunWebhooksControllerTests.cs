using System.Net;
using MailgunWebhooks.Controllers;
using MailgunWebhooks.Helper;
using MailgunWebhooks.Validators;
using NUnit.Framework;

namespace MailgunWebhooks.Tests
{
    [TestFixture]
    public class MailGunWebhooksControllerTests
    {
        private MailGunWebhooksController _sut;

        [SetUp]
        public void SetUp()
        {
            var requestValidator = new WebhookRequestValidator("sample");
            _sut = new MailGunWebhooksController(new RequestParser(requestValidator));
        }

        [Test]
        public void PostDeliver_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            var actual = _sut.PostDeliver(null);

            Assert.That(actual, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }
    }
}
