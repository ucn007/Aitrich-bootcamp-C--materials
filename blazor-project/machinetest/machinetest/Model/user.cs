using System.ComponentModel.DataAnnotations;
namespace machinetest.Model;

public class user
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
    [Required]
    public string phone { get; set; }
    
    
    
}