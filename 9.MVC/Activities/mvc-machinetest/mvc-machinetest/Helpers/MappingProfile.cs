using AutoMapper;
using mvc_machinetest.DTOs.Admin;
using mvc_machinetest.DTOs.Department;
using mvc_machinetest.DTOs.Employe;
using mvc_machinetest.Models;

namespace mvc_machinetest.Helpers;

public class MappingProfile:Profile
{

    public MappingProfile()
    {
        CreateMap<Admin, LoginDto>().ReverseMap();
        CreateMap<Admin, RegisterDto>().ReverseMap();
        CreateMap<Admin, UserResponseDto>().ReverseMap();
        CreateMap<Admin, RegisterDto>().ReverseMap();
        
        CreateMap<Employee, CreateEmployeDto>().ReverseMap();
        CreateMap<Employee, UpdateEmployeDto>().ReverseMap();
        
        CreateMap<Department,CreateDeptDto>().ReverseMap();
        CreateMap<Department, UpdateDeptDto>().ReverseMap();
    }
}