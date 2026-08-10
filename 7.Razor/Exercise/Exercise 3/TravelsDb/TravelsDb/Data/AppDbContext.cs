using Microsoft.EntityFrameworkCore;
using TravelsDb.Models;


namespace TravelsDb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }



    }
}
