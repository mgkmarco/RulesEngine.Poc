using AutoMapper;
using RuleEngine.Poc.Public.Contracts.Configurations;
using RulesEngine.Poc.WebApi.DTOs;

namespace RulesEngine.Poc.WebApi.Profiles
{
    public class WebApiProfile : Profile
    {
        public WebApiProfile()
        {
            CreateMap<EventsTableDto, IEventsTableConfiguration>()
                .ReverseMap();
            
            CreateMap<CarouselDto, ICarouselConfiguration>()
                .ReverseMap();
        }
    }
}