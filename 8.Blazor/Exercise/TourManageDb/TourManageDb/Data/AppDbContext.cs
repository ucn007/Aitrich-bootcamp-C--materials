using Microsoft.EntityFrameworkCore;
using TourManageDb.Model;

namespace TourManageDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "",
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    Password = "admin123",
                    PhoneNumber = "1234567890",
                    Gender = "Male",
                    CreatedAt = DateTime.Now,
                    Role = Helper.Role.Admin
                });
        }
    }
}
