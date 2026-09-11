using AutoMapper;
using BlazorApp2.DTOs;
using BlazorApp2.Model;

namespace BlazorApp2.Helpers;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TourCreateDto, Tours>();
        CreateMap<Tours,TourCreateDto>();
        CreateMap<TourUpdateDto, Tours>();
        CreateMap<Tours,TourUpdateDto>();
    }
}