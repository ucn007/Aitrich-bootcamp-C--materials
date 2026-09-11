using BlazorApp5.Interfaces;
using BlazorApp5.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5.Repository;

public class UserRepository:IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

   public async Task<IEnumerable<User>> GetUsersAsync()
   {
       return await _context.Users.ToListAsync();
   }

   public async Task<bool> UserExistsAsync(string email)
   {
       return await _context.Users.AnyAsync(x => x.Email == email);
   }

   public async Task<User> CreateUserAsync(User user)
   {
       _context.Users.Add(user);
       await _context.SaveChangesAsync();
       return user;
   }

   public async Task<User> UpdateUserAsync(User user)
   {
       _context.Users.Update(user);
       await _context.SaveChangesAsync();

       return user;
   }

   public async Task<bool> DeleteUserAsync(int id)
   {
       var user = await GetUserByIdAsync(id);

       if (user == null)
           return false;

       _context.Users.Remove(user);
       await _context.SaveChangesAsync();

       return true;
   }
}