using BlazorApp5.Helper;
using BlazorApp5.Interfaces;
using BlazorApp5.Model;
using BlazorApp5.Repository;
using BlazorApp5.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp5.Extention;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContextFactory<ApplicationDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection")));


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
            
        services.AddAutoMapper(cfg => { }, typeof(MapperProfile));
        
        
        return services;
    }
}