using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercise.Pages.Admin.Destinations;

public class IndexModel : PageModel
{
    public List<DestinationViewModel> Destinations { get; set; } = new();

    public void OnGet()
    {
        Destinations = new List<DestinationViewModel>
        {
            new()
            {
                Id = 1,
                Name = "Goa",
                City = "Goa",
                ImagePath = "https://images.unsplash.com/photo-1512343879784-a960bf40e7f2"
            },
            new()
            {
                Id = 2,
                Name = "Munnar",
                City = "Kerala",
                ImagePath = "https://images.unsplash.com/photo-1593693397690-362cb9666fc2"
            },
            new()
            {
                Id = 3,
                Name = "Manali",
                City = "Himachal Pradesh",
                ImagePath = "https://images.unsplash.com/photo-1518005020951-eccb494ad742"
            },
            new()
            {
                Id = 4,
                Name = "Jaipur",
                City = "Rajasthan",
                ImagePath = "https://images.unsplash.com/photo-1477587458883-47145ed94245"
            },
            new()
            {
                Id = 5,
                Name = "Maldives",
                City = "Maldives",
                ImagePath = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e"
            },
            new()
            {
                Id = 6,
                Name = "Paris",
                City = "France",
                ImagePath = "https://images.unsplash.com/photo-1502602898657-3e91760cbb34"
            }
        };
    }
}

public class DestinationViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}