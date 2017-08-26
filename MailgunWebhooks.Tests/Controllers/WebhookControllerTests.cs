using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Web.Http;
using AutoMapper;
using MailgunWebhooks.Controllers;
using MailgunWebhooks.Helper;
using MailgunWebhooks.Validators;
using NUnit.Framework;

namespace MailgunWebhooks.Tests.Controllers
{
    [TestFixture]
    public class WebhookControllerTests
    {
        private MailGunWebhooksController _sut;

        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
        }

        [SetUp]
        public void SetUp()
        {
            var signatureValidator = new WebhookSignatureValidator(Mother.SampleMailgunApiKey);
            var requestParser = new RequestParser(signatureValidator);
            _sut = new MailGunWebhooksController(requestParser);
        }

        [Test]
        public void PostDeliver_Should_Be_Successfull_For_Valid_Requests()
        {
            var request = Mother.CreateValidDeliverRequest();
            SetupWebApiRequest(new FormUrlEncodedContent(request));

            var actual = _sut.PostDeliver(new FormDataCollection(request));

            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void PostUnsubscribe_Should_Be_Successfull_For_Valid_Requests()
        {
            var request = Mother.CreateValidUnsubscribeRequest();
            SetupWebApiRequest(new FormUrlEncodedContent(request));

            var actual = _sut.PostUnsubscribe(new FormDataCollection(request));

            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void PostClick_Should_Be_Successfull_For_Valid_Requests()
        {
            var request = Mother.CreateValidClickRequest();
            SetupWebApiRequest(new FormUrlEncodedContent(request));

            var actual = _sut.PostClick(new FormDataCollection(request));

            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void PostOpen_Should_Be_Successfull_For_Valid_Requests()
        {
            var request = Mother.CreateValidOpenRequest();
            SetupWebApiRequest(new FormUrlEncodedContent(request));

            var actual = _sut.PostOpen(new FormDataCollection(request));

            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        
        [Test]
        public void PostDrop_Should_Be_Successfull_For_Valid_Requests()
        {
            var content = Mother.CreateValidDropHttpContent();
            SetupWebApiRequest(content);

            var actual = _sut.PostDrop();

            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void PostBounce_Should_Be_Successfull_For_Valid_Requests()
        {
            var content = Mother.CreateValidBounceHttpContent();
            SetupWebApiRequest(content);

            var actual = _sut.PostBounce();

            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void PostSpam_Should_Be_Successfull_For_Valid_Requests()
        {
            var content = Mother.CreateValidSpamHttpContent();
            SetupWebApiRequest(content);

            var actual = _sut.PostSpam();

            var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
            Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void AllEndpoints_Should_Return_NotAcceptable_For_InvalidSignature_FormDataRequest()
        {
            var request = Mother.CreateInvalidWebhookRequest();
            SetupWebApiRequest(new FormUrlEncodedContent(request));
            var actions = new Func<IHttpActionResult>[] {
                () => _sut.PostDeliver(new FormDataCollection(request)),
                () => _sut.PostOpen(new FormDataCollection(request)),
                () => _sut.PostUnsubscribe(new FormDataCollection(request)),
                () => _sut.PostClick(new FormDataCollection(request)),
            };
            foreach (var action in actions)
            {
                var actual = action();
                var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
                Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
            }
        }

        [Test]
        public void AllEndpoints_Should_Return_NotAcceptable_For_InvalidSignature_MultipartRequest()
        {
            var actions = new Func<IHttpActionResult>[] {
                () => _sut.PostDrop(),
                () => _sut.PostBounce(),
                () => _sut.PostSpam()
            };
            foreach (var action in actions)
            {
                var content = Mother.CreateInvalidWebhookHttpContent();
                SetupWebApiRequest(content);
                var actual = action();
                var acctualHttpResponse = actual.ExecuteAsync(CancellationToken.None).Result;
                Assert.That(acctualHttpResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
            }
        }

        private void SetupWebApiRequest(HttpContent content)
        {
            _sut.Request = new HttpRequestMessage { Content = content };
        }
    }
}
