using BlazorApp4.DTOs;
using BlazorApp4.Interfaces;
using BlazorApp4.Model;

namespace BlazorApp4.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<User> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(dto.Email);
        if (existingUser != null)
        {
            throw new Exception("Email is already registered.");
        }
        var user = new User { 
            FirstName = dto.FirstName, 
            LastName = dto.LastName, 
            Email = dto.Email, 
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            PhoneNumber = dto.PhoneNumber, Address = dto.Address, 
            Role = "User", 
            CreatedAt = DateTime.UtcNow 
        };
        return await _userRepository.AddUserAsync(user);
    }
    public async Task<User?> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetUserByEmailAsync(dto.Email);

        if (user == null)
            return null;

        var passwordValid =
            BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

        if (!passwordValid)
            return null;

        return user;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task<bool> UpdateUserAsync(int id, User user)
    {
        if (id != user.Id)
        {
            return false;
        }
        return await _userRepository.UpdateUserAsync(user);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
        
        
}