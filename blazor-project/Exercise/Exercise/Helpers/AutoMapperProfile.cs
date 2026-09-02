using AutoMapper;
using Exercise.Dtos;
using Exercise.Model;

namespace Exercise.Helpers;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<DestinationCreate, Destination>();
        CreateMap<DestinationUpdate, Destination>();
        CreateMap<Destination, DestinationCreate>();
        CreateMap<Destination, DestinationUpdate>();
        CreateMap<TourCreate, TourPackage>();
        CreateMap<TourPackage, TourCreate>();
        CreateMap<TourPackage, TourUpdate>();
        CreateMap<TourCreate, TourPackage>();
        CreateMap<TourUpdate, TourPackage>();
        CreateMap<UserCreate, User>();
        CreateMap<User, UserCreate>();
    }
}