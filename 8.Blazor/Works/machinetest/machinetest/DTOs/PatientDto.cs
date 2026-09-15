namespace machinetest.DTOs;

public class PatientDto
{
    public int Id { get; set; }
    public string PatientName { get; set; } = null!;

    public int Phone { get; set; }

    public string Email { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? Dob { get; set; }

   
}