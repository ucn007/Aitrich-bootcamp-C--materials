using Microsoft.EntityFrameworkCore;
using TourDestination.Helper;
using TourDestination.Interfaces;
using TourDestination.Model;
using TourDestination.Repositories;
using TourDestination.services;

namespace TourDestination.Extension
{
    public static  class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices
           (this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Add Services
            services.AddScoped<IDestinationRepository, DestinationRepository>();
           services.AddScoped<IDestinationService, DestinationService>();
            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}
