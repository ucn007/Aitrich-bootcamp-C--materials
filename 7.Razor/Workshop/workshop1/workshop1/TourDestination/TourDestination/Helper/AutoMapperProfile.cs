using AutoMapper;
using TourDestination.DestinationDto;
using TourDestination.Dtos;
using TourDestination.Model;

namespace TourDestination.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DestinationcreationDto, Destination>();
            CreateMap<DestinationUpdateDto, Destination>();
            CreateMap<Destination, DestinationcreationDto>();
            CreateMap<Destination, DestinationUpdateDto>();
        }
    }
}
