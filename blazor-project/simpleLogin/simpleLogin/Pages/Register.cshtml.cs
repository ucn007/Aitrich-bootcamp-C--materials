using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using simpleLogin.Models;

namespace simpleLogin.Pages;

public class RegisterModel : PageModel
{
    private readonly ApplicationDbContext _context;

    [BindProperty]
    public User NewUser { get; set; } = new User();

    public RegisterModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnPost()
    {
        if (string.IsNullOrEmpty(NewUser.UserName) ||
            string.IsNullOrEmpty(NewUser.Password))
        {
            ModelState.AddModelError("", "Username and Password are required");
            return Page();
        }

        _context.Users.Add(NewUser);
        _context.SaveChanges();

        return RedirectToPage("/Index");
    }
}