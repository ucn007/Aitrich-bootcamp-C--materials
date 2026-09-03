using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TourManageDb.Data;
using TourManageDb.Extension;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddServiceExtension(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register ProtectedSessionStorage so components can inject it
builder.Services.AddScoped<ProtectedSessionStorage>();

var app = builder.Build();

// Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();   // session must be AFTER UseRouting

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();