namespace MyNamespace
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter your Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age <= 5)
            {
               Console.WriteLine(" Free to travel "); 
            }
            else if ( age <= 12)
            {
                Console.WriteLine(" Ticket Charge: ₹50/- ");  
            }
            else if ( age <= 59)
            {
                Console.WriteLine(" Ticket Charge: ₹100/- ");  
            }
            else if ( age >= 60)
            {
                Console.WriteLine(" Ticket Charge: ₹70/- (Senior Citizen Discount applied) ");  
            }
        }
    }
};

