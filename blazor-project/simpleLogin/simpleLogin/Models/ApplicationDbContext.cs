using Microsoft.EntityFrameworkCore;

namespace simpleLogin.Models;

public class ApplicationDbContext: DbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
}