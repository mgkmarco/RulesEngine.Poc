using AutoMapper;
using RuleEnginePOCPublicContracts.Configurations;
using RulesEnginePOCWebApi.DTOs;

namespace RulesEnginePOCWebApi.Profiles
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            CreateMap<EventsTableDto, IEventsTableConfiguration>()
                .ReverseMap();
        }
    }
}