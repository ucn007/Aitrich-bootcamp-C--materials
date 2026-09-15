using System;
using System.Collections.Generic;

namespace machinetest.Model;

public partial class Patient
{
    public int Id { get; set; }

    public string PatientName { get; set; } = null!;

    public int Phone { get; set; }

    public string Email { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public virtual ICollection<Appoinment> Appoinments { get; set; } = new List<Appoinment>();
}
