using AutoMapper;
using TourAgency_login.Model;
using TourConsultant_login.Dtos;

namespace TourConsultant_login.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<User, UserRegisterDto>().ReverseMap();
        }
        

    }
}
