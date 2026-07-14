namespace LibrarySystem.LibraryItem;

public class Dvd: LibraryItems
{
    
    public float duration { get; set; }
    public int dueDate { get; set; }

    public Dvd(float duration, string title, int itemId,int dueDate) : base(itemId, title)
    {
        this.duration = duration;
        this.Title = title;
        
    }
    
    public override void Borrow(string userId)
    {
        Console.WriteLine("Dvd can be borrowed for 7 days.");

        base.Borrow(userId);  
    }

    public override void Borrow(string userId, DateTime dueDate)
    {
        Console.WriteLine($"Dvd borrowed until {dueDate:d}");

        base.Borrow(userId, dueDate);
    }
    
    public override void DisplayDetails()
    {
        Console.WriteLine($"Dvd Id: {ItemId}");
        Console.WriteLine($"Dvd Name: {Title}");
        Console.WriteLine($"Duration: {duration}");
    }
    
}