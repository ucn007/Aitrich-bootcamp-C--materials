using machinetest.Data;
using machinetest.Helpers;
using machinetest.Interface;
using machinetest.Model;
using machinetest.Repository;
using machinetest.Services;
using Microsoft.EntityFrameworkCore;

namespace machinetest.Extentions;

public static class ApplicationServiceExtention
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContextFactory<MyDbContext>(options =>
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection")));


        services.AddScoped<IUserRepositoy, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IDoctorService, DoctorService>();
        
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        
        services.AddAutoMapper(cfg => { }, typeof(MappingProfile));
        return services;
    }
}