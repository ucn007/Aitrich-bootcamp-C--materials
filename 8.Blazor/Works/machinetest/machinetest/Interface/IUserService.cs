using machinetest.DTOs;

namespace machinetest.Interface;

public interface IUserService
{
    Task<UserResponseDto?> GetByIdAsync(int id);
    Task<UserResponseDto?> GetByNameAsync(string name);
    Task<List<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto> CreateAsync(UserCreateDto dto);
    Task<UserResponseDto?> UpdateAsync(int id, UserResponseDto dto);
    Task<bool> DeleteAsync(int id);
}