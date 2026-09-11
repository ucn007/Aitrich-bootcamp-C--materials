namespace BlazorApp4.Model;

public class Tour
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Destination { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int DurationDays { get; set; }
    
    public int MaxParticipants { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public bool IsAvailable { get; set; }
}