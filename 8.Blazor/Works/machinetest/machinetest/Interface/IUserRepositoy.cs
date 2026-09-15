using machinetest.Model;

namespace machinetest.Interface;

public interface IUserRepositoy
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByNameAsync(string name);
    Task<List<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<bool> DeleteAsync(int id);
}