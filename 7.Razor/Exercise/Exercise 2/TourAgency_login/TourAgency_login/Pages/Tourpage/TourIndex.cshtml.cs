using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;

namespace TourConsultant_login.Pages.Tourpage
{
    public class IndexModel : PageModel
    {
        private readonly ITourService _tourService;

        public IndexModel(ITourService tourService)
        {
            _tourService = tourService;
        }

        public List<Tour> Tours { get; set; } = new();

        public async Task OnGetAsync()
        {
            Tours = await _tourService.GetAllTours();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _tourService.DeleteTour(id);
            return RedirectToPage();
        }
    }
}
