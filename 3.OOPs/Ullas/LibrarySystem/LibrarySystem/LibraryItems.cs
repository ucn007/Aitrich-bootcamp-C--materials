namespace LibrarySystem;

public abstract class LibraryItems
{
    public int ItemId { get; set; }
    public string Title { get; set; }

 
    private bool _borrowed;
    private string _borrower;

    public bool Borrowed
    {
        get { return _borrowed; }
        set { _borrowed = value; }
    }

    public string Borrower
    {
        get { return _borrower; }
        set { _borrower = value; }
    }

    
    public LibraryItems(int itemId, string title)
    {
        ItemId = itemId;
        Title = title;
        Borrowed = false;
        Borrower = "";
    }

   
    public virtual void Borrow(string userId)
    {
        Borrowed = true;
        Borrower = userId;
    }

    public virtual void Borrow(string userId, DateTime dueDate)
    {
        Borrowed = true;
        Borrower = userId;
    }

    public virtual void ReturnItem()
    {
        Borrowed = false;
        Borrower = "";
    }

    public abstract void DisplayDetails();
}