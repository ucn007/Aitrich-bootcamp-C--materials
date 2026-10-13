using Education.DTOs.User;
using Education.Enums;
using Education.Interfaces;
using Education.Models;

namespace Education.Service;

public class UserService:IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        // Check email
        if (await _userRepository.EmailExistsAsync(dto.Email))
        {
            return false;
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            Gender = dto.Gender,

            // New users are students
            Role = UserRole.Student.ToString(),

            // Hash this in production
            Password = dto.Password
        };

        await _userRepository.AddAsync(user);

        return true;
    }
    
    
    
    
    public async Task<UserDto?> LoginAsync(LoginUserDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);

        if (user == null)
        {
            return null;
        }

        // Temporary comparison
        // Use password hashing in production
        if (user.Password != dto.Password)
        {
            return null;
        }

        return MapToDto(user);
    }
    
   

    public async Task<UserDto?> GetByIdAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            return null;
        }

        return MapToDto(user);
    }


    

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user == null)
        {
            return null;
        }

        return MapToDto(user);
    }


  

    public async Task<bool> UpdateAsync(UpdateUserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(dto.UserId);

        if (user == null)
        {
            return false;
        }

        // Check whether another user already has this email
        var existingUser =
            await _userRepository.GetByEmailAsync(dto.Email);

        if (existingUser != null &&
            existingUser.UserId != dto.UserId)
        {
            return false;
        }

        user.Name = dto.Name;
        user.Email = dto.Email;
        user.Phone = dto.Phone;
        user.Gender = dto.Gender;

        await _userRepository.UpdateAsync(user);

        return true;
    }


   

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _userRepository.EmailExistsAsync(email);
    }

 

    private static UserDto MapToDto(User user)
    {
        return new UserDto
        {
            UserId = user.UserId,
            Name = user.Name,
            Email = user.Email,
            Phone = user.Phone,
            Gender = user.Gender,
            Role = UserRole.Student.ToString()
        };
    }

    
    
}