using LibrarySystem.LibraryItem;

namespace LibrarySystem.Manage;

public class LibraryManager
{
    LibraryItems[] libraryItems = new LibraryItems[20];
    int itemcount = 0;

    public void addItem()
    {
        Console.WriteLine("Enter Item Type");
        Console.WriteLine("1. Book");
        Console.WriteLine("2. Magazine");
        Console.WriteLine("3. Dvd");
        Console.WriteLine("Enter your Choice");
        
        int choice = int.Parse(Console.ReadLine());
        
        if (choice > 3)
        {
            Console.WriteLine("Invalid Choice");
        }
        else 
        {
            
            if (choice == 1)
            {
                Console.WriteLine(" Enter Book ID");
                int itemId = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter Book Name");
                string itemName = Console.ReadLine();
                Console.WriteLine(" Enter Author Name:");
                string authorName = Console.ReadLine();
                int dueDate = 14;
                libraryItems[itemcount++] = new Books(itemId, itemName, authorName,dueDate);
                Console.WriteLine(" Book Added Successfully");
            }
            else if (choice == 2)
            {
                Console.WriteLine(" Enter Magazine ID");
                int itemId = int.Parse(Console.ReadLine()) ;
                Console.WriteLine(" Enter Magazine Name");
                string itemName = Console.ReadLine();
                Console.WriteLine(" Enter Issue No:");
                int issueNo = int.Parse(Console.ReadLine());
                int dueDate = 7;
                libraryItems[itemcount++] = new Magazine(itemId, itemName, issueNo,dueDate);
                Console.WriteLine(" Magazine Added Successfully");
            }
            else if (choice == 3)
            {
                Console.WriteLine(" Enter DVD ID");
                int itemId = int.Parse(Console.ReadLine());
                Console.WriteLine(" Enter DVD Name");
                string itemName = Console.ReadLine();
                Console.WriteLine(" Enter Duration:"); 
                float duration = float.Parse(Console.ReadLine());
                int dueDate = 3;
                
                libraryItems[itemcount++] = new Dvd( duration,itemName, itemId, dueDate);
                Console.WriteLine(" DVD Added Successfully");
            }
            
            
        }
        
        
    }


    public void DisplayItems()
    {
        if (libraryItems == null)
        {
            Console.WriteLine("Library Items Not Found");
        }

        for (int i = 0; i < libraryItems.Length; i++)
        {
            if (libraryItems[i] != null)
            {
               libraryItems[i].DisplayDetails();
               Console.WriteLine("-------------------------------------------");
               Console.WriteLine();
            }
        }
    }

    public void BorrowItem()
    {
        Console.Write("Enter Item ID: ");
        int itemId = int.Parse(Console.ReadLine());

        for (int i = 0; i < itemcount; i++)
        {
            if (libraryItems[i].ItemId == itemId)
            {
                if (libraryItems[i].Borrowed)
                {
                    Console.WriteLine("Item is already borrowed.");
                }
                else
                {
                    Console.Write("Enter User ID: ");
                    string userId = Console.ReadLine();

                    libraryItems[i].Borrow(userId);

                    Console.WriteLine("Item borrowed successfully.");
                }

                return;
            }
        }

        Console.WriteLine("Item not found.");
    }

    public void ReturnItem()
    {
        Console.Write("Enter Item ID: ");
        int itemId = int.Parse(Console.ReadLine());
        for (int i = 0; i < itemcount; i++)
        {
            if (libraryItems[i].ItemId == itemId )
            {
                if (libraryItems[i].Borrowed == true)
                {
                    libraryItems[i].ReturnItem();
                    Console.WriteLine("Item reutned successfully.");
                }
                else
                {
                    Console.Write("Item not found. ");
                }
               
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }
}