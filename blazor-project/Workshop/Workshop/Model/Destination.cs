using System.ComponentModel.DataAnnotations;

namespace Workshop.Model;

public class Destination
{
    
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    [Required]  
    public string City { get; set; }
    
    [Display(Name = "Destination Image")]
    public string? ImagePath { get; set; }
    
}