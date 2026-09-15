using System;
using System.Collections.Generic;

namespace machinetest.Model;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string Department { get; set; } = null!;

    public int? ConsultationFee { get; set; }

    public string? Available { get; set; }

    public virtual ICollection<Appoinment> Appoinments { get; set; } = new List<Appoinment>();
}
