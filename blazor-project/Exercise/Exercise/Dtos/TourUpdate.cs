using System.ComponentModel.DataAnnotations;

namespace Exercise.Dtos;

public class TourUpdate
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int DestinationId { get; set; }

    [Required]
    public string DestinationName { get; set; } = string.Empty;

    [Required]
    [Range(1, 365)]
    public int Days { get; set; }

    [Required]
    [Range(1, 10000)]
    public int Seats { get; set; }

    [Display(Name = "Tour Image")]
    public string? ImagePath { get; set; }
}