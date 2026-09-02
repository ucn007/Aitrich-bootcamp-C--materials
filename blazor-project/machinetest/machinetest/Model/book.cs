using System.ComponentModel.DataAnnotations;

namespace machinetest.Model;

public class book
{
    [Key]
    public int id { get; set; }
    [Required]
    public string title { get; set; }
    [Required]
    public string author { get; set; }
    [Required]
    public int quantity { get; set; }
    
}