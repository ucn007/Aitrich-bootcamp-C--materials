using TourAgency_login.Model;

namespace TourConsultant_login.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string username); // fetch user from DB
        Task AddAsync(User user);                        // add new user
        Task UpdateAsync(User user);                     // update user in DB
        Task SaveAsync();
    }
}