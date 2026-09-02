using Microsoft.EntityFrameworkCore;

namespace Workshop.Model;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
        
    public DbSet<Destination> Destinations { get; set; } = null!;
}