using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public class ApplicationDbContext:DbContext
{
    public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}