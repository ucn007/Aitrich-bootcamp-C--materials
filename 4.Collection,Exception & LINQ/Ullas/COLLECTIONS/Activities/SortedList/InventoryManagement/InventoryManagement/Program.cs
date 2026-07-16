namespace  InventoryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            inventory.inventory inventory = new inventory.inventory();
            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to Inventory Management!");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item by Id");
                Console.WriteLine("3. Remove Item by Name");
                Console.WriteLine("4. Search Item by Id");
                Console.WriteLine("5. Search Item by Name");
                Console.WriteLine("6. Display Inventory");
                Console.WriteLine("7. Exit");
                Console.WriteLine("\nEnter Your Choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    {
                        Console.WriteLine("Enter Item ID: ");
                        int itemID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Item Name: ");
                        string itemName = Console.ReadLine();
                        inventory.addItem(itemID, itemName);
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Enter Item ID: ");
                        int itemID = Convert.ToInt32(Console.ReadLine());
                        inventory.removeItem(itemID);
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Enter Item Name: ");
                        string itemName = Console.ReadLine();
                        inventory.removeItemValue(itemName);
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Enter Item id: ");
                        int itemID = Convert.ToInt32(Console.ReadLine());
                        inventory.SearchItem(itemID);
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Enter Item Name: ");
                        string itemName = Console.ReadLine();
                        inventory.SearchItemValue(itemName);
                        break;
                    }
                    case 6:
                    {
                        Console.WriteLine("/n All Products ");
                        inventory.displayInventory();
                        break;
                    }
                    case 7:
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