using Microsoft.EntityFrameworkCore;
using TourAgency_login.Model;

namespace TourConsultant_login.Model
{
    public class ApplicationDbContext:DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }

        public virtual DbSet<Destination> Destination { get; set; }
    }
}
