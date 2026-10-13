using mvc_machinetest.DTOs.Admin;

namespace mvc_machinetest.Interfaces;

public interface IAdminService
{
    Task<UserResponseDto> RegisterAsync(RegisterDto dto);
    Task<LoginResponse?> LoginAsync(LoginDto dto);
    Task<UserResponseDto?> GetByIdAsync(int id);
    Task<List<UserResponseDto>> GetAllAsync();  
}