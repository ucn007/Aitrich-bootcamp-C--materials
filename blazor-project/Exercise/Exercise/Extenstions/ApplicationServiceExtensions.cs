using Exercise.Helpers;
using Exercise.Interfaces;
using Exercise.Model;
using Exercise.Repository;
using Exercise.Services;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Extenstions;

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

            
        // Repositories
        services.AddScoped<IDestinationRepository, DestinationRepository>();

        // Services
        services.AddScoped<IDestinationService, DestinationService>();
        
        
        // Tour
        services.AddScoped<ITourRepository, TourRepository>();
        services.AddScoped<ITourService, TourService>();

        
        
        
        // Users
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        
        
        // AutoMapper
        services.AddAutoMapper(typeof(AutoMapperProfile));

        return services;
    }
    

}