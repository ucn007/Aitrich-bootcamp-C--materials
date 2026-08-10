using TourAgency_login.Model;
using TourConsultant_login.Dtos;

namespace TourConsultant_login.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserRegisterDto dto);         // validates and creates user
        Task<User?> LoginAsync(UserLoginDto dto);             // validates credentials
        Task<bool> ChangePasswordAsync(UserChangePasswordDto dto); // updates password
    }
}
