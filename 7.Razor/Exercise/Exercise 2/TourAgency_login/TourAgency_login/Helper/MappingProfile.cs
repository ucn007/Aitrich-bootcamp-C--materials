using AutoMapper;
using TourAgency_login.Model;
using TourConsultant_login.Dtos;
using TourConsultant_login.Model;

namespace TourConsultant_login.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<Tour, TourRegisterDto>().ReverseMap();
            CreateMap<Tour, TourUpdateDto>().ReverseMap();
        }
        

    }
}
