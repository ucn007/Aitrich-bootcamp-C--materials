namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.Pizza");
            Console.WriteLine("2.Burger");
            Console.WriteLine("3.Juice");
            Console.WriteLine("\n Enter your choice: ");
            string food = Console.ReadLine().ToLower();

            switch (food)
            {
                case "1":
                {
                    Console.WriteLine("Pizza has been added to your cart.");
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Burger has been added to your cart.");
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Juice has been added to your cart.");
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
};

