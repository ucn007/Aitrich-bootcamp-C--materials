using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School_app.Data;
using School_app.Helper;
using School_app.Repository;
using School_app.Repository.Interface;
using School_app.Services;
using School_app.Services.Interface;

namespace School_app.Extensions;

public static class SchoolServiceExtension
{
    public static IServiceCollection AddSchoolServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // DB
        services.AddDbContextFactory<MyDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            )
        );
        
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    CookieAuthenticationDefaults.AuthenticationScheme;

                options.DefaultSignInScheme =
                    CookieAuthenticationDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme =
                    CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.Cookie.Name = "SchoolApp.Auth";
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.Lax;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/AccessDenied";

                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.SlidingExpiration = true;
            });

        services.AddAuthorization();
        
        //user service and repository
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();

        // AutoMapper
        services.AddAutoMapper(
            cfg => { },
            typeof(MappingProfile)
        );

        return services;
    }
}