using ConsultantManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConsultantManagement.Pages
{
    public class LoginModel : PageModel
    {
        private readonly RegisterService _service;
        public LoginModel(RegisterService service)
        {
            _service = service;
        }
        [BindProperty]

        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var register = await _service.GetByUsernameAndPasswordAsync(Username, Password);

            if (register == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return Page();
            }
            HttpContext.Session.SetInt32("RegisterId", register.Id);
            HttpContext.Session.SetString("Register", Username);
            return RedirectToPage("/Consultantt/Index");
        }
    }
}
