using AutoMapper;
using JobApplication.DTOs;
using JobApplication.Interfaces.Repository;
using JobApplication.Interfaces.Services;
using JobApplication.Models;

namespace JobApplication.Services;

public class UserService:IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserResponseDto>> GetAllAsync()
    {
        return _mapper.Map<List<UserResponseDto>>(await _userRepository.GetAllAsync());
    }

    public async Task<UserResponseDto?> GetByIdAsync(Guid userId)
    {
        return _mapper.Map<UserResponseDto>(await _userRepository.GetByIdAsync(userId));
    }

    public async Task<UserResponseDto> RegisterAsync(RegisterDto registerDto)
    {
        var exist = await _userRepository.GetByEmailAsync(registerDto.Email);
        if (exist != null)
        {
            return null;
        }
        var user = _mapper.Map<User>(registerDto);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        user.Email = registerDto.Email;
        user.CreatedAt = DateTime.Now;
        
        var createdUser = await _userRepository.CreateAsync(user);
        return _mapper.Map<UserResponseDto>(createdUser);
    }

    public async Task<UserResponseDto?> UpdateAsync(
        Guid userId,
        RegisterDto registerDto)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            {
            return null;
            }
        user.Name = registerDto.Name;
        user.Email = registerDto.Email;
        user.Phone =  registerDto.Phone;
        
        var updatedUser = await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserResponseDto>(updatedUser);
    }

    public async Task<bool> DeleteAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
            return false;
        }
        

        await _userRepository.DeleteAsync(userId);

        return true;
    }
}