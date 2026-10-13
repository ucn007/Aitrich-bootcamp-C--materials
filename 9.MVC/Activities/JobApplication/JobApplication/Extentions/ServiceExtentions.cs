using System.Text;
using JobApplication.Configuration;
using JobApplication.Data;
using JobApplication.Helpers;
using JobApplication.Interfaces.Repository;
using JobApplication.Interfaces.Services;
using JobApplication.Models;
using JobApplication.Repository;
using JobApplication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using sitecraft_backend.Repository;

namespace JobApplication.Extentions;

public static class ServiceExtentions
{
public static IServiceCollection AddServiceExtentions(
this IServiceCollection services,
IConfiguration configuration)
{
// Database
services.AddDbContextFactory<MyDbContext>(
options =>
options.UseSqlServer(
configuration.GetConnectionString("defaultConnection")
)
);

 

    // Repositories
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<ICompanyRepository, CompanyRepository>();
    services.AddScoped<IJobRepository, JobRepository>();

    // Services
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ICompanyService, CompanyService>();
    services.AddScoped<ICompanyAuthService, CompanyAuthService>();
    services.AddScoped<IJobServices, JobServices>();

    // JWT Settings
    services.Configure<JwtSettings>(
        configuration.GetSection("Jwt")
    );

    // JWT Authentication
    var jwtKey = configuration["Jwt:Key"];

    if (string.IsNullOrWhiteSpace(jwtKey))
    {
        throw new InvalidOperationException(
            "JWT Key is missing from appsettings.json."
        );
    }

    services
        .AddAuthentication(
            JwtBearerDefaults.AuthenticationScheme
        )
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer =
                        configuration["Jwt:Issuer"],

                    ValidAudience =
                        configuration["Jwt:Audience"],

                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtKey)
                        )
                };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var token =
                        context.Request.Cookies["jwt"];

                    if (!string.IsNullOrEmpty(token))
                    {
                        context.Token = token;
                    }

                    return Task.CompletedTask;
                },

                OnChallenge = async context =>
                {
                    context.HandleResponse();

                    context.Response.Redirect(
                        "/Auth/Login"
                    );

                    await Task.CompletedTask;
                }
            };
        });

    // AutoMapper
    services.AddAutoMapper(
        cfg => { },
        typeof(MappingProfile)
    );

    return services;
}


}
