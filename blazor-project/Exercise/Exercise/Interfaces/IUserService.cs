using Exercise.Dtos;
using Exercise.Model;

namespace Exercise.Interfaces;

public interface IUserService
{
    Task<List<UserCreate>> GetAllAsync();
    Task<User?> LoginAsync(string email, string password);
    Task<UserCreate?> GetByIdAsync(int id);

    Task<UserCreate> CreateAsync(UserCreate dto);

    Task<bool> UpdateAsync(int id, UserCreate dto);

    Task<bool> DeleteAsync(int id);

    Task<bool> EmailExistsAsync(string email);
    
    Task<UserCreate?> GetByEmailAsync(string email);
}