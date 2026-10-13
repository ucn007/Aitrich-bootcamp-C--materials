using mvc_machinetest.Models;

namespace mvc_machinetest.Interfaces;

public interface IAdminRepository
{
    Task<Admin?> GetByEmailAsync(string email);
    Task<Admin?> GetByIdAsync(int id);
    Task<List<Admin>> GetAllAsync();
    Task<Admin> CreateAsync(Admin admin);
}