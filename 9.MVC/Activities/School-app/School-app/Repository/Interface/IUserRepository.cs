using School_app.Models;

namespace School_app.Repository.Interface;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    
    Task<User> GetById(long id);
    
    Task<User> GetByEmail(string email);
    
    Task<User> GetByUsername(string username);
    
    Task<User> GetByUsernameAndPassword(string username, string password);
    
    Task<User> GetByEmailAndPassword(string email, string password);
    
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(long id);
}