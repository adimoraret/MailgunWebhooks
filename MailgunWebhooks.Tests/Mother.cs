using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace MailgunWebhooks.Tests
{
    public static class Mother
    {
        public const string SampleMailgunApiKey = "key-test";

        public static IDictionary<string, string> CreateValidDeliverRequest()
        {
            var identification = GenerateMailgunIdentification("1234", SampleMailgunApiKey);
            var dict = new Dictionary<string, string>
            {
                {"message-id", "123"},
                {"message-headers", "some headers"},
                {"event", "deliver"},
                {"recipient", "a@b.c"},
                {"domain", "codetrest.com"},
                {"timestamp", identification.Timestamp},
                {"token", identification.Token},
                {"signature", identification.Signature},
                {"body-plain", "abcdefg"}
            };
            return dict;
        }

        public static List<KeyValuePair<string, string>> ValidDeliverRequest =>
                    CreateValidDeliverRequest()
                    .Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value))
                    .ToList();

        public static IDictionary<string, string> CreateValidUnsubscribeRequest()
        {
            var identification = GenerateMailgunIdentification("1234", SampleMailgunApiKey);
            var dict = new Dictionary<string, string>
            {
                {"message-id", "123"},
                {"message-headers", "some headers"},
                {"event", "deliver"},
                {"recipient", "a@b.c"},
                {"domain", "codetrest.com"},
                {"ip", "127.0.0.1"},
                {"country", "USA"},
                {"region", "California"},
                {"city", "Los Angeles"},
                {"user-agent","some user agent"},
                {"device-type","some device type"},
                {"client-type", "some client type"},
                {"client-name", "some client name"},
                {"client-os", "Windows"},
                {"campaign-id","123"},
                {"campaign-name", "the one"},
                {"tag", "my tag"},
                {"mailing-list","some mailing list"},
                {"timestamp", identification.Timestamp},
                {"token", identification.Token},
                {"signature", identification.Signature},
                {"body-plain", "abcdefg"}
            };
            return dict;
        }

        public static List<KeyValuePair<string, string>> ValidUnsubscribeRequest =>
            CreateValidUnsubscribeRequest()
            .Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value))
            .ToList();


        public static List<KeyValuePair<string, string>> CreateValidClickRequest()
        {
            var identification = GenerateMailgunIdentification("901234", SampleMailgunApiKey);
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message-id", "123"),
                new KeyValuePair<string, string>("message-headers", "some headers"),
                new KeyValuePair<string, string>("event", "deliver"),
                new KeyValuePair<string, string>("recipient", "a@b.c"),
                new KeyValuePair<string, string>("domain", "codetrest.com"),
                new KeyValuePair<string, string>("ip", "127.0.0.1"),
                new KeyValuePair<string, string>("country", "USA"),
                new KeyValuePair<string, string>("region", "California"),
                new KeyValuePair<string, string>("city", "Los Angeles"),
                new KeyValuePair<string, string>("user-agent","some user agent"),
                new KeyValuePair<string, string>("device-type","some device type"),
                new KeyValuePair<string, string>("client-type", "some client type"),
                new KeyValuePair<string, string>("client-name", "some client name"),
                new KeyValuePair<string, string>("client-os", "Windows"),
                new KeyValuePair<string, string>("campaign-id","123"),
                new KeyValuePair<string, string>("campaign-name", "the one"),
                new KeyValuePair<string, string>("tag", "my tag"),
                new KeyValuePair<string, string>("mailing-list","some mailing list"),
                new KeyValuePair<string, string>("url","http://localhost"),
                new KeyValuePair<string, string>("timestamp", identification.Timestamp),
                new KeyValuePair<string, string>("token", identification.Token),
                new KeyValuePair<string, string>("signature", identification.Signature),
                new KeyValuePair<string, string>("body-plain", "abcdefg")
            };
        }

        public static List<KeyValuePair<string, string>> CreateValidOpenRequest()
        {
            var identification = GenerateMailgunIdentification("901234", SampleMailgunApiKey);
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message-id", "123"),
                new KeyValuePair<string, string>("message-headers", "some headers"),
                new KeyValuePair<string, string>("event", "deliver"),
                new KeyValuePair<string, string>("recipient", "a@b.c"),
                new KeyValuePair<string, string>("domain", "codetrest.com"),
                new KeyValuePair<string, string>("ip", "127.0.0.1"),
                new KeyValuePair<string, string>("country", "USA"),
                new KeyValuePair<string, string>("region", "California"),
                new KeyValuePair<string, string>("city", "Los Angeles"),
                new KeyValuePair<string, string>("user-agent","some user agent"),
                new KeyValuePair<string, string>("device-type","some device type"),
                new KeyValuePair<string, string>("client-type", "some client type"),
                new KeyValuePair<string, string>("client-name", "some client name"),
                new KeyValuePair<string, string>("client-os", "Windows"),
                new KeyValuePair<string, string>("campaign-id","123"),
                new KeyValuePair<string, string>("campaign-name", "the one"),
                new KeyValuePair<string, string>("tag", "my tag"),
                new KeyValuePair<string, string>("mailing-list","some mailing list"),
                new KeyValuePair<string, string>("timestamp", identification.Timestamp),
                new KeyValuePair<string, string>("token", identification.Token),
                new KeyValuePair<string, string>("signature", identification.Signature),
                new KeyValuePair<string, string>("body-plain", "abcdefg")
            };
        }

        public static List<KeyValuePair<string, string>> CreateInvalidWebhookRequest()
        {
            var identification = GenerateMailgunIdentification("1234", SampleMailgunApiKey);
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message-id", "123"),
                new KeyValuePair<string, string>("message-headers", "some headers"),
                new KeyValuePair<string, string>("event", "deliver"),
                new KeyValuePair<string, string>("recipient", "a@b.c"),
                new KeyValuePair<string, string>("domain", "codetrest.com"),
                new KeyValuePair<string, string>("timestamp", identification.Timestamp),
                new KeyValuePair<string, string>("token", "some other token"),
                new KeyValuePair<string, string>("signature", identification.Signature),
                new KeyValuePair<string, string>("body-plain", "abcdefg")
            };
        }

        public static HttpContent CreateValidDropHttpContent()
        {
            var identification = GenerateMailgunIdentification("901234", SampleMailgunApiKey);
            var properties = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message-id", "123"),
                new KeyValuePair<string, string>("message-headers", "some headers"),
                new KeyValuePair<string, string>("event", "deliver"),
                new KeyValuePair<string, string>("recipient", "a@b.c"),
                new KeyValuePair<string, string>("domain", "codetrest.com"),
                new KeyValuePair<string, string>("reason","some reason"),
                new KeyValuePair<string, string>("code","some code"),
                new KeyValuePair<string, string>("description","some description"),
                new KeyValuePair<string, string>("timestamp", identification.Timestamp),
                new KeyValuePair<string, string>("token", identification.Token),
                new KeyValuePair<string, string>("signature", identification.Signature),
                new KeyValuePair<string, string>("body-plain", "abcdefg")
            };
            var multipartContent = CreateMultipartFormDataContent(properties);
            return multipartContent;
        }

        public static HttpContent CreateValidBounceHttpContent()
        {
            var identification = GenerateMailgunIdentification("901234", SampleMailgunApiKey);
            var properties = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message-id", "123"),
                new KeyValuePair<string, string>("message-headers", "some headers"),
                new KeyValuePair<string, string>("event", "deliver"),
                new KeyValuePair<string, string>("recipient", "a@b.c"),
                new KeyValuePair<string, string>("domain", "codetrest.com"),
                new KeyValuePair<string, string>("code","some code"),
                new KeyValuePair<string, string>("error","some error"),
                new KeyValuePair<string, string>("notification","some notification"),
                new KeyValuePair<string, string>("campaign-id","123"),
                new KeyValuePair<string, string>("campaign-name", "the one"),
                new KeyValuePair<string, string>("mailing-list", "some mailing list"),
                new KeyValuePair<string, string>("timestamp", identification.Timestamp),
                new KeyValuePair<string, string>("token", identification.Token),
                new KeyValuePair<string, string>("signature", identification.Signature),
                new KeyValuePair<string, string>("body-plain", "abcdefg")
            };
            var multipartContent = CreateMultipartFormDataContent(properties);
            return multipartContent;
        }

        public static HttpContent CreateValidSpamHttpContent()
        {
            var identification = GenerateMailgunIdentification("901234", SampleMailgunApiKey);
            var properties = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message-id", "123"),
                new KeyValuePair<string, string>("message-headers", "some headers"),
                new KeyValuePair<string, string>("event", "deliver"),
                new KeyValuePair<string, string>("recipient", "a@b.c"),
                new KeyValuePair<string, string>("domain", "codetrest.com"),
                new KeyValuePair<string, string>("tag","some tag"),
                new KeyValuePair<string, string>("campaign-id","123"),
                new KeyValuePair<string, string>("campaign-name", "the one"),
                new KeyValuePair<string, string>("mailing-list", "some mailing list"),
                new KeyValuePair<string, string>("timestamp", identification.Timestamp),
                new KeyValuePair<string, string>("token", identification.Token),
                new KeyValuePair<string, string>("signature", identification.Signature),
                new KeyValuePair<string, string>("body-plain", "abcdefg")
            };
            var multipartContent = CreateMultipartFormDataContent(properties);
            return multipartContent;
        }

        public static HttpContent CreateInvalidWebhookHttpContent()
        {
            var identification = GenerateMailgunIdentification("901234", SampleMailgunApiKey);
            var properties = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("message-id", "123"),
                new KeyValuePair<string, string>("message-headers", "some headers"),
                new KeyValuePair<string, string>("event", "deliver"),
                new KeyValuePair<string, string>("recipient", "a@b.c"),
                new KeyValuePair<string, string>("domain", "codetrest.com"),
                new KeyValuePair<string, string>("timestamp", identification.Timestamp),
                new KeyValuePair<string, string>("token", "other token"),
                new KeyValuePair<string, string>("signature", identification.Signature),
                new KeyValuePair<string, string>("body-plain", "abcdefg")
            };
            var multipartContent = CreateMultipartFormDataContent(properties);
            return multipartContent;
        }

        private static MailgunIdentitfication GenerateMailgunIdentification(string token, string mailgunKey)
        {
            var timestamp = GetCurrentTimestamp();
            var signature = GenerateMailgunSignature(timestamp, token, mailgunKey);
            return new MailgunIdentitfication
            {
                Timestamp = timestamp,
                Token = token,
                Signature = signature
            };
        }

        private static string GenerateMailgunSignature(string timestamp, string token, string mailgunKey)
        {
            var hmac = new HMACSHA256(Encoding.ASCII.GetBytes(mailgunKey));
            var signature = hmac.ComputeHash(Encoding.ASCII.GetBytes(timestamp + token));
            var generatedSignature = BitConverter.ToString(signature).Replace("-", "");
            return generatedSignature;
        }

        private static string GetCurrentTimestamp()
        {
            var currentDateTime = DateTime.UtcNow;
            var epochReferenceTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (currentDateTime - epochReferenceTime).TotalSeconds.ToString();
        }

        private static HttpContent CreateMultipartFormDataContent(IEnumerable<KeyValuePair<string, string>> properties)
        {
            var multipartContent = new MultipartFormDataContent();
            foreach (var prop in properties)
            {
                multipartContent.Add(new StringContent(prop.Value), prop.Key);
            }
            return multipartContent;
        }
    }
}