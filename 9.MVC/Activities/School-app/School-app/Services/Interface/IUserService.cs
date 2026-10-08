using School_app.DTOs;
using School_app.DTOs.User;

namespace School_app.Services.Interface;

public interface IUserService
{
    Task<UserResponseDto> GetById(long id);
    
    Task<UserResponseDto> GetByEmail(string email);
    
    Task<IEnumerable<UserResponseDto>> GetUserAsync();
    
    Task<RegisterDto> RegisterAsync(RegisterDto dto);
    
    Task<LoginResponseDto?> LoginAsync(LoginDto dto);
    
    Task <UserResponseDto> UpdateUserAsync(long id, UserResponseDto dto);
    
    Task DeleteAsync(long id);
}