using AutoMapper;
using machinetest.DTOs;
using machinetest.Model;

namespace machinetest.Helpers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<Appoinment, AppointmentDto>().ReverseMap();
    }
}