using JobApplication.DTOs;

namespace JobApplication.Interfaces.Services;

public interface IUserService
{
    Task<List<UserResponseDto>> GetAllAsync();

    Task<UserResponseDto?> GetByIdAsync(Guid userId);

    Task<UserResponseDto> RegisterAsync(RegisterDto registerDto);

    Task<UserResponseDto?> UpdateAsync(
        Guid userId,
        RegisterDto registerDto);

    Task<bool> DeleteAsync(Guid userId);
}