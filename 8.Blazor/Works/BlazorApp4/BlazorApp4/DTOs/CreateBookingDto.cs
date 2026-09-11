namespace BlazorApp4.DTOs;

public class CreateBookingDto
{
    // User
    
    public int UserId { get; set; }
    public string PhoneNumber { get; set; } = string.Empty; 
    
    // Tour
    
    public int TourId { get; set; }
    
    // Booking details
    public DateTime TravelDate { get; set; }
    public int NumberOfPeople { get; set; }
}