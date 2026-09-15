using machinetest.DTOs;
using machinetest.Interface;
using machinetest.Model;

namespace machinetest.Repository;

public class UserService: IUserService
{
    private readonly IUserRepositoy _userRepository;

    public UserService(IUserRepositoy userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        return MapToDto(user);
    }

    public async Task<UserResponseDto?> GetByNameAsync(string name)
    {
        var user = await _userRepository.GetByNameAsync(name);

        if (user == null)
            return null;

        return MapToDto(user);
    }

    public async Task<List<UserResponseDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users
            .Select(MapToDto)
            .ToList();
    }

    public async Task<UserResponseDto> CreateAsync(UserCreateDto dto)
    {
        var user = new User
        {
            Name = dto.Name, 
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password), 
            Role = "User", 
        };

        await _userRepository.CreateAsync(user);

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
          Password =  user.Password,
            Role = user.Role, 
        };
    }

    public async Task<UserResponseDto?> UpdateAsync(
        int id,
        UserResponseDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        user.Name = dto.Name;
        user.Password = dto.Password;
        user.Role = dto.Role;

        var updatedUser = await _userRepository.UpdateAsync(user);

        return MapToDto(updatedUser);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }

    private static UserResponseDto MapToDto(User user)
    {
        return new UserResponseDto
        {
            Name = user.Name,
            Password = user.Password,
            Role = user.Role
        };
    }
}