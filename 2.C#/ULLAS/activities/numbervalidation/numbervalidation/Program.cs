namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            int number;
            
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine("number is even");
                }
                else
                {
                    Console.WriteLine("number is odd");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
        }
    }
};

