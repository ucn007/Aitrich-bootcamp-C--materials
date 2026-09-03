using TourManageDb.DTO;
using TourManageDb.Model;

namespace TourManageDb.Interface
{
    public interface IUserRepository
    {
        public Task<User?> LoginAsync(string email, string password);
        public Task<bool> EmailExistsAsync(string email);
        public Task RegisterAsync(User user);
    }
}
