namespace MyNamespace
{
    class Program
    {
        enum OrderStatus
        {
            Pending,
            Shipped,
            Delivered,
            Cancelled
        }

        struct Order
        {
            public int Id;
            public string CustomerName;
            public OrderStatus Status;
        }

        static Order[] orders =
        {
            new Order
            {
                Id = 101,
                CustomerName = "Ullas",
                Status = OrderStatus.Pending
            },

            new Order
            {
                Id = 102,
                CustomerName = "Rahul",
                Status = OrderStatus.Shipped
            },

            new Order
            {
                Id = 103,
                CustomerName = "Anu",
                Status = OrderStatus.Delivered
            },
            new Order
            {
            Id = 104,
            CustomerName = "Anu",
            Status = OrderStatus.Delivered
            },
            new Order
            {
            Id = 105,
            CustomerName = "Anu",
            Status = OrderStatus.Delivered
            }
        };

        static void Main(string[] args)
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"ID: {order.Id}");
                Console.WriteLine($"Customer: {order.CustomerName}");
                Console.WriteLine($"Status: {order.Status}");

                if (order.Status == OrderStatus.Delivered)
                {
                    Console.WriteLine("Message: Order successfully delivered");
                }
                Console.WriteLine();
            }
        }
        
    }
};

