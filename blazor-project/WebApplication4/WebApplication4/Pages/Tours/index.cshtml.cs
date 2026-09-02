using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Dtos;
using WebApplication4.Service;

namespace WebApplication4.Pages.Tours;

public class IndexModel : PageModel
{
    private readonly TourService _service;

    public List<TourDto> Tours { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? SearchItem { get; set; }

    public IndexModel(TourService service)
    {
        _service = service;
    }

    public async Task OnGetAsync()
    {
        Tours = await _service.GetAllAsync(SearchItem);
    }
}