using Microsoft.EntityFrameworkCore;
using TourManagement.Helper;
using TourManagement.Interface;
using TourManagement.Model;
using TourManagement.Repository;
using TourManagement.Service;

namespace TourManagement.Extension
{
    public static class ApplicationServiceExtension
    {
        public static object AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IDestinationService, DestinatinService>();
            return services;
        }

    }
}
