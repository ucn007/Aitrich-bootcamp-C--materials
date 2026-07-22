using OnlineShop.Exception;
using OnlineShop.Models;
using OnlineShop.Repository;

namespace OnlineShop.Manager;

public class OrderManager
{
    private readonly OrderRepository orders = new OrderRepository();
    private readonly Validation.Validation valid = new Validation.Validation();

    public void AddOrder()
    {
        int orderId;
        int quantity;
        decimal price;
        DateTime orderDate;

        // Order Id
        while (true)
        {
            try
            {
                Console.Write("Enter Order Id: ");

                if (!int.TryParse(Console.ReadLine(), out orderId))
                    throw new InvalidValueException("Order Id must be a number.");

                if (orderId <= 0)
                    throw new InvalidValueException("Order Id must be greater than zero.");

                break;
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Customer Name
        string customerName;
        while (true)
        {
            Console.Write("Enter Customer Name: ");
            customerName = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(customerName))
                break;

            Console.WriteLine("Customer Name cannot be empty.");
        }

        // Product Name
        string productName;
        while (true)
        {
            Console.Write("Enter Product Name: ");
            productName = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(productName))
                break;

            Console.WriteLine("Product Name cannot be empty.");
        }

        // Category
        string category;
        while (true)
        {
            Console.Write("Enter Category: ");
            category = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(category))
                break;

            Console.WriteLine("Category cannot be empty.");
        }

        // Quantity
        while (true)
        {
            try
            {
                Console.Write("Enter Quantity: ");

                if (!int.TryParse(Console.ReadLine(), out quantity))
                    throw new InvalidValueException("Quantity must be a valid number.");

                valid.QuantityCheck(quantity);

                break;
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Price
        while (true)
        {
            try
            {
                Console.Write("Enter Price: ");

                if (!decimal.TryParse(Console.ReadLine(), out price))
                    throw new InvalidValueException("Price must be a valid number.");

                valid.PriceCheck(price);

                break;
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Order Date
        while (true)
        {
            try
            {
                Console.Write("Enter Order Date (yyyy-MM-dd): ");

                if (!DateTime.TryParse(Console.ReadLine(), out orderDate))
                    throw new InvalidDateException("Invalid date format.");

                valid.ValidateOrderDate(orderDate);

                break;
            }
            catch (InvalidDateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Order order = new Order(
            orderId,
            customerName,
            productName,
            category,
            quantity,
            price,
            orderDate
        );

        orders.PlaceOrder(order);

        Console.WriteLine("\nOrder placed successfully.");
    }

    public void GetOrders()
    {
        orders.DisplayAllOrders();
    }

    public void SearchByName()
    {
        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine() ?? "";

        orders.SearchCustomerOrders(customerName);
    }

    public void Revenues()
    {
        orders.CalculateRevenue();
    }

    public void TopOrders()
    {
        orders.TopFiveExpensiveOrders();
    }

    public void FilterByCategory()
    {
        Console.Write("Enter Category: ");
        string category = Console.ReadLine() ?? "";

        orders.FilterByCategory(category);
    }

    public void DeleteOrder()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter Order Id: ");

                if (!int.TryParse(Console.ReadLine(), out int orderId))
                    throw new InvalidValueException("Order Id must be a valid number.");

                orders.DeleteOrder(orderId);
                break;
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}