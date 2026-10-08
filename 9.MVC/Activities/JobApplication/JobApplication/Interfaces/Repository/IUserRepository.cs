using JobApplication.Models;

namespace JobApplication.Interfaces.Repository;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid userId);
    
    Task<User?> GetByEmailAsync(string email);
    
    Task<List<User>> GetAllAsync();
    
    Task<User> CreateAsync(User user);
    
    Task<bool> EmailExistsAsync(string email);
    
    Task<User> UpdateAsync(User user);
    
    Task<bool> DeleteAsync(Guid userId);
}