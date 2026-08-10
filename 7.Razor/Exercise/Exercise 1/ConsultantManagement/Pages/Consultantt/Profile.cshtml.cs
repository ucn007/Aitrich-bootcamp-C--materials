using ConsultantManagement.Model;
using ConsultantManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConsultantManagement.Pages.Consultantt
{
    public class ProfileModel : PageModel
    {
        private readonly ConsultantService _service;

        public ProfileModel(ConsultantService service)
        {
            _service = service;
        }

        [BindProperty]
        public Consultants ConsultantInfo { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var registerId = HttpContext.Session.GetInt32("RegisterId");
            if (registerId == null)
                return RedirectToPage("/Login");

            ConsultantInfo = await _service.GetConsultantByIdAsync(id);

            return Page();
        }
    }
}
