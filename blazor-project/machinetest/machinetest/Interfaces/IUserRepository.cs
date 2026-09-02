using machinetest.Model;

namespace machinetest.Interfaces;

public interface IUserRepository

    {
        Task<List<user>> GetAllAsync();

        Task<user?> GetByIdAsync(int id);

        Task<user?> GetByEmailAsync(string email);

        Task AddAsync(user user);

        Task UpdateAsync(user user);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<bool> EmailExistsAsync(string email);
    }
