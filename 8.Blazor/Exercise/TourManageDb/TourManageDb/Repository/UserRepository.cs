using Microsoft.EntityFrameworkCore;
using TourManageDb.Data;
using TourManageDb.Interface;
using TourManageDb.Model;

namespace TravelsDb.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<AppDbContext> factory;

        public UserRepository(IDbContextFactory<AppDbContext> factory)
        {
            this.factory = factory;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            using var context = await factory.CreateDbContextAsync();

            email = email.Trim();
            password = password.Trim();

            return await context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            using var context = await factory.CreateDbContextAsync();

            return await context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task RegisterAsync(User user)
        {
            using var context = await factory.CreateDbContextAsync();

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}