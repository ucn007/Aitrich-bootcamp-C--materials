using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_machinetest.Models;

public partial class Department
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Department name is required")]
    [StringLength(255, ErrorMessage = "Department name cannot exceed 255 characters")]
    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
