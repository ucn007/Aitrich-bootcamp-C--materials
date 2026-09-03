using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TourManageDb.Data;
using TourManageDb.Helper;
using TourManageDb.Interface;
using TourManageDb.Repository;
using TourManageDb.Service;
using TravelsDb.Repositories;
using TravelsDb.Services;

namespace TourManageDb.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services, IConfiguration configuration)
        {
            // ✅ Add DbContext
            services.AddDbContextFactory<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<IDestinationService, DestinationService>();
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(UseMappingProfile));

            return services;
        }
    }
}
