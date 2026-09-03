using System.ComponentModel.DataAnnotations;

namespace machinetest.Dtos;

public class BookCreateDto
{
    public int id { get; set; }
    
    [Required]
    public string title { get; set; } = string.Empty;

    [Required]
    public string author { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int quantity { get; set; }
}