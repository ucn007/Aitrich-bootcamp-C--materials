using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TourConsultant_login.Dtos;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;
using TourConsultant_login.Service;

namespace TourConsultant_login.Pages.Tourpage
{
    public class CreateModel : PageModel
    {
        private readonly ITourService _tourService;
        private readonly IDestinationRepository _destinationRepository;

        public CreateModel(ITourService tourService, IDestinationRepository destinationRepository)
        {
            _tourService = tourService;
            _destinationRepository = destinationRepository;
        }

        [BindProperty]
        public TourRegisterDto Tour { get; set; } = new();
        public SelectList DestinationList { get; set; }
        public async Task OnGetAsync()
        {
            var destinations = await _destinationRepository.GetAllDestinationAsync();

            DestinationList = new SelectList(
    destinations,
    "Id",                 // value (IMPORTANT)
    "DestinationName"     // text
);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); // reload dropdown
                return Page();
            }

            await _tourService.CreateTour(Tour);
            return RedirectToPage("/TourPage/TourIndex");
        }
    }
}
