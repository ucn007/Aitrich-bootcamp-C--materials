using AutoMapper;
using BlazorApp5.DTOs;
using BlazorApp5.Model;

namespace BlazorApp5.Helper;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<LoginDto, User>().ReverseMap();
        CreateMap<RegisterDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<LoginResponseDto, User>().ReverseMap();
        
    }
}