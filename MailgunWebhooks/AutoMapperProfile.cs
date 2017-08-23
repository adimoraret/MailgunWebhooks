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
            MapMailgunWebhookRequest();
        }

        private void MapMailgunWebhookRequest()
        {
        }
    }
}