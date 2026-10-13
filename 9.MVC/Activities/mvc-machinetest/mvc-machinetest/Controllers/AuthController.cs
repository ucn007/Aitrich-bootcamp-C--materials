using Microsoft.AspNetCore.Mvc;
using mvc_machinetest.DTOs.Admin;
using mvc_machinetest.Interfaces;

namespace mvc_machinetest.Controllers;

public class AuthController : Controller
{
    private readonly IAdminService _adminService;
 
    public AuthController(IAdminService adminService)
    {
        _adminService = adminService;
    }

// GET: /Auth/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

// POST: /Auth/Login
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _adminService.LoginAsync(dto);

        if (result == null)
        {
            ModelState.AddModelError(
                "",
                "Invalid email or password."
            );

            return View(dto);
        }

        // Store JWT in cookie
        Response.Cookies.Append(
            "jwt",
            result.Token,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.UtcNow.AddHours(2)
            }
        );

        return RedirectToAction("Index", "Home");
    }


// GET: /Auth/Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

// POST: /Auth/Register
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        try
        {
            await _adminService.RegisterAsync(dto);

            return RedirectToAction("Login");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);

            return View(dto);
        }
    }


// GET: /Auth/Logout
    [HttpGet]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");

        return RedirectToAction("Login");
    }
   

}