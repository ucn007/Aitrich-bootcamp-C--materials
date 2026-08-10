using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TourConsultant_login.Helper;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;
using TourConsultant_login.Repository;
using TourConsultant_login.Service;

namespace TourConsultant_login.Extention
{
    public  static class ApplicationServiceExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Add DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );

            // Add AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            // OR: services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // Add Repository & Service
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
