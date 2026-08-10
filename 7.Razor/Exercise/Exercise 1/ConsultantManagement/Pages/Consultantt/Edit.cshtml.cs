using ConsultantManagement.Model;
using ConsultantManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace ConsultantManagement.Pages.Consultantt
{
    public class EditModel : PageModel
    {
        private readonly ConsultantService _service;

        [BindProperty]
        public Consultants ConsultantInfo { get; set; }

        public EditModel(ConsultantService service)
        {
            _service = service;
        }

       
       
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ConsultantInfo = await _service.GetConsultantByIdAsync(id);

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.UpdateConsultantAsync(id, ConsultantInfo);
            return RedirectToPage("/Consultantt/Index");
        }
    }
}
