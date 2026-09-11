using BlazorApp4.Model;

namespace BlazorApp4.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync(); 
    
    Task<User?> GetUserByIdAsync(int id); 
    
    Task<User?> GetUserByEmailAsync(string email); 
    
    Task<User> AddUserAsync(User user); 
    
    
    Task<bool> UpdateUserAsync(User user); 
    
    Task<bool> DeleteUserAsync(int id);
}