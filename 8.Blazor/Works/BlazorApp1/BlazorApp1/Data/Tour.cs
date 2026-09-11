namespace BlazorApp1.Data;

public class Tour
{
    public int Id { get; set; }
    public string Destination { get; set; }
    public decimal Price { get; set; }
    public int AvailableSlots { get; set; }
    
    public Tour() { }
 
    public Tour(int id, string destination, decimal price, int availableSlots)
    {
        Id = id;
        Destination = destination;
        Price = price;
        AvailableSlots = availableSlots;
    }
}