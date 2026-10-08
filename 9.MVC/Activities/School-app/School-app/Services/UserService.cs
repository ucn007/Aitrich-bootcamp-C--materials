using AutoMapper;
using School_app.DTOs;
using School_app.DTOs.User;
using School_app.Models;
using School_app.Repository.Interface;
using School_app.Services.Interface;

namespace School_app.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> GetById(long id)
    {
        return _mapper.Map<UserResponseDto>(await _userRepository.GetById(id));
    }

    public async Task<UserResponseDto> GetByEmail(string email)
    {
        return _mapper.Map<UserResponseDto>(await _userRepository.GetByEmail(email));
    }

    public async Task<IEnumerable<UserResponseDto>> GetUserAsync()
    {
        return _mapper.Map<IEnumerable<UserResponseDto>>(await _userRepository.GetAll());
    }

    public async Task<RegisterDto> RegisterAsync(RegisterDto dto)
    {
     
        var exist = await _userRepository.GetByEmail(dto.Email);

        if (exist != null)
        {
            return null;
        }

         var user = _mapper.Map<User>(dto);
         user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
         user.Role = "User";
         user.CreatedAt = DateTime.UtcNow;
         
         var createdUser = await _userRepository.AddAsync(user);
         return _mapper.Map<RegisterDto>(createdUser);
         
    }


    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByEmail(dto.Email);

        if (user == null)
        {
            return null;
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash
        );

        if (!passwordValid)
        {
            return null;
        }

        return new LoginResponseDto
        {
            User = _mapper.Map<UserResponseDto>(user)
        };
    }

    public async Task<UserResponseDto> UpdateUserAsync(long id, UserResponseDto dto)
    {
        var user = await _userRepository.GetById(id);
        if (user == null)
            return null;
        user.Name = dto.Name;
        user.Email = dto.Email;
        user.Phone = dto.Phone;
        user.IsActive = dto.IsActive;
        var  updatedUser = await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserResponseDto>(updatedUser);
    }

    public async Task DeleteAsync(long id)
    {
        var user = await _userRepository.GetById(id);
    }
}