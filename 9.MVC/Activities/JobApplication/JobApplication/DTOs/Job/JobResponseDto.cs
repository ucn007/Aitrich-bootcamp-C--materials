namespace JobApplication.DTOs.Job;

public class JobResponseDto
{
    public Guid JobId { get; set; }

    public string JobTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Experience { get; set; }

    public Guid CompId { get; set; }

    public string JobType { get; set; } = null!;

 
    public DateTime CreatedAt { get; set; }
}