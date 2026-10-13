using System.ComponentModel.DataAnnotations;

namespace mvc_machinetest.DTOs.Department;

public class CreateDeptDto
{
    [Required(ErrorMessage = "Department name is required")]
    [StringLength(255, ErrorMessage = "Department name cannot exceed 255 characters")]
    public string Name { get; set; } = null!;
}