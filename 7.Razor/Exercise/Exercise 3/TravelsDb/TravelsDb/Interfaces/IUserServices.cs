using TravelsDb.DTO;
using TravelsDb.Models;

namespace TravelsDb.Interfaces
{
    public interface IUserServices
    {
        public Task<User?> LoginAsync(string email, string password);
        public Task<bool> EmailExistsAsync(string email);
        public Task RegisterAsync(UserDto dto);
    }
}
