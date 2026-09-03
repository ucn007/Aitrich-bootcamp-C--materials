using Microsoft.EntityFrameworkCore;

namespace TourManagement.Model
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}
