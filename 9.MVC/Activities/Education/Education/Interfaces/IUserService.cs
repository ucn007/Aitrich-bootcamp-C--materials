using Education.DTOs.User;

namespace Education.Interfaces;

public interface IUserService
{
    // Register
    Task<bool> RegisterAsync(RegisterDto dto);

    // Login
    Task<UserDto?> LoginAsync(LoginUserDto dto);

    // Find user
    Task<UserDto?> GetByIdAsync(int userId);

    Task<UserDto?> GetByEmailAsync(string email);

    // Edit user
    Task<bool> UpdateAsync(UpdateUserDto dto);

    // Check email
    Task<bool> EmailExistsAsync(string email);
}