using System.ComponentModel.DataAnnotations;

namespace JobApplication.DTOs.Job;

public class UpdateJobDto
{
    [Required]
    [StringLength(200)]
    public string JobTitle { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Range(0, 50)]
    public decimal Experience { get; set; }

    [Required]
    [StringLength(50)]
    public string JobType { get; set; } = null!;

 
}