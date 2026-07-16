namespace Librarybooks.Models;

public class Books
{
    public int BookId { get; set; }
    public string Title { get; set; }

    public Books(int bookId, string title)
    {
        BookId = bookId;
        Title = title;
    }

    public void display()
    {
        Console.WriteLine("****************************************\n");
        Console.WriteLine($"\nBook ID: {BookId}\n Title: {Title}\n");
        Console.WriteLine("****************************************\n");
    }
}