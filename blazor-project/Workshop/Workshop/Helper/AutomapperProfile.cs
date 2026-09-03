using AutoMapper;
using Workshop.Dtos;
using Workshop.Model;

namespace Workshop.Helper;

public class AutomapperProfile:Profile
{
    public AutomapperProfile()
    {
       CreateMap<DestinationCreateDto, Destination>();
       CreateMap<DestinationUpdateDto, Destination>();
       CreateMap<Destination, DestinationCreateDto>();
       CreateMap<Destination, DestinationUpdateDto>();
    }
}