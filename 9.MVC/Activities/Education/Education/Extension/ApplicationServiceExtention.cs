using Education.Data;
using Education.Helper;
using Education.Interfaces;
using Education.Repository;
using Education.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Education.Extension;

public static class ApplicationServiceExtention
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContextFactory<MyDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection")));

        
        //session
        
        services.AddDistributedMemoryCache();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        
        
        
        
        //user
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService,UserService>();
      
            
        services.AddAutoMapper(cfg => { }, typeof(MappingProfile));
        
        
        return services;
    }
}