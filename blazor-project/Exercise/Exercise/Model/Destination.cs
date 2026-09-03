using System.ComponentModel.DataAnnotations;

namespace Exercise.Model;

public class Destination
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string city { get; set; }
    [Required]
    public string state { get; set; }
    
    [Display(Name = "Destination Image")]
    public string? ImagePath { get; set; }
    
}