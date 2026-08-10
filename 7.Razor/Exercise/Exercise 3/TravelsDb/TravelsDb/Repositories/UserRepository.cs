using Microsoft.EntityFrameworkCore;
using TravelsDb.Data;
using TravelsDb.Interfaces;
using TravelsDb.Models;

namespace TravelsDb.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly AppDbContext context;
        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task RegisterAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
