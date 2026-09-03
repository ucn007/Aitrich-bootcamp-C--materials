using Microsoft.EntityFrameworkCore;

namespace Exercise.Model;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<TourPackage> TourPackages { get; set; }
}