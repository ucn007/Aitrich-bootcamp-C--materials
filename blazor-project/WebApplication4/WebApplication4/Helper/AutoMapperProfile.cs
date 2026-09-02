using AutoMapper;
using WebApplication4.Dtos;
using WebApplication4.Model;

namespace WebApplication4.Helper;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Tours, TourDto>().ReverseMap();
    }
}