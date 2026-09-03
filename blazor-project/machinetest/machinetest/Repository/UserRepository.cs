using machinetest.Interfaces;
using machinetest.Model;
using Microsoft.EntityFrameworkCore;

namespace machinetest.Repository;

public class UserRepository:IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<user>> GetAllAsync()
    {
        return await _context.users
            .ToListAsync();
    }

    public async Task<user?> GetByIdAsync(int id)
    {
        return await _context.users
            .FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<user?> GetByEmailAsync(string email)
    {
        return await _context.users
            .FirstOrDefaultAsync(x => x.email == email);
    }

    public async Task AddAsync(user user)
    {
        await _context.users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(user user)
    {
        _context.users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);

        if (user == null)
            return;

        _context.users.Remove(user);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.users
            .AnyAsync(x => x.id == id);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.users
            .AnyAsync(x => x.email == email);
    } 
}