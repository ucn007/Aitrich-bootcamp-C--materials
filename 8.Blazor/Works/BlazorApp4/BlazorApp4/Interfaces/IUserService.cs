using BlazorApp4.DTOs;
using BlazorApp4.Model;

namespace BlazorApp4.Interfaces;

public interface IUserService
{
    Task<User> RegisterAsync(RegisterDto dto);
    Task<User?> LoginAsync(LoginDto dto); 
    Task<User?> GetUserByIdAsync(int id); 
    Task<IEnumerable<User>> GetAllUsersAsync(); 
    Task<bool> UpdateUserAsync(int id, User user); 
    Task<bool> DeleteUserAsync(int id);
}