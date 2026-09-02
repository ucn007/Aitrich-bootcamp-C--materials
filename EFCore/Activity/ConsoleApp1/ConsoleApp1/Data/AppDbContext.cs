using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Data;

public class AppDbContext: DbContext
{
    public DbSet<Tours>  Tours { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=localhost,1433;Database=TourDB;User Id=sa;Password=Ullas@123;TrustServerCertificate=True;"
        );
    }

}