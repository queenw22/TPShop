using API.Dto;
using AutoMapper;
using Core.Entity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Service, ServiceToReturnDto>()
               .ForMember(d => d.ServiceType, o => o.MapFrom(s => s.ServiceType.Name))
               .ForMember(d => d.CommType,  o => o.MapFrom(s => s.CommType.Name))
               .ForMember(d => d.DesignOptions, o => o.MapFrom(s => s.DesignOptions.Name));

        }
    }
}