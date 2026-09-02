namespace WebApplication2.Models;

public class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; } 
    
    public int DepartmentId { get; set; }

    
    public Department? Department { get; set; }
}