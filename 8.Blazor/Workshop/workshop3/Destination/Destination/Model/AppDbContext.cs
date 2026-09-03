using Microsoft.EntityFrameworkCore;

namespace Destination.Model
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Tour> Tours { get; set; }
    
    }
}
