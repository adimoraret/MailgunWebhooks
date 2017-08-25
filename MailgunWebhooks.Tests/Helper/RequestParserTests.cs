using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AutoMapper;
using MailgunWebhooks.Helper;
using MailgunWebhooks.Models;
using MailgunWebhooks.Validators;
using NUnit.Framework;

namespace MailgunWebhooks.Tests.Helper
{
    [TestFixture]
    public class RequestParserTests
    {
        private IRequestParser _sut;
        private readonly IWebhookSignatureValidator _invalidSignatureValidator = new WebhookInvalidSignatureValidator();
        private IWebhookSignatureValidator _validSignatureValidator = new WebhookInvalidSignatureValidator();

        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
        }

        [Test]
        public void ProcessFormDataRequest_Should_Return_NotAcceptable_For_Invalid_Signature()
        {
            _sut = new RequestParser(_invalidSignatureValidator);

            VerifyProcessFormDataRequestReturnsNotAcceptable<BounceRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<ClickRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<DeliverRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<DropRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<OpenRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<SpamRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<UnsubscribeRequest>();
        }

        [Test]
        public void ProcessMultipartRequest_Should_Return_NotAcceptable_For_Invalid_Signature()
        {
            _sut = new RequestParser(_invalidSignatureValidator);

            VerifyProcessMultipartRequestReturnsNotAcceptable<BounceRequest>();
            VerifyProcessMultipartRequestReturnsNotAcceptable<ClickRequest>();
            VerifyProcessMultipartRequestReturnsNotAcceptable<DeliverRequest>();
            VerifyProcessMultipartRequestReturnsNotAcceptable<DropRequest>();
            VerifyProcessMultipartRequestReturnsNotAcceptable<OpenRequest>();
            VerifyProcessMultipartRequestReturnsNotAcceptable<SpamRequest>();
            VerifyProcessMultipartRequestReturnsNotAcceptable<UnsubscribeRequest>();
        }

        [Test]
        public void ProcessFormDataRequest_Should_Return_Ok_For_Valid_Signature()
        {
            _sut = new RequestParser(_invalidSignatureValidator);

            VerifyProcessFormDataRequestReturnsNotAcceptable<BounceRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<ClickRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<DeliverRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<DropRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<OpenRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<SpamRequest>();
            VerifyProcessFormDataRequestReturnsNotAcceptable<UnsubscribeRequest>();
        }

        private void VerifyProcessFormDataRequestReturnsNotAcceptable<T>() where T : WebhookRequest
        {
            var actual = _sut.ProcessFormDataRequest<T>(new List<KeyValuePair<string, string>>());
            Assert.That(actual, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }

        private void VerifyProcessMultipartRequestReturnsNotAcceptable<T>() where T : WebhookRequest
        {
            var request = new HttpRequestMessage { Content = new MultipartFormDataContent() };
            var actual = _sut.ProcessMultipartRequest<T>(request);
            Assert.That(actual, Is.EqualTo(HttpStatusCode.NotAcceptable));
        }
    }
}
