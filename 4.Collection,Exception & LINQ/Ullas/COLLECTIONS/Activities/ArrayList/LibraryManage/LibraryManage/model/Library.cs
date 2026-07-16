using System.Collections;

namespace LibraryManage.model;

public class Library
{
    public ArrayList books = new ArrayList();

    public void addBook(string book)
    {
        books.Add(book);
        Console.WriteLine("Book added");
    }
    
    public void DisplayBooks()
    {
        foreach (string book in books)
        {
            Console.WriteLine(book);
            Console.WriteLine();
        }
    }

    public void removeBook(string book)
    {
        if (books.Contains(book))
        {
            books.Remove(book);
        }
        else
        {
            Console.WriteLine("Book not found");
        }
    }
    public void removeIndexBook(int index)
    {
        if (books.Contains(index))
        {
            books.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Book not found");
        }
       
    }
    
    public void sortBooks()
    {
        books.Sort();
    }
    
}