using AutoMapper;
using TourManageDb.DTO;
using TourManageDb.Model;

namespace TourManageDb.Helper
{
    public class UseMappingProfile : Profile
    {
        public UseMappingProfile()
        {
            CreateMap<Tour, TourDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
        }
    }
}
