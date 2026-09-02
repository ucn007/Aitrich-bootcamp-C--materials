
using AutoMapper;
using machinetest.Dtos;
using machinetest.Interfaces;
using machinetest.Model;

namespace machinetest.Services;

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
    
    
        public async Task<List<UserCreateDto>> GetAllAsync()
    {
        var users = await _repo.GetAllAsync();

        return _mapper.Map<List<UserCreateDto>>(users);
    }

    public async Task<UserCreateDto?> GetByIdAsync(int id)
    {
        var user = await _repo.GetByIdAsync(id);

        if (user == null)
            return null;

        return _mapper.Map<UserCreateDto>(user);
    }

    public async Task<UserCreateDto> CreateAsync(UserCreateDto dto)
    {
        var emailExists = await _repo.EmailExistsAsync(dto.email);

        if (emailExists)
            throw new InvalidOperationException(
                "A user with this email already exists."
            );

        var user = _mapper.Map<user>(dto);

        await _repo.AddAsync(user);

        return _mapper.Map<UserCreateDto>(user);
    }

    public async Task<bool> UpdateAsync(int id, UserCreateDto dto)
    {
        var user = await _repo.GetByIdAsync(id);

        if (user == null)
            return false;

        user.name = dto.name;
        user.email = dto.email;
        user.phone = dto.phone; 


        user.password = dto.password;
        

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

 
    
    public async Task<UserCreateDto?> GetByEmailAsync(string email)
    {
        var user = await _repo.GetByEmailAsync(email);

        if (user == null)
            return null;

        return _mapper.Map<UserCreateDto>(user);
    }
    
    public async Task<user?> LoginAsync(string email, string password)
    {
        var user = await _repo.GetByEmailAsync(email);

        if (user == null)
            return null;
        
        if (password != user.password)
            return null;

        return user;
    }
}