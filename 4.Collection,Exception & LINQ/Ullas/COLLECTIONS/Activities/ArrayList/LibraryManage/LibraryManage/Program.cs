using LibraryManage.model;

namespace  LibraryManage;
public class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("========================== Library Management ==========================");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Show Books");
            Console.WriteLine("4. Remove Book by Index"); 
            Console.WriteLine("5. Sort");
            Console.WriteLine("6. Exit");
            Console.WriteLine("===========================================");
            
            Console.Write("\nEnter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    Console.Write("Enter Book name: ");
                    string name = Console.ReadLine();
                    library.addBook(name);
                    Console.Write(name + " added \n");
                    break;
                }
                case 2:
                {
                    Console.Write("Enter Book name: ");
                    string name = Console.ReadLine();
                    Console.Write(name + " Removed \n");
                    library.removeBook(name);
                    break;
                }
                case 3:
                {
                    library.DisplayBooks();
                    break;
                }
                case 4:
                {
                    Console.Write("Enter Book Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    library.removeIndexBook(id);
                    break;
                }
                case 5:
                {
                    library.sortBooks();
                    Console.WriteLine("Sorted books");
                    library.DisplayBooks();
                    Console.WriteLine("\n");
                    break;
                }
                case 6:
                {
                    exit = true;
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid choice");
                    break;
                }
            }
            
        }
    }
}