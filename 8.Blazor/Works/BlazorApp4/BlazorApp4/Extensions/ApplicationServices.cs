using BlazorApp4.Helpers;
using BlazorApp4.Interfaces;
using BlazorApp4.Model;
using BlazorApp4.Repository;
using BlazorApp4.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp4.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddScoped<ProtectedSessionStorage>();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection")));
        
        
        services.AddScoped<ITourService, TourService>();
        services.AddScoped<ITourRepository, TourRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddAutoMapper(cfg => { }, typeof(MapperProfile));

        return services;
    }
}