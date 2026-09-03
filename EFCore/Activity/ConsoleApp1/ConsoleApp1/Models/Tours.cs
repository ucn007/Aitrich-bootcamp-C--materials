namespace ConsoleApp1.Models;

public class Tours
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; } 
    public string Location { get; set; }
    public int Seats { get; set; }

    public Tours(  string name, string description, string location, int seats)
    {
        
        this.Name = name;
        this.Description = description;
        this.Location = location;
        this.Seats = seats;
        
    }
}