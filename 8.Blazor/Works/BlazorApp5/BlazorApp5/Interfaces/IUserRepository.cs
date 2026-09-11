using BlazorApp5.Model;

namespace BlazorApp5.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(int id); 
    Task<User?> GetUserByEmailAsync(string email); 
    Task<IEnumerable<User>> GetUsersAsync();
    Task<bool> UserExistsAsync(string email); 
    Task<User> CreateUserAsync(User user); 
    Task<User> UpdateUserAsync(User user); 
    Task<bool> DeleteUserAsync(int id);
}