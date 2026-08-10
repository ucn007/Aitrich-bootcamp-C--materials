

namespace ConsultantManagement.Model;

using ConsultantManagement.Enums;


public class Consultants
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int RegisterId { get; set; }
    public int AssignedTours { get; set; }
    public int Bookings { get; set; }
    public Status Status { get; set; }
    public DateTime JoinedDate { get; set; }



}

