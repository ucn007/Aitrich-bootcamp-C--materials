using AutoMapper;
using machinetest.Dtos;
using machinetest.Model;

namespace machinetest.Helpers;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BookCreateDto, book>();
        CreateMap<book, BookCreateDto>();
        CreateMap<book, BookUpdateDto>();
        CreateMap<BookUpdateDto, book>();
        CreateMap<user, UserCreateDto>();
        CreateMap<UserCreateDto ,user>();
    }
    
}