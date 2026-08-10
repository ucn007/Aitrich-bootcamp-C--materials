using ConsultantManagement.Model;
using ConsultantManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace ConsultantManagement.Pages.Consultantt
{
    public class DeleteModel : PageModel
    {
        private readonly ConsultantService _service;

       public DeleteModel(ConsultantService service)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var registerId = HttpContext.Session.GetInt32("RegisterId");
            if (registerId == null)
                return RedirectToPage("/Login");

            await _service.DeleteConsultantAsync(id, registerId.Value);
            return RedirectToPage("Index");
        }
       
    }
}
