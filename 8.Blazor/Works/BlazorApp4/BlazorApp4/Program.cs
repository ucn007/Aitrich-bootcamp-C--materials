using BlazorApp4.Components;
using BlazorApp4.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


// ==========================================
// AUTHENTICATION
// ==========================================

builder.Services
    .AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";

        options.AccessDeniedPath =
            "/AccessDenied";

        options.ExpireTimeSpan =
            TimeSpan.FromMinutes(30);

        options.SlidingExpiration = true;

        options.Cookie.HttpOnly = true;

        options.Cookie.SecurePolicy =
            CookieSecurePolicy.SameAsRequest;

        options.Cookie.SameSite =
            SameSiteMode.Lax;
    });


// ==========================================
// AUTHORIZATION
// ==========================================

builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();


// ==========================================
// HTTP CONTEXT
// ==========================================

builder.Services.AddHttpContextAccessor();


// ==========================================
// APPLICATION SERVICES
// ==========================================

builder.Services.AddApplicationServices(
    builder.Configuration);


// ==========================================
// BLAZOR
// ==========================================

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(
        "/Error",
        createScopeForErrors: true);

    app.UseHsts();
}


// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.UseAuthentication();

app.UseAuthorization();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();