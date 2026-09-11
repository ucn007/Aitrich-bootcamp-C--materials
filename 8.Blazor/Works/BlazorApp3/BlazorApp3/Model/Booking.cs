namespace BlazorApp3.Model;

public class Booking
{
    public int Id { get; set; } 
    // User who made the booking
    public int UserId { get; set; } 
    public string UserName { get; set; } = string.Empty; 
    public string UserEmail { get; set; } = string.Empty; 
    public string PhoneNumber { get; set; } = string.Empty; 
    // Tour being booked
    public int TourId { get; set; } 
    public string TourName { get; set; } = string.Empty; 
    
    // Booking details
    public DateTime BookingDate { get; set; } = DateTime.UtcNow; 
    public DateTime TravelDate { get; set; } 
    public int NumberOfPeople { get; set; } 
    public decimal TotalAmount { get; set; } 
    public string Status { get; set; } = "Pending";
    
    
}