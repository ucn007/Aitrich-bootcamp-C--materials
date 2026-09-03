using AutoMapper;
using Destination.Dto;
using Destination.Model;

namespace Destination.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Register, RegisterDto>().ReverseMap();
            CreateMap<Tour, TourDto>().ReverseMap();

        }
    }
}
