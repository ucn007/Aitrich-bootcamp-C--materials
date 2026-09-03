using Microsoft.AspNetCore.Mvc.RazorPages;
using Workshop.Dtos;
using Workshop.Interfaces;

namespace Workshop.Pages.Destinations;

public class IndexModel : PageModel
{
    private readonly IDestinationService _destinationService;

    public List<DestinationCreateDto> Destinations { get; set; } = new();

    public IndexModel(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public async Task OnGetAsync()
    {
        Destinations = await _destinationService.GetAllAsync();
    }
}