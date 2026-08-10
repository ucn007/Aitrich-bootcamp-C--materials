using AutoMapper;
using TravelsDb.DTO;
using TravelsDb.Models;

namespace TravelsDb.Helper
{
    public class UseMappingProfile : Profile
    {
        public UseMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
