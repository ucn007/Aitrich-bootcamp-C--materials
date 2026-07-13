namespace LibrarySystem.LibraryItem;

public class Magazine: LibraryItems
{
    public int issueNo { get; set; } 
    public int dueDate { get; set; }
    
    public Magazine( int ItemId, string Title , int issueNo, int dueDate): base(ItemId, Title)
    {
        this.issueNo = issueNo;
    }
    
    
    public override void Borrow(string userId)
    {
        Console.WriteLine("Magazine can be borrowed for 7 days.");

        base.Borrow(userId);  
    }

    public override void Borrow(string userId, DateTime dueDate)
    {
        Console.WriteLine($"Magazine borrowed until {dueDate:d}");

        base.Borrow(userId, dueDate);
    }
    
    
    public override void DisplayDetails()
    {
        Console.WriteLine($"Magazine Id: {ItemId}");
        Console.WriteLine($"Magazine: {Title}");
        Console.WriteLine($"Issue Number: {issueNo}");
    }
}