using OnlineShop.Models;

namespace OnlineShop.Repository;

public class OrderRepository
{
    private List<Order> orders = new List<Order>();

    
    public void PlaceOrder(Order order)
    {
        orders.Add(order); 
    }

     
  
 
    public void SearchCustomerOrders(string customerName)
    {
        var result = orders.Where(o =>
            o.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase));

        if (!result.Any())
        {
            Console.WriteLine("No orders found.");
            return;
        }

        foreach (var order in result)
        {
            PrintOrder(order);
        }
    }

     
    public void DeleteOrder(int orderId)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);

        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        orders.Remove(order);
        Console.WriteLine("Order deleted successfully.");
    }
 
    public void CalculateRevenue()
    {
        decimal revenue = orders.Sum(o => o.Price * o.Quantity);

        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Total Revenue : ₹{revenue}");
        Console.WriteLine("--------------------------------");
    }

    
    public void TopFiveExpensiveOrders()
    {
        var result = orders
            .OrderByDescending(o => o.Price * o.Quantity)
            .Take(5);

        Console.WriteLine("-------- Top 5 Expensive Orders --------");

        foreach (var order in result)
        {
            Console.WriteLine($"Order ID : {order.OrderId}");
            Console.WriteLine($"Customer : {order.CustomerName}");
            Console.WriteLine($"Product : {order.ProductName}");
            Console.WriteLine($"Total Amount : ₹{order.Price * order.Quantity}");
            Console.WriteLine("--------------------------------");
        }
    }

     
    public void FilterByCategory(string category)
    {
        var result = orders.Where(o =>
            o.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

        if (!result.Any())
        {
            Console.WriteLine("No orders found.");
            return;
        }

        Console.WriteLine($"-------- {category} Orders --------");

        foreach (var order in result)
        {
            PrintOrder(order);
        }
    }

    
    
    public void DisplayAllOrders()
    {
        if (!orders.Any())
        {
            Console.WriteLine("No orders available.");
            return;
        }

        foreach (var order in orders)
        {
            PrintOrder(order);
        }
    }

  
    private void PrintOrder(Order order)
    {
        Console.WriteLine($"Order ID     : {order.OrderId}");
        Console.WriteLine($"Customer     : {order.CustomerName}");
        Console.WriteLine($"Product      : {order.ProductName}");
        Console.WriteLine($"Category     : {order.Category}");
        Console.WriteLine($"Price        : ₹{order.Price}");
        Console.WriteLine($"Quantity     : {order.Quantity}");
        Console.WriteLine($"Total        : ₹{order.Price * order.Quantity}");
        Console.WriteLine($"Order Date   : {order.OrderDate}");
        Console.WriteLine("--------------------------------");
    }
}