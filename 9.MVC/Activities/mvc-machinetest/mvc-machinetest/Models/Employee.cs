using System;
using System.Collections.Generic;

namespace mvc_machinetest.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int DepartmentId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Department Department { get; set; } = null!;
}
