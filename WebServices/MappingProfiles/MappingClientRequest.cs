using AutoMapper;
using Core.Dots;
using Core.Entities;

namespace WebServicesMappingProfiles
{
    public class MappingClientRequest:Profile
    {
        public MappingClientRequest()
        {
            CreateMap<ClientRequestView, ClientRequest>().ReverseMap();
       
        }
    }
}
