using AutoMapper;
using School_app.DTOs;
using School_app.DTOs.User;
using School_app.Models;

namespace School_app.Helper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<User , LoginDto>().ReverseMap();
        CreateMap<User , UserResponseDto>().ReverseMap();
        CreateMap<User , RegisterDto>().ReverseMap();
        CreateMap<User , LoginResponseDto>().ReverseMap();
    }
}