using machinetest.Model;

namespace machinetest.DTOs;

public class AppointmentDto
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public string? PatientName { get; set; }

    public int DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public DateOnly? AppointmentDate { get; set; }

    public TimeOnly? AppoinmentTime { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}