using AutoMapper;
using BlazorApp3.DTOs;
using BlazorApp3.Model;

namespace BlazorApp3.Helpers;

public class AutoMapperProfile: Profile
{

    public AutoMapperProfile()
    {
        CreateMap<LoginDto, User>();
        CreateMap<RegisterDto, User>();
        CreateMap<User,RegisterDto>();
        CreateMap<User, LoginDto>();
        CreateMap<TourCreateDto, Tour>();
        CreateMap<Tour, TourCreateDto>();
        CreateMap<Tour, TourUpdateDto>();
        CreateMap<TourUpdateDto, Tour>();
        CreateMap<Booking, BookingDto>();
        CreateMap<BookingDto, Booking>();
        
    }
    
}