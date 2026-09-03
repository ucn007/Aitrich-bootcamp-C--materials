using System.Security.Cryptography;
using AutoMapper;
using Exercise.Dtos;
using Exercise.Interfaces;
using Exercise.Model;

namespace Exercise.Services;

public class UserService:IUserService
{
     private readonly IUserRepository _repo;
    private readonly IMapper _mapper;

    public UserService(
        IUserRepository repo,
        IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<UserCreate>> GetAllAsync()
    {
        var users = await _repo.GetAllAsync();

        return _mapper.Map<List<UserCreate>>(users);
    }

    public async Task<UserCreate?> GetByIdAsync(int id)
    {
        var user = await _repo.GetByIdAsync(id);

        if (user == null)
            return null;

        return _mapper.Map<UserCreate>(user);
    }

    public async Task<UserCreate> CreateAsync(UserCreate dto)
    {
        var emailExists = await _repo.EmailExistsAsync(dto.Email);

        if (emailExists)
            throw new InvalidOperationException(
                "A user with this email already exists."
            );

        var user = _mapper.Map<User>(dto);

        user.PasswordSalt = Convert.ToBase64String(
            RandomNumberGenerator.GetBytes(16)
        );

        user.Password = HashPassword(
            dto.Password,
            user.PasswordSalt
        );

        await _repo.AddAsync(user);

        return _mapper.Map<UserCreate>(user);
    }

    public async Task<bool> UpdateAsync(int id, UserCreate dto)
    {
        var user = await _repo.GetByIdAsync(id);

        if (user == null)
            return false;

        user.Name = dto.Name;
        user.Email = dto.Email;
        user.Phone = dto.Phone;

        // Generate a new password hash
        user.PasswordSalt = Convert.ToBase64String(
            RandomNumberGenerator.GetBytes(16)
        );

        user.Password = HashPassword(
            dto.Password,
            user.PasswordSalt
        );

        await _repo.UpdateAsync(user);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!await _repo.ExistsAsync(id))
            return false;

        await _repo.DeleteAsync(id);

        return true;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _repo.EmailExistsAsync(email);
    }

    private static string HashPassword(
        string password,
        string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            saltBytes,
            100_000,
            HashAlgorithmName.SHA256,
            32
        );

        return Convert.ToBase64String(hash);
    }
    
    public async Task<UserCreate?> GetByEmailAsync(string email)
    {
        var user = await _repo.GetByEmailAsync(email);

        if (user == null)
            return null;

        return _mapper.Map<UserCreate>(user);
    }
    
    public async Task<User?> LoginAsync(string email, string password)
    {
        var user = await _repo.GetByEmailAsync(email);

        if (user == null)
            return null;

        var saltBytes = Convert.FromBase64String(user.PasswordSalt);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            saltBytes,
            100_000,
            HashAlgorithmName.SHA256,
            32
        );

        var passwordHash = Convert.ToBase64String(hash);

        if (passwordHash != user.Password)
            return null;

        return user;
    }
}