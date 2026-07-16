using Librarybooks.Models;

namespace Librarybooks.Manage;

public class BookManage
{
    public List<Books> books = new List<Books>();

    public void AddBook(Books book)
    {
        books.Add(book);
        Console.WriteLine($"Added book: {book.Title}");
    }

    public void RemoveBook(String title)
    {
        Console.WriteLine("Enter book title to remove");
        string bookTitle = Console.ReadLine();
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Title == bookTitle)
            {
                books.RemoveAt(i);
                Console.WriteLine($"Removed book: {books[i].Title}");
            }
            else
            {
                Console.WriteLine($"Book named {bookTitle} not found");
            }
        }
    }

    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books found");
        }
        else
        {
            foreach (Books book in books)
            {
                book.display();
            }
        }
    }
    
}