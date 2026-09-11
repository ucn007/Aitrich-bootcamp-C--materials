using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

using BlazorApp5.Components;
using BlazorApp5.Extention;
using BlazorApp5.DTOs;
using BlazorApp5.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// SERVICES
// ==========================================

builder.Services.AddApplicationServices(
    builder.Configuration);


// ==========================================
// AUTHENTICATION
// ==========================================

builder.Services
    .AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";

        options.ExpireTimeSpan = TimeSpan.FromHours(8);

        options.SlidingExpiration = true;

        options.Cookie.Name = "BlazorApp5.Auth";

        options.Cookie.HttpOnly = true;

        options.Cookie.SecurePolicy =
            CookieSecurePolicy.Always;

        options.Cookie.SameSite =
            SameSiteMode.Lax;
    });


// ==========================================
// AUTHORIZATION
// ==========================================

builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();


// ==========================================
// BLAZOR
// ==========================================

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();


// ==========================================
// HTTP REQUEST PIPELINE
// ==========================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(
        "/Error",
        createScopeForErrors: true);

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();


// ==========================================
// AUTHENTICATION & AUTHORIZATION
// ==========================================

app.UseAuthentication();

app.UseAuthorization();


// ==========================================
// LOGIN ENDPOINT
// ==========================================

app.MapPost(
        "/auth/login",
        async (
            [FromForm] LoginDto loginDto,
            IUserService userService,
            HttpContext httpContext) =>
        {
            var response = await userService.LoginAsync(loginDto);

            if (response?.User == null)
            {
                return Results.Redirect("/Login?error=invalid");
            }

            var user = response.User;
        
            var role = user.Role?.Trim() ?? string. Empty;

            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    user.Name),

                new Claim(
                    ClaimTypes.Email,
                    user.Email),

                new Claim(
                    ClaimTypes.Role,
                    role)
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            
            
            Console.WriteLine($"LOGIN USER: {user.Name}");
            Console.WriteLine($"LOGIN ROLE: [{user.Role}]");
            if (role.Equals(
                    "admin",
                    StringComparison.OrdinalIgnoreCase))
            {
                return Results.Redirect("/admin/index");
            }

            return Results.Redirect("/");
        })
    .DisableAntiforgery();


// ==========================================
// LOGOUT ENDPOINT
// ==========================================

app.MapPost(
    "/auth/logout",
    async (HttpContext httpContext) =>
    {
        await httpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return Results.Redirect("/Login");
    });


// ==========================================
// BLAZOR
// ==========================================

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();