namespace  Parking_Fee
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter Parking Hours:");
            float hours = float.Parse(Console.ReadLine());

            if (hours <= 2)
            {
                Console.WriteLine("Your Parking Fee is ₹20/-");
            }
            else if(hours <= 5)

            {
                Console.WriteLine("Your Parking Fee is ₹50/-");
            }
            else if(hours > 5)

            {
                Console.WriteLine("Your Parking Fee is ₹100/-");
            }
        }
    }
}