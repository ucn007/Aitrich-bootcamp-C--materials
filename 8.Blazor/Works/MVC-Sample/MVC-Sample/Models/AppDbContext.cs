using Microsoft.EntityFrameworkCore;

namespace MVC_Sample.Models;

public class AppDbContext:DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Student> Students { get; set; }
    
}