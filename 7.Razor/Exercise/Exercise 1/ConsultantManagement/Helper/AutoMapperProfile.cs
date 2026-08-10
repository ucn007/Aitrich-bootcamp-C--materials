using AutoMapper;
using ConsultantManagement.Dto;
using ConsultantManagement.Model;

namespace ConsultantManagement.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Consultants,ConsultantDto>().ReverseMap();
            CreateMap<Register,RegisterDto>().ReverseMap();

        }
    }
}
