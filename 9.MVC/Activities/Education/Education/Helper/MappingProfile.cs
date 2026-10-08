using AutoMapper;
using Education.DTOs.User;
using Education.Models;

namespace Education.Helper;

public class MappingProfile: Profile
{
    public  MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<LoginUserDto, User>().ReverseMap();
        CreateMap<User,RegisterDto>().ReverseMap(); 
        CreateMap<UpdateUserDto, User>().ReverseMap();
    }
}