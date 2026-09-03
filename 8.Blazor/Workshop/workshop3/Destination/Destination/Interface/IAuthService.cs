using Destination.Dto;

namespace Destination.Interface
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterDto registerDto, string password);
        Task<bool> Login(string email, string password);
        Task Logout();
    }
}
