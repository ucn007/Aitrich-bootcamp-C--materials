using mvc_machinetest.DTOs.Admin;
using mvc_machinetest.Interfaces;
using mvc_machinetest.Models;

namespace mvc_machinetest.Services;

public class AdminServices:IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IJwtService _jwtService;

    public AdminServices(IAdminRepository adminRepository, IJwtService jwtService)
    {
        _adminRepository = adminRepository;
        _jwtService = jwtService;
    }


   public async Task<UserResponseDto> RegisterAsync(RegisterDto dto)
    {
        var existingAdmin = await _adminRepository.GetByEmailAsync(dto.Email);

        if (existingAdmin != null)
        {
            throw new Exception("Admin with this email already exists.");
        }
        var admin = new Admin
        {
            Name = dto.Name,
            Phone = dto.Phone,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow
        };

        var createdAdmin = await _adminRepository.CreateAsync(admin);

        return new UserResponseDto
        {
            Id = createdAdmin.Id,
            Name = createdAdmin.Name,
            Phone = createdAdmin.Phone,
            Email = createdAdmin.Email,
            CreatedAt = createdAdmin.CreatedAt
        };
    }

    public async Task<LoginResponse?> LoginAsync(LoginDto dto)
    {
        var admin = await _adminRepository.GetByEmailAsync(dto.Email);

        if (admin == null)
        {
            return null;
        }

        bool passwordValid = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            admin.PasswordHash
        );

        if (!passwordValid)
        {
            return null;
        }

        var token = _jwtService.GenerateToken(admin);

        return new LoginResponse
        {
            Token = token,
            User = new UserResponseDto
            {
                Id = admin.Id,
                Name = admin.Name,
                Phone = admin.Phone,
                Email = admin.Email,
                CreatedAt = admin.CreatedAt
            }
        };
    }

    public async Task<UserResponseDto?> GetByIdAsync(int id)
    {
        var admin = await _adminRepository.GetByIdAsync(id);

        if (admin == null)
        {
            return null;
        }

        return new UserResponseDto
        {
            Id = admin.Id,
            Name = admin.Name,
            Phone = admin.Phone,
            Email = admin.Email,
            CreatedAt = admin.CreatedAt
        }; 
    }

    public async Task<List<UserResponseDto>> GetAllAsync()
    {
        var admins = await _adminRepository.GetAllAsync();

        return admins.Select(admin => new UserResponseDto
        {
            Id = admin.Id,
            Name = admin.Name,
            Phone = admin.Phone,
            Email = admin.Email,
            CreatedAt = admin.CreatedAt
        }).ToList();
    }
    
    
}