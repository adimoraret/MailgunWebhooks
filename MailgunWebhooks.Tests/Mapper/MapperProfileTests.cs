using System.Collections.Generic;
using MailgunWebhooks.Mapper;
using MailgunWebhooks.Models;
using NUnit.Framework;

namespace MailgunWebhooks.Tests.Mapper
{
    [TestFixture]
    public class MapperProfileTests
    {

        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            AutoMapper.Mapper.Initialize(cfg => { cfg.AddProfile<MapperProfile>(); });
        }

        [Test]
        public void ShouldMapToDeliverRequest()
        {
            var deliverRequest = Mother.CreateValidDeliverRequest();

            var deliverRequestModel = AutoMapper.Mapper.Map<DeliverRequest>(deliverRequest);

            VerifyDeliverRequestMapping(deliverRequestModel, deliverRequest);
        }

        [Test]
        public void ShouldMapToUnsubscribeRequest()
        {
            var usubscribeRequest = Mother.CreateValidUnsubscribeRequest();

            var unsubscribeRequestModel = AutoMapper.Mapper.Map<UnsubscribeRequest>(usubscribeRequest);

            VerifyUnsubscribeRequestMapping(unsubscribeRequestModel, usubscribeRequest);
        }


        private static void VerifyDeliverRequestMapping(DeliverRequest deliverRequestModel, IDictionary<string, string> deliverRequest)
        {
            Assert.That(deliverRequestModel.MessageId, Is.EqualTo(deliverRequest["message-id"]));
            Assert.That(deliverRequestModel.MessageHeaders, Is.EqualTo(deliverRequest["message-headers"]));
            Assert.That(deliverRequestModel.Recipient, Is.EqualTo(deliverRequest["recipient"]));
            Assert.That(deliverRequestModel.Domain, Is.EqualTo(deliverRequest["domain"]));
            Assert.That(deliverRequestModel.Timestamp, Is.EqualTo(deliverRequest["timestamp"]));
            Assert.That(deliverRequestModel.Token, Is.EqualTo(deliverRequest["token"]));
            Assert.That(deliverRequestModel.Signature, Is.EqualTo(deliverRequest["signature"]));
            Assert.That(deliverRequestModel.BodyPlain, Is.EqualTo(deliverRequest["body-plain"]));
        }

        private static void VerifyUnsubscribeRequestMapping(UnsubscribeRequest unsubscribeRequestModel,
            IDictionary<string, string> usubscribeRequest)
        {
            Assert.That(unsubscribeRequestModel.MessageId, Is.EqualTo(usubscribeRequest["message-id"]));
            Assert.That(unsubscribeRequestModel.MessageHeaders, Is.EqualTo(usubscribeRequest["message-headers"]));
            Assert.That(unsubscribeRequestModel.Recipient, Is.EqualTo(usubscribeRequest["recipient"]));
            Assert.That(unsubscribeRequestModel.Domain, Is.EqualTo(usubscribeRequest["domain"]));
            Assert.That(unsubscribeRequestModel.Ip, Is.EqualTo(usubscribeRequest["ip"]));
            Assert.That(unsubscribeRequestModel.Country, Is.EqualTo(usubscribeRequest["country"]));
            Assert.That(unsubscribeRequestModel.Region, Is.EqualTo(usubscribeRequest["region"]));
            Assert.That(unsubscribeRequestModel.City, Is.EqualTo(usubscribeRequest["city"]));
            Assert.That(unsubscribeRequestModel.UserAgent, Is.EqualTo(usubscribeRequest["user-agent"]));
            Assert.That(unsubscribeRequestModel.DeviceType, Is.EqualTo(usubscribeRequest["device-type"]));
            Assert.That(unsubscribeRequestModel.ClientType, Is.EqualTo(usubscribeRequest["client-type"]));
            Assert.That(unsubscribeRequestModel.ClientName, Is.EqualTo(usubscribeRequest["client-name"]));
            Assert.That(unsubscribeRequestModel.ClientOs, Is.EqualTo(usubscribeRequest["client-os"]));
            Assert.That(unsubscribeRequestModel.CampaignId, Is.EqualTo(usubscribeRequest["campaign-id"]));
            Assert.That(unsubscribeRequestModel.CampaignName, Is.EqualTo(usubscribeRequest["campaign-name"]));
            Assert.That(unsubscribeRequestModel.Tag, Is.EqualTo(usubscribeRequest["tag"]));
            Assert.That(unsubscribeRequestModel.MailingList, Is.EqualTo(usubscribeRequest["mailing-list"]));
            Assert.That(unsubscribeRequestModel.Timestamp, Is.EqualTo(usubscribeRequest["timestamp"]));
            Assert.That(unsubscribeRequestModel.Token, Is.EqualTo(usubscribeRequest["token"]));
            Assert.That(unsubscribeRequestModel.Signature, Is.EqualTo(usubscribeRequest["signature"]));
            Assert.That(unsubscribeRequestModel.BodyPlain, Is.EqualTo(usubscribeRequest["body-plain"]));
        }
    }
}
