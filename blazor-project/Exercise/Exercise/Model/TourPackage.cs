using System.ComponentModel.DataAnnotations;

namespace Exercise.Model;

public class TourPackage
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int DestinationId { get; set; }

    [Required]
    public string DestinationName { get; set; } = string.Empty;

    [Required]
    public int Days { get; set; }

    [Required]
    public int Seats { get; set; }

    public string? ImagePath { get; set; }

    // Navigation property
    public Destination? Destination { get; set; }
}