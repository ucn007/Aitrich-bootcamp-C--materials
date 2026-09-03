using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model;

public class ApplicationDbContext : DbContext
{
  public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
  
  public DbSet<Doctor> Doctors { get; set; }
}