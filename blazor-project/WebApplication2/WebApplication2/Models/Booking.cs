namespace WebApplication2.Models;

public class Booking
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string PatientName { get; set; }
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public DateTime Date { get; set; }
    
}