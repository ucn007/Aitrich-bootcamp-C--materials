using Destination.Helper;
using Destination.Interface;
using Destination.Model;
using Destination.Repository;
using Destination.Service;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace Destination.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices
          (this IServiceCollection services, IConfiguration config)
        {
            services.AddDistributedMemoryCache(); // Required for session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<ProtectedSessionStorage>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourService, TourService>();


            return services;
            }
        }
}
