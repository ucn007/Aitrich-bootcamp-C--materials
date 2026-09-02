using Microsoft.EntityFrameworkCore;
using Workshop.Helper;
using Workshop.Interfaces;
using Workshop.Model;
using Workshop.Repositories;
using Workshop.Services;

namespace Workshop.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection")
            ));

        services.AddScoped<IDestinationRepository, DestinationRepository>();

        services.AddScoped<IDestinationService, DestinationService>();

        services.AddAutoMapper(typeof(AutomapperProfile));

        return services;
    }
}