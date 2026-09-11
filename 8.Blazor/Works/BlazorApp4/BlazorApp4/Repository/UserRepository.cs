using BlazorApp4.Interfaces;
using BlazorApp4.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Repository;

public class UserRepository:IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    
    public async Task<User> AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser == null) 
            return false; 
        existingUser.FirstName = user.FirstName; 
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber; 
        existingUser.Address = user.Address; 
        existingUser.Role = user.Role; 
        await _context.SaveChangesAsync(); 
        return true;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id); 
        if (user == null) 
            return false; 
        _context.Users.Remove(user); 
        await _context.SaveChangesAsync(); 
        return true;
    }
}