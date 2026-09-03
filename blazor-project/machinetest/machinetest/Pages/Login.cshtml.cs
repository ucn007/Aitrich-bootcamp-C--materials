using machinetest.Interfaces;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using machinetest.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace machinetest.Pages;

public class LoginModel : PageModel
{
    private readonly IUserService _userService;

    public LoginModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    public string Password { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Admin login
        if (Email == "admin@123.com" && Password == "admin")
        {
            var adminClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Admin"),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var adminIdentity = new ClaimsIdentity(
                adminClaims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var adminPrincipal = new ClaimsPrincipal(adminIdentity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                adminPrincipal
            );

            return RedirectToPage("/Admin/Index");
        }

        // Normal user login
        var user = await _userService.LoginAsync(
            Email,
            Password
        );

        if (user == null)
        {
            ModelState.AddModelError(
                string.Empty,
                "Invalid email or password."
            );

            return Page();
        }

        var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                user.id.ToString()
            ),

            new Claim(
                ClaimTypes.Name,
                user.name
            ),

            new Claim(
                ClaimTypes.Email,
                user.email
            ),

           
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

        return RedirectToPage("/Index");
    }
}

