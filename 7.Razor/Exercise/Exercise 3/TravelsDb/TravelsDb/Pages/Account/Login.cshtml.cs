using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelsDb.Interfaces;
using TravelsDb.Models;

namespace TravelsDb.Pages.Account
{
    public class LoginModel : PageModel
    {
        public readonly IUserServices userServices;
        public LoginModel(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await userServices.LoginAsync(Email, Password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("UserRole", user.Role.ToString());

                return RedirectToPage("/Work/Index");
            }
            // Set session or cookie for logged-in user
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.UserName);
            return RedirectToPage("/Work/Index");
        }
    }
}
