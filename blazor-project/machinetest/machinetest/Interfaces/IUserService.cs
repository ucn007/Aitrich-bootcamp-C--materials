using machinetest.Dtos;
using machinetest.Model;

namespace machinetest.Interfaces;

public interface IUserService
{
    Task<List<UserCreateDto>> GetAllAsync();
    Task<user?> LoginAsync(string email, string password);
    Task<UserCreateDto?> GetByIdAsync(int id);

    Task<UserCreateDto> CreateAsync(UserCreateDto dto);

    Task<bool> UpdateAsync(int id, UserCreateDto dto);

    Task<bool> DeleteAsync(int id);

    Task<bool> EmailExistsAsync(string email);
    
    Task<UserCreateDto?> GetByEmailAsync(string email);
}