using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;

namespace TourConsultant_login.Pages.Tourpage
{
    public class DeleteModel : PageModel
    {
        private readonly ITourService _tourService;

        public DeleteModel(ITourService tourService)
        {
            _tourService = tourService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            await _tourService.DeleteTour(id);
            return RedirectToPage("Index");
        }
    }
}
