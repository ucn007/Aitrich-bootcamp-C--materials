using AutoMapper;
using BlazorApp5.DTOs;
using BlazorApp5.Interfaces;
using BlazorApp5.Model;

namespace BlazorApp5.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        return _mapper.Map<UserResponseDto?>(await _userRepository.GetUserByIdAsync(id));
    }

    public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
    {
        return _mapper.Map<IEnumerable<UserResponseDto>>(await _userRepository.GetUsersAsync());
    }


    public async Task<UserResponseDto?> RegisterAsync(RegisterDto dto)
    {
        // Check if email already exists
        var exists = await _userRepository.UserExistsAsync(dto.Email);

        if (exists)
            return null;

        // Map DTO to User
        var user = _mapper.Map<User>(dto);

        // Hash password using BCrypt
        user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        user.Role = "User";
        user.CreatedAt = DateTime.UtcNow;

        // Save user
        var createdUser = await _userRepository.CreateUserAsync(user);

        // Return response DTO
        return _mapper.Map<UserResponseDto>(createdUser);
    }




    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetUserByEmailAsync(dto.Email);

        if (user == null)
            return null;

        var passwordValid = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.Password);

        if (!passwordValid)
            return null;

        return new LoginResponseDto
        {
            User = _mapper.Map<UserResponseDto>(user)
        };
    }


    public async Task<UserResponseDto?> UpdateUserAsync(int id, UserUpdateDto dto)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null) return null;
        user.Name = dto.Name; 
        user.Email = dto.Email;
        user.PhoneNumber = dto.PhoneNumber;
        var updatedUser = await _userRepository.UpdateUserAsync(user);
        return _mapper.Map<UserResponseDto>(updatedUser);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
        
        
        
        
}