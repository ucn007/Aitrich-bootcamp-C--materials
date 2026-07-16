using Librarybooks.Manage;
using Librarybooks.Models;

namespace  Librarybooks
{
    class Program
    {
        static void Main(string[] args)
        {
            BookManage manage = new BookManage();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Library Management");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Delete Book");
                Console.WriteLine("3. Display Books");
                Console.WriteLine("4. Exit");
                
                Console.WriteLine("\n\n Enter your Choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                    {
                        Console.Write("Enter Book ID: ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        
                        Books book = new Books(bookId, title);
                        manage.AddBook(book);
                        
                       break; 
                    }
                    case 2:
                    {
                      Console.WriteLine("Enter title:");
                      string title = Console.ReadLine();
                      manage.RemoveBook(title);
                      break;
                        
                    }
                    case 3:
                    {
                        manage.DisplayBooks();
                        break;
                    }
                    case 4:
                    {
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid Input");
                        break;
                    }
                }
                
                
            }
        }
    }
}