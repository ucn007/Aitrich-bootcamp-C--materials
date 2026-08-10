using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using TravelsDb.DTO;
using TravelsDb.Interfaces;
using TravelsDb.Models;
using TravelsDb.Helper;
using TravelsDb.Services;

namespace TravelsDb.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public readonly IUserServices userServices;
        public RegisterModel(IUserServices userServices)
        {
            this.userServices = userServices;
        }


        [BindProperty]
        public User? user { get; set; }

        public IActionResult onGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Check if email already exists
            if (await userServices.EmailExistsAsync(user.Email))
            {
                ModelState.AddModelError(string.Empty, "Email is already registered.");
                return Page();
            }
            // Set default role to User
            await userServices.RegisterAsync(new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Role = Role.User
            });
            return RedirectToPage("/Account/Login");
        }
    }
}
