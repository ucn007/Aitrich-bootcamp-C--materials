using JobApplication.DTOs;
using JobApplication.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
        {
            return View(loginDto);
        }

        var result = await _authService.LoginAsync(loginDto);

        if (result == null)
        {
            ModelState.AddModelError(
                "",
                "Invalid email or password."
            );

            return View(loginDto);
        }

        // Store JWT in cookie
        Response.Cookies.Append(
            "jwt",
            result.Token,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddMinutes(60)
            }
        );

        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    [HttpPost]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");

        return RedirectToAction("Login", "Auth");
    }
}