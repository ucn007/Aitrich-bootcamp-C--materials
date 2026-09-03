using TourManageDb.DTO;
using TourManageDb.Model;

namespace TourManageDb.Interface
{
    public interface IUserService
    {
        public Task<User?> LoginAsync(string email, string password);
        public Task<bool> EmailExistsAsync(string email);
        public Task RegisterAsync(RegisterDto dto);
    }
}
