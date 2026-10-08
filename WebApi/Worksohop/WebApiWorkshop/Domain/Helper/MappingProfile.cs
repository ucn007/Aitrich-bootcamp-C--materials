using AutoMapper;
using Domain.Models;
using Domain.Services.Destinations.DTO;
using Domain.Services.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {


            CreateMap<Destination, DestinationDto>().ReverseMap();
            CreateMap<Destination, DestinationResponseDto>().ReverseMap();


            CreateMap<AddUserDto, AuthUser>().ReverseMap();

            CreateMap<AuthUser, UserResponseDto>().ReverseMap();

        }
    }
}
