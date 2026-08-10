using ConsultantManagement.Dto;
using ConsultantManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConsultantManagement.Pages.Consultantt
{
    public class CreateModel : PageModel
    {
        private readonly ConsultantService _service;

        [BindProperty]
        public ConsultantDto ConsultantInfo { get; set; }

        public CreateModel(ConsultantService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var registerId = HttpContext.Session.GetInt32("RegisterId");
            if (registerId == null)
                return RedirectToPage("/Login");

            await _service.AddConsultantAsync(ConsultantInfo, registerId.Value);
            return RedirectToPage("Index");
        }
        
    }
}
