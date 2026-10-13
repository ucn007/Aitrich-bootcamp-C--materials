using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mvc_machinetest.Data;
using mvc_machinetest.Helpers;
using mvc_machinetest.Interfaces;
using mvc_machinetest.Repository;
using mvc_machinetest.Services;

namespace mvc_machinetest.Extensions;

public static class  ServiceExtensions
{
    public static IServiceCollection AddMyServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        //Db
        services.AddDbContextFactory<MyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        //services
        
        services.AddScoped<IAdminRepository , AdminRepository>();
        services.AddScoped<IAdminService, AdminServices>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        //Automapper
        
        services.AddAutoMapper(cfg => { },typeof(MappingProfile));
        
        
        // JWT Authentication
        var jwtKey = configuration["Jwt:Key"];

        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new Exception("JWT Key is missing.");
        }

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtKey)
                    )
                };

                // Read JWT from cookie
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token =
                            context.Request.Cookies["jwt"];

                        return Task.CompletedTask;
                    },

                    // Redirect unauthenticated users to Login
                    OnChallenge = context =>
                    {
                        context.HandleResponse();

                        context.Response.Redirect("/Auth/Login");

                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization();

        return services;
    }
}