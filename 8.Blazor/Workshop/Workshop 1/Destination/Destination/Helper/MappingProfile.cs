using AutoMapper;
using Destination.Dto;
using Destination.Model;

namespace Destination.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        
            CreateMap<Destinationn, DestinationDto>().ReverseMap();
        }
    }
}
