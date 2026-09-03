using Microsoft.EntityFrameworkCore;
using TourDestination.Extension;
using TourDestination.Interfaces;
using TourDestination.Model;
using TourDestination.Repositories;
using TourDestination.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.MapFallbackToPage("/Destination/Index");

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapGet("/", context =>
{
    context.Response.Redirect("/Destination/Index");
    return Task.CompletedTask;
});

app.Run();
