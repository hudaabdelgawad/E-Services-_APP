using AutoMapper;
using Core.Dots;
using Core.Entities;

namespace Ecom.API.MappingProfiles
{
    public class MappingServiceDetails : Profile
    {
        public MappingServiceDetails()
        {
            CreateMap<ServiceDetails, ServiceDetailsDto>()
                .ForMember(d => d.ServiceName, o => o.MapFrom(s => s.Service.ServiceName))
                .ReverseMap();
        
        }
    }
}
