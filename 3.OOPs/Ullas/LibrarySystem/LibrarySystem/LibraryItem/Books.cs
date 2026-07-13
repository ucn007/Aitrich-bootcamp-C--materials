namespace LibrarySystem.LibraryItem;

public class Books: LibraryItems
{
    public string Author { get; set; }
    public int DueDate { get; set; } 
    
    
    public Books ( int ItemId, string Title, string author, int dueDate): base( ItemId, Title)
    {
        Author = author;
        DueDate = dueDate;
    }

    public override void Borrow(string userId)
    {
        Console.WriteLine("Book can be borrowed for 14 days.");

        base.Borrow(userId);  
    }

    public override void Borrow(string userId, DateTime dueDate)
    {
        Console.WriteLine($"Book borrowed until {dueDate:d}");

        base.Borrow(userId, dueDate);
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Book Id: {ItemId}");
        Console.WriteLine($"Book: {Title}");
        Console.WriteLine($"Author: {Author}");
    }
}