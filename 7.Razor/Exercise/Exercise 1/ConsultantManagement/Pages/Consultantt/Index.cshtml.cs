using ConsultantManagement.Model;
using ConsultantManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace ConsultantManagement.Pages.Consultantt
{
    public class IndexModel : PageModel
    {
        private readonly ConsultantService _service;
        public IndexModel(ConsultantService service)
        {
            _service = service;
        }
        public int TotalConsultants { get; set; }
        public List<Consultants> ConsultantInfo { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var registerId = HttpContext.Session.GetInt32("RegisterId");
            if (registerId == null)
                return RedirectToPage("/Login");

            ConsultantInfo = await _service.GetAllConsultantAsync(registerId.Value);
            TotalConsultants = await _service.GetTotalConsultantsByUserAsync(registerId.Value);
            return Page();
           
        }
    }
}
