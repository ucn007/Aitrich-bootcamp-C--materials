using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TourDestination.Model
{
  
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

            public DbSet<Destination> Destinations { get; set; } = null!;
        }
    }

