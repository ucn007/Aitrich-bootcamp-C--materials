using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Model;

public class ApplicationDbContext:DbContext
{
    public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
    
    public DbSet<Tours> Tour { get; set; }
}