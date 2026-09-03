using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace simpleLogin.Pages;

public class ProfileModel : PageModel
{
    public string? Username { get; set; }

    public IActionResult OnGet()
    {
        Username = HttpContext.Session.GetString("User");

        if (string.IsNullOrEmpty(Username))
        {
            return RedirectToPage("/Index");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        HttpContext.Session.Clear();

        return RedirectToPage("/Index");
    }
}