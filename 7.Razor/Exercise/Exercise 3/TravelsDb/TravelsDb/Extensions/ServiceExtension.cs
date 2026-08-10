using TravelsDb.Data;
using TravelsDb.Interfaces;
using TravelsDb.Services;
using Microsoft.EntityFrameworkCore;
using TravelsDb.Repositories;

namespace TravelsDb.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceExtensions(this IServiceCollection service, IConfiguration config)
        {
       
            service.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            service.AddScoped<IUserServices, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();

            service.AddScoped<IDestinationRepository, DestinationRepository>();
            service.AddScoped<IDestinationService, DestinationService>();

            service.AddAutoMapper(typeof(Program).Assembly);

            return service;
        }
    }
}


