using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Model;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    
        public DbSet<Tours> Tour { get; set; }
        public DbSet<Destination> Destination { get; set; }
    
}