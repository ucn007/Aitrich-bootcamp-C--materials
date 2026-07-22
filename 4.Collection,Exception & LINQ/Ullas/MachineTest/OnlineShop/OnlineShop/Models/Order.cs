namespace OnlineShop.Models;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(int orderId, string customerName, string productName, string category, int quantity, decimal price,
        DateTime orderDate)
    {
        OrderId = orderId;
        CustomerName = customerName;
        ProductName = productName;
        Category = category;
        Quantity = quantity;
        Price = price;
        OrderDate = orderDate;
    }
    
}