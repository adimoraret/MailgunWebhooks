using System.Net;
using System.Net.Http;
using System.Threading;
using AutoMapper;
using MailgunWebhooks.Controllers;
using MailgunWebhooks.Helper;
using MailgunWebhooks.Validators;
using NUnit.Framework;

namespace MailgunWebhooks.Tests
{
    [TestFixture]
    public class MailGunWebhooksControllerInvalidRequestTests
    {
        private MailGunWebhooksController _sut;
        private IWebhookRequestValidator _requestValidator;
        private IRequestParser _requestParser;

        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
        }

        [SetUp]
        public void SetUp()
        {
            _requestValidator = new WebhookInvalidRequestValidator();
            _requestParser = new RequestParser(_requestValidator);
            _sut = new MailGunWebhooksController(_requestParser);
        }

        [Test]
        public void PostDeliver_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            _sut.Request = new HttpRequestMessage();

            var actual = _sut.PostDeliver(null);
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostOpen_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            _sut.Request = new HttpRequestMessage();

            var actual = _sut.PostOpen(null);
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostClick_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            _sut.Request = new HttpRequestMessage();

            var actual = _sut.PostClick(null);
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostDrop_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            _sut.Request = new HttpRequestMessage { Content = new MultipartContent() };

            var actual = _sut.PostDrop();
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostBounce_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            _sut.Request = new HttpRequestMessage { Content = new MultipartContent() };

            var actual = _sut.PostBounce();
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostSpam_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            _sut.Request = new HttpRequestMessage {Content = new MultipartContent()};

            var actual = _sut.PostSpam();
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostUnsubscribe_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            _sut.Request = new HttpRequestMessage();

            var actual = _sut.PostUnsubscribe(null);
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }
    }
}
