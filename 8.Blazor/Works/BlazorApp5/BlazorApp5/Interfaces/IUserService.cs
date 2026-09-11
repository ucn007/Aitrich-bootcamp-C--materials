using BlazorApp5.DTOs;

namespace BlazorApp5.Interfaces;

public interface IUserService
{
    Task<UserResponseDto?> GetUserByIdAsync(int id);
    Task<IEnumerable<UserResponseDto>> GetUsersAsync(); 
    Task<UserResponseDto?> RegisterAsync(RegisterDto dto); 
    Task<LoginResponseDto?> LoginAsync(LoginDto dto); 
    Task<UserResponseDto?> UpdateUserAsync(int id, UserUpdateDto dto);
    Task<bool> DeleteUserAsync(int id);
}