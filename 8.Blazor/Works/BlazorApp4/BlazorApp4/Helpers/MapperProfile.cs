using AutoMapper;
using BlazorApp4.DTOs;
using BlazorApp4.Model;

namespace BlazorApp4.Helpers;

public class MapperProfile: Profile
{
    public MapperProfile()
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
        CreateMap<Booking, CreateBookingDto>();
        CreateMap<CreateBookingDto, Booking>();
        
        
    }
}