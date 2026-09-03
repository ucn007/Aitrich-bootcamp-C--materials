using AutoMapper;
using TourManagement.Dto;
using TourManagement.Model;

namespace TourManagement.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Destination, DestinationDto>().ReverseMap();
            CreateMap<Tour,TourDto>().ReverseMap();
        }
    }
}
