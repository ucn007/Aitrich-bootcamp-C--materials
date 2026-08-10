using ConsultantManagement.Dto;
using ConsultantManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConsultantManagement.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly RegisterService _service;
            public RegisterModel(RegisterService service)
        { 
            _service = service;
        }
        [BindProperty]
        public RegisterDto RegisterInfo { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.AddUserAsync(RegisterInfo);
            return RedirectToPage("Login");
        }
    }
}
