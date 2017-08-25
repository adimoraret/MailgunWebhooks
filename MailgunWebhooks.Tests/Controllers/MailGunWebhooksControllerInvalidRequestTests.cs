using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using AutoMapper;
using MailgunWebhooks.Controllers;
using MailgunWebhooks.Helper;
using MailgunWebhooks.Validators;
using NUnit.Framework;

namespace MailgunWebhooks.Tests.Controllers
{
    [TestFixture]
    public class MailGunWebhooksControllerInvalidRequestTests
    {
        private MailGunWebhooksController _sut;
        private IWebhookSignatureValidator _signatureValidator;
        private IRequestParser _requestParser;
        private HttpContent _multipartFormDataContent;
        private HttpContent _formUrlEncodedContent;

        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
        }

        [SetUp]
        public void SetUp()
        {
            _signatureValidator = new WebhookInvalidSignatureValidator();
            _requestParser = new RequestParser(_signatureValidator);
            _formUrlEncodedContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
            _multipartFormDataContent = new MultipartFormDataContent();

            _sut = new MailGunWebhooksController(_requestParser);
        }

        [Test]
        public void PostDeliver_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            SetupWebApiRequest(_formUrlEncodedContent);

            var actual = _sut.PostDeliver(null);
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostOpen_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            SetupWebApiRequest(_formUrlEncodedContent);

            var actual = _sut.PostOpen(null);
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostClick_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            SetupWebApiRequest(_formUrlEncodedContent);

            var actual = _sut.PostClick(null);
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostDrop_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            SetupWebApiRequest(_multipartFormDataContent);

            var actual = _sut.PostDrop();
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostBounce_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            SetupWebApiRequest(_multipartFormDataContent);

            var actual = _sut.PostBounce();
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostSpam_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            SetupWebApiRequest(_multipartFormDataContent);

            var actual = _sut.PostSpam();
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        [Test]
        public void PostUnsubscribe_Should_Return_NotAcceptable_For_InvalidRequests()
        {
            SetupWebApiRequest(_formUrlEncodedContent);

            var actual = _sut.PostUnsubscribe(null);
            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;

            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        private void SetupWebApiRequest(HttpContent content)
        {
            _sut.Request = new HttpRequestMessage { Content = content };
        }
    }
}
