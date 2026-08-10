using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TourConsultant_login.Dtos;
using TourConsultant_login.Interfaces;

namespace TourConsultant_login.Pages.Userpage
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserRegisterDto RegisterDto { get; set; } = new UserRegisterDto();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool success = await _userService.RegisterAsync(RegisterDto);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Username already exists.");
                return Page();
            }

            TempData["SuccessMessage"] = "Registration successful. Please login.";
            return RedirectToPage("Login");
        }
    }
}
