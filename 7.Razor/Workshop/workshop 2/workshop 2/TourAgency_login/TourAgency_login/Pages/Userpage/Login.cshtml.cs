using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TourConsultant_login.Dtos;
using TourConsultant_login.Interfaces;

namespace TourConsultant_login.Pages.Userpage
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserLoginDto LoginDto { get; set; } = new UserLoginDto();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userService.LoginAsync(LoginDto);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Invalid username or password.";
                return Page();
            }

            // Save user info in session
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("Role", user.Role.ToString());

            return RedirectToPage("/Userpage/Home"); // Redirect to home page after login
        }
    }
}
