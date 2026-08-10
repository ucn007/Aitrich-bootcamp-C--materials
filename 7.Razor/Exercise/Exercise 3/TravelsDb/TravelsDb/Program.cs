using TravelsDb.Data;
using TravelsDb.Extensions;
using TravelsDb.Helper;
using TravelsDb.Interfaces;
using TravelsDb.Models;
using TravelsDb.Services;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();

builder.Services.AddServiceExtensions(builder.Configuration);

// ✅ REQUIRED for Session
builder.Services.AddDistributedMemoryCache();

// ✅ Add Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // optional
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Seed Static Admin
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Users.Any(u => u.Email == "admin@gmail.com"))
    {
        context.Users.Add(new User
        {
            UserName = "Admin",
            Email = "admin@gmail.com",
            Password = "Admin@123",
            Role = Role.Admin
        });

        context.SaveChanges();
    }
}

// Configure pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();   // 🔥 IMPORTANT (missing in your code)

app.UseRouting();

// ✅ Session BEFORE Authorization
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();