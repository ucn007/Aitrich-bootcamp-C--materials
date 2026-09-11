using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Model;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
    
    public DbSet<Tours> Tours { get; set; }
}