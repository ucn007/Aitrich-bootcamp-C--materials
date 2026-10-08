using Microsoft.EntityFrameworkCore;
using MVC_Sample.Models;

namespace MVC_Sample.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        
        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection")));

        return services;

    }
}