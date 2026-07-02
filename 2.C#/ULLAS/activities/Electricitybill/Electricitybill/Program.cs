namespace Electricitybill
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter Total Units");
            int units = int.Parse(Console.ReadLine());

            if (units <= 100)
            {
                int billamt = units * 2;
                Console.WriteLine("Billamount: " + billamt);
            }
            else if (units <= 200)
            {
                int billamt = units * 3;
                Console.WriteLine("Billamount: " + billamt);
            }
            else if (units > 200)
            {
                int billamt = units * 5;
                Console.WriteLine("Billamount: " + billamt);
            }
            
        }
    }
};

