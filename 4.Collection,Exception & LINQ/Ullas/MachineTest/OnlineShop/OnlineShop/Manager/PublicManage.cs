namespace OnlineShop.Manager;

public class PublicManage
{
    OrderManager orders = new OrderManager();
    bool exit = false;
    
    public void ShowMenu()
    {
        while (!exit)
        {
            Console.WriteLine("-------------- Online Shop --------------");
            Console.WriteLine("1. Place Order");
            Console.WriteLine("2. View Order");
            Console.WriteLine("3. Search Orders By Customer");
            Console.WriteLine("4. Search Orders By Category");
            Console.WriteLine("5. Display Top 5 Expenssive Orders");
            Console.WriteLine("6. Delete Order");
            Console.WriteLine("7. Exit");
        
            Console.WriteLine("\nEnter your choice:");
        
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    orders.AddOrder();
                    break;
                }
                case 2:
                {
                    orders.GetOrders();
                    break;
                }
                case 3:
                {
                    orders.SearchByName();
                    break;
                }
                case 4:
                {
                    orders.FilterByCategory();
                    break;
                }
                case 5:
                {
                    orders.TopOrders();
                    break;
                }
                case 6:
                {
                    orders.DeleteOrder();
                    break;
                }
                case 7:
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