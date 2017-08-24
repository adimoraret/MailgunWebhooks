using System.Collections.Generic;
using AutoMapper;
using MailgunWebhooks.Models;

namespace MailgunWebhooks
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapMailgunWebhooks();
        }

        private void MapMailgunWebhooks()
        {
            MapWebhookRequest();
            MapDeliverRequest();
            MapOpenRequest();
            MapClickRequest();
            MapDropRequest();
            MapBounceRequest();
            MapSpamRequest();
            MapUnsubscribeRequest();
        }

        private void MapWebhookRequest()
        {
            CreateMap<IDictionary<string, string>, WebhookRequest>()
                .ForMember(dest => dest.MessageId, opt=>opt.MapFrom(src => GetPropertyValueOrEmpty(src, "message-id")))
                .ForMember(dest => dest.MessageHeaders, opt=>opt.MapFrom(src => GetPropertyValueOrEmpty(src, "message-headers")))
                .ForMember(dest => dest.Event, opt=>opt.MapFrom(src => GetPropertyValueOrEmpty(src, "event")))
                .ForMember(dest => dest.Recipient, opt=>opt.MapFrom(src => GetPropertyValueOrEmpty(src, "recipient")))
                .ForMember(dest => dest.Domain, opt=>opt.MapFrom(src => GetPropertyValueOrEmpty(src, "domain")))
                .ForMember(dest => dest.Timestamp, opt=>opt.MapFrom(src => GetPropertyValueOrEmpty(src, "timestamp")))
                .ForMember(dest => dest.Token, opt=>opt.MapFrom(src => GetPropertyValueOrEmpty(src, "token")))
                .ForMember(dest => dest.Signature, opt=>opt.MapFrom(src => GetPropertyValueOrEmpty(src, "signature")))
                .ForMember(dest => dest.BodyPlain, opt=>opt.MapFrom(src=>GetPropertyValueOrEmpty(src, "body-plain")));
        }

        private void MapDeliverRequest()
        {
            CreateMap<IDictionary<string, string>, DeliverRequest>()
                .IncludeBase<IDictionary<string, string>, WebhookRequest>();
        }

        private void MapOpenRequest()
        {
            CreateMap<IDictionary<string, string>, OpenRequest>()
                .IncludeBase<IDictionary<string, string>, WebhookRequest>()
                .ForMember(dest => dest.Ip, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "ip")))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "country")))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "region")))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "city")))
                .ForMember(dest => dest.UserAgent, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "user-agent")))
                .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "device-type")))
                .ForMember(dest => dest.ClientType, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-type")))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-name")))
                .ForMember(dest => dest.ClientOs, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-os")))
                .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-id")))
                .ForMember(dest => dest.CampaignName, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-name")))
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "tag")))
                .ForMember(dest => dest.MailingList, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "mailing-list")));
        }

        private void MapClickRequest()
        {
            CreateMap<IDictionary<string, string>, ClickRequest>()
                .IncludeBase<IDictionary<string, string>, WebhookRequest>()
                .ForMember(dest => dest.Ip, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "ip")))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "country")))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "region")))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "city")))
                .ForMember(dest => dest.UserAgent, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "user-agent")))
                .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "device-type")))
                .ForMember(dest => dest.ClientType, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-type")))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-name")))
                .ForMember(dest => dest.ClientOs, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-os")))
                .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-id")))
                .ForMember(dest => dest.CampaignName, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-name")))
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "tag")))
                .ForMember(dest => dest.MailingList, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "mailing-list")))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "url")));
        }

        private void MapDropRequest()
        {
            CreateMap<IDictionary<string, string>, DropRequest>()
                .IncludeBase<IDictionary<string, string>, WebhookRequest>()
                .ForMember(dest => dest.Reason, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "reason")))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "code")))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "description")));
        }

        private void MapBounceRequest()
        {
            CreateMap<IDictionary<string, string>, BounceRequest>()
                .IncludeBase<IDictionary<string, string>, WebhookRequest>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "code")))
                .ForMember(dest => dest.Error, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "error")))
                .ForMember(dest => dest.Notification, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "notification")))
                .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-id")))
                .ForMember(dest => dest.CampaignName, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-name")))
                .ForMember(dest => dest.MailingList, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "mailing-list")));
        }

        private void MapSpamRequest()
        {
            CreateMap<IDictionary<string, string>, SpamRequest>()
                .IncludeBase<IDictionary<string, string>, WebhookRequest>()
                .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-id")))
                .ForMember(dest => dest.CampaignName, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-name")))
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "tag")))
                .ForMember(dest => dest.MailingList, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "mailing-list")));
        }

        private void MapUnsubscribeRequest()
        {
            CreateMap<IDictionary<string, string>, UnsubscribeRequest>()
                .IncludeBase<IDictionary<string, string>, WebhookRequest>()
                .ForMember(dest => dest.Ip, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "ip")))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "country")))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "region")))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "city")))
                .ForMember(dest => dest.UserAgent, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "user-agent")))
                .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "device-type")))
                .ForMember(dest => dest.ClientType, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-type")))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-name")))
                .ForMember(dest => dest.ClientOs, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "client-os")))
                .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-id")))
                .ForMember(dest => dest.CampaignName, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "campaign-name")))
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "tag")))
                .ForMember(dest => dest.MailingList, opt => opt.MapFrom(src => GetPropertyValueOrEmpty(src, "mailing-list")));
        }

        private static string GetPropertyValueOrEmpty(IDictionary<string, string> source, string key)
        {
            return source.ContainsKey(key) ? source[key] : "";
        }
    }
}