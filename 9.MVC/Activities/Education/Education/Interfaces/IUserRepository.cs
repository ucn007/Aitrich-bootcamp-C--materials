using Education.Models;

namespace Education.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int userId);

    Task<User?> GetByEmailAsync(string email);

    Task<List<User>> GetAllAsync();

    Task AddAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(int userId);

    Task<bool> EmailExistsAsync(string email);
    
}