using Microsoft.EntityFrameworkCore;

namespace machinetest.Model;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
    public DbSet<user> users { get; set; }
    public DbSet<book> books { get; set; }
    
    
}