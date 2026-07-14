namespace MyNamespace
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Recharge Plan");
            Console.WriteLine("1. 199");
            Console.WriteLine("2. 299");
            Console.WriteLine("3. 399");
            Console.WriteLine("\n");
            Console.WriteLine("Enter your choice");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                {
                    Console.WriteLine("your selected plan is 199");
                    break;
                } 
                case 2:
                {
                    Console.WriteLine("your selected plan is 299");
                    break;
                } 
                case 3:
                {
                    Console.WriteLine("your selected plan is 399");
                    break;
                }
                default:
                {
                    Console.WriteLine("Please select a valid option");
                    break;
                }
            }
        }
    }
};

