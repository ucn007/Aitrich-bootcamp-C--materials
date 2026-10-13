using AutoMapper;
using JobApplication.DTOs;
using JobApplication.DTOs.Company;
using JobApplication.DTOs.Job;
using JobApplication.Models;

namespace JobApplication.Helpers;

public class MappingProfile: Profile
{
    
    public MappingProfile()
    {
        //User Mapping
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<RegisterDto, User>().ReverseMap();
        CreateMap<LoginDto, User>().ReverseMap();
        CreateMap<LoginResponseDto, User>().ReverseMap();
        
        //Company Mapping
        CreateMap<Company , CmpLoginDto>().ReverseMap();
        CreateMap<Company , CmpLoginResponseDto>().ReverseMap();
        CreateMap<Company , CompanyResponse>().ReverseMap();
        CreateMap<Company, CmpRegister>().ReverseMap();
        
        
        //Job Mapping
        CreateMap<Job , CreateJobDto>().ReverseMap();
        CreateMap<Job , JobResponseDto>().ReverseMap();
        CreateMap<Job , UpdateJobDto>().ReverseMap();

    }
}