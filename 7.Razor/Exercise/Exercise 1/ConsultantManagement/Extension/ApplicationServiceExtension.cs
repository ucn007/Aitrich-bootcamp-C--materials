using ConsultantManagement.Helper;
using ConsultantManagement.Model;
using ConsultantManagement.Repository;
using ConsultantManagement.Service;
using Microsoft.EntityFrameworkCore;

namespace ConsultantManagement.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            // Add Services
            services.AddScoped<ConsultantService>();
            services.AddScoped<ConsultantRepository>();
            services.AddScoped<RegisterService>();
            services.AddScoped<RegisterRepository>();
            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services;
        }
    }
}
