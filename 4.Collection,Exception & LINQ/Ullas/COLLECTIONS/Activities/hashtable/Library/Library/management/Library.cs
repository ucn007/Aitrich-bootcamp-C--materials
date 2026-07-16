using System.Collections;

namespace Library.management;

public class Library
{
    Hashtable libraryBooks = new Hashtable();

    public void addBook(string id, string title)
    {
        libraryBooks.Add(id, title);
        Console.WriteLine("Entry Created for " + title);
    }
    public void DisplayBooks()
    {
        foreach (DictionaryEntry entry in libraryBooks)
        {
           Console.WriteLine("*" + entry.Key + ": " + entry.Value + "\n"); 
        }
    }

    public void removeBook(string id)
    {
        if (libraryBooks.ContainsKey(id))
        {
            Console.WriteLine("Removing Book with Id: " + id);
            libraryBooks.Remove(id);
        }
        else
        {
            Console.WriteLine("Book with id " + id + " does not exist");
        }
       
    }

    public void removeBookName(string name)
    {

        if (libraryBooks.Contains(name))
        {
            Console.WriteLine("Removing Book " + name);
            libraryBooks.Remove(name);
        }
        else
        {
            Console.WriteLine("Book " + name + " does not exist");
        }
    }
    public void SearchBook(string title)
    {
        Console.WriteLine("Searching for Book with Title: " + title);
        if (libraryBooks.Contains(title))
        {
          Console.WriteLine("Found Book with Title: " + title);
        }
        else
        {
            Console.WriteLine("Book with title " + title + " does not exist");
        }
    }

    public void deleteAllBook()
    {
        Console.WriteLine("Deleting all Books");
        Console.WriteLine("1. Confirm");
        Console.WriteLine("2. Cancel");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("Deleting all" + libraryBooks.Count + " Books");
            libraryBooks.Clear();
        }
        else if (choice == 2)
        {
            Console.WriteLine("Deleting canceled");
        }
        else
        {
            Console.WriteLine("invalid choice");
        }
    
    }
} 