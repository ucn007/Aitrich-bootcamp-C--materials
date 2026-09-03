namespace ConsoleApp2.Migrations;

public partial class Tour
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int Seats { get; set; }

    // Required by EF Core
    public Tour()
    {
    }

    // Used by your application when creating a new tour
    public Tour(
        string tourName,
        string tourDescription,
        string tourLocation,
        int seats)
    {
        Name = tourName;
        Description = tourDescription;
        Location = tourLocation;
        Seats = seats;
    }
}