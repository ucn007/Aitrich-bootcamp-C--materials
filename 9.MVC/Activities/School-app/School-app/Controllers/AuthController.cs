using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_app.Data;
using School_app.DTOs;
using School_app.DTOs.User;
using School_app.Services.Interface;

namespace School_app.Controllers;

public class AuthController : Controller
{
    private readonly MyDbContext _dbContext;
    private readonly IUserService _userService;

    public AuthController(
        MyDbContext dbContext,
        IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    [HttpGet("/")]
    [HttpGet("/Login")]
    public IActionResult Login()
    {
        return View();
    }

[HttpPost("/Login")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Login(LoginDto dto)
{
    if (!ModelState.IsValid)
    {
        return View(dto);
    }

    var user = await _dbContext.Users
        .FirstOrDefaultAsync(x => x.Email == dto.Email);

    if (user == null)
    {
        ModelState.AddModelError(
            "",
            "Invalid email or password."
        );

        return View(dto);
    }

    if (!user.IsActive)
    {
        ModelState.AddModelError(
            "",
            "Your account is inactive."
        );

        return View(dto);
    }

    if (!BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash))
    {
        ModelState.AddModelError(
            "",
            "Invalid email or password."
        );

        return View(dto);
    }

    if (string.IsNullOrWhiteSpace(user.Role))
    {
        ModelState.AddModelError(
            "",
            "User role is not configured."
        );

        return View(dto);
    }

    var claims = new List<Claim>
    {
        new Claim(
            ClaimTypes.NameIdentifier,
            user.Id.ToString()
        ),

        new Claim(
            ClaimTypes.Name,
            user.Name
        ),

        new Claim(
            ClaimTypes.Email,
            user.Email
        ),

        new Claim(
            ClaimTypes.Role,
            user.Role
        )
    };

    var identity = new ClaimsIdentity(
        claims,
        CookieAuthenticationDefaults.AuthenticationScheme
    );

    var principal = new ClaimsPrincipal(identity);

    await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        principal
    );

    if (user.Role.Equals(
            "admin",
            StringComparison.OrdinalIgnoreCase))
    {
        return RedirectToAction("Index", "Admin");
    }

    if (user.Role.Equals(
            "student",
            StringComparison.OrdinalIgnoreCase))
    {
        return RedirectToAction("Index", "Student");
    }

    ModelState.AddModelError(
        "",
        "Invalid user role."
    );

    return View(dto);
}

    [HttpGet("/Register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("/Register")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _userService.RegisterAsync(dto);

        if (result == null)
        {
            ModelState.AddModelError(
                "Email",
                "An account with this email already exists."
            );

            return View(dto);
        }

        return RedirectToAction(
            "Login",
            "Auth"
        );
    }
    
    
    [HttpGet("/TestAuth")]
    public IActionResult TestAuth()
    {
        var isAuthenticated = User.Identity?.IsAuthenticated ?? false;

        var name = User.Identity?.Name ?? "NO NAME";

        var role = User.FindFirst(ClaimTypes.Role)?.Value ?? "NO ROLE";

        return Content(
            $"Authenticated: {isAuthenticated}\n" +
            $"Name: {name}\n" +
            $"Role: {role}"
        );
    }
}