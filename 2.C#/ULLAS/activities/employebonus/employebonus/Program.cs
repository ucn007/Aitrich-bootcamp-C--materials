namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter your experience:");
            int experience = int.Parse(Console.ReadLine());
            if (experience >= 5)
            {
                Console.WriteLine("You are eligible for bonus!");
            }
            else
            {
                int pending =  5 - experience;
                Console.WriteLine("You are not eligible for bonus "+ pending +" years more need to eligible  ");
            }
        }
    }
};

