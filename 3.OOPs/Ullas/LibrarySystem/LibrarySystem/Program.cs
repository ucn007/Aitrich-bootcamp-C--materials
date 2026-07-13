using LibrarySystem.Manage;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryManager libraryManager = new LibraryManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("============================ Library System ==============================");
                Console.WriteLine("1. Add Library Item");
                Console.WriteLine("2. Display Items");
                Console.WriteLine("3. Borrow Item");
                Console.WriteLine("4. Return");
                Console.WriteLine("5. Exit");
            
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        libraryManager.addItem();
                        break;
                    }
                    case 2:
                    {
                        libraryManager.DisplayItems();
                        break;
                    }
                    case 3:
                    {
                        libraryManager.BorrowItem();
                        break;
                    }
                    case 4:
                    {
                        libraryManager.ReturnItem();
                        break;
                    }
                    case 5:
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
}