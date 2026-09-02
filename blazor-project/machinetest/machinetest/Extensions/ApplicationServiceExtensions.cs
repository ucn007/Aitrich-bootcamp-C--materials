using machinetest.Helpers;
using machinetest.Interfaces;
using machinetest.Model;
using machinetest.Repository;
using machinetest.Services;
using Microsoft.EntityFrameworkCore;

namespace machinetest.Extensions;

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
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IUserService, UserService>();
        
        
        services.AddAutoMapper(typeof(AutoMapperProfile));

        return services;
    }
}