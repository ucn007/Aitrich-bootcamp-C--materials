using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TourConsultant_login.Dtos;
using TourConsultant_login.Interfaces;
using TourConsultant_login.Model;
using TourConsultant_login.Repository;
using TourConsultant_login.Service;
namespace TourConsultant_login.Pages.Tourpage;

public class EditTourModel : PageModel
{
    private readonly ITourService _tourService;
    private readonly IDestinationRepository _destinationRepository;

    public EditTourModel(
        ITourService tourService,
        IDestinationRepository destinationRepository)
    {
        _tourService = tourService;
        _destinationRepository = destinationRepository;
    }

    [BindProperty]
    public TourUpdateDto Tour { get; set; }

    public SelectList DestinationList { get; set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var tour = await _tourService.GetTourById(id);

        if (tour == null)
            return NotFound();

        Tour = tour;

        var destinations = await _destinationRepository.GetAllDestinationAsync();

        DestinationList = new SelectList(
            destinations,
            "Id",
            "DestinationName",
            Tour.DestinationId  // selected value
        );

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var destinations = await _destinationRepository.GetAllDestinationAsync();
            DestinationList = new SelectList(destinations, "Id", "DestinationName");
            return Page();
        }

        await _tourService.UpdateTour(Tour.Id, Tour);

        return RedirectToPage("TourIndex");
    }
}
