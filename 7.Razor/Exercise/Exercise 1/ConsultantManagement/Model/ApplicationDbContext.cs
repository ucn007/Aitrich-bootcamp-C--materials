using Microsoft.EntityFrameworkCore;

namespace ConsultantManagement.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       public DbSet<Consultants>Consultants { get; set; }
        public DbSet<Register> Registers { get; set; }

    }
}
