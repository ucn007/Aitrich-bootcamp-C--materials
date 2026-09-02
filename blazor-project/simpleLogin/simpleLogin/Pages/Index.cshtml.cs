using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using simpleLogin.Models;

namespace simpleLogin.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnPost()
    {
        var user = _context.Users
            .SingleOrDefault(u =>
                u.UserName == Username &&
                u.Password == Password);

        if (user == null)
        {
            ModelState.AddModelError(
                string.Empty,
                "Invalid username or password"
            );

            return Page();
        }

        HttpContext.Session.SetString("User", user.UserName);

        return RedirectToPage("/Profile");
    }
}