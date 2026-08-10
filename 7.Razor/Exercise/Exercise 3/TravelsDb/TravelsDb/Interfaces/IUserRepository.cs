using TravelsDb.Models;

namespace TravelsDb.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> LoginAsync(string email, string password);
        public Task<bool> EmailExistsAsync(string email);
        public Task RegisterAsync(User user);
    }
}
