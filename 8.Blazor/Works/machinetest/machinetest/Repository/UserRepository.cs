using machinetest.Data;
using machinetest.Interface;
using machinetest.Model;
using Microsoft.EntityFrameworkCore;

namespace machinetest.Repository;

public class UserRepository:IUserRepositoy
{
    private readonly MyDbContext _context;

    public UserRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetByNameAsync(string name)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
            .ToListAsync();
    }

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);

        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
}