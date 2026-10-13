using Education.DTOs.User;
using Education.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Education.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: Account/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var user = await _userService.LoginAsync(dto);
    
        if (user == null)
        {
            ModelState.AddModelError(
                "",
                "Invalid email or password."
            );

            return View(dto);
        }
        TempData["DebugMessage"] = $"User: {user.Name}, Role: {user.Role}";
        // Store user information
        HttpContext.Session.SetString("Username", user.Name);
        HttpContext.Session.SetString("UserId", user.UserId.ToString());
        HttpContext.Session.SetString("Role", user.Role);

        // Redirect based on role
        if (user.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
        {
            return RedirectToAction("Index", "Admin");
        }

        return RedirectToAction("Index", "Home");
    }


    // GET: Account/Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    // POST: Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var result = await _userService.RegisterAsync(dto);

        if (!result)
        {
            ModelState.AddModelError(
                "Email",
                "An account with this email already exists."
            );

            return View(dto);
        }

        return RedirectToAction("Login");
    }
    
    
    
    // POST: Account/Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        // Remove all session data
        HttpContext.Session.Clear();

        // Redirect to login
        return RedirectToAction("Login", "Account");
    }
    
    
}