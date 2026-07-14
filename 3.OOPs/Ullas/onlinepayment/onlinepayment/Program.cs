namespace MyNamespace
{
  
    public class Program
    {
        public static void Main(string[] args)
        {
            double paymentAmount = 15000;
            Ipayment paymentMethod = null;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== PAYMENT GATEWAY MENU ===");
                Console.WriteLine($"Total Amount Due: ${paymentAmount:F2}");
                Console.WriteLine("1. Credit Card");
                Console.WriteLine("2. Debit Card");
                Console.WriteLine("3. UPI Payment");
                Console.WriteLine("4. Cancel Transaction");
                Console.Write("Select your payment method (1-4): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    {
                        paymentMethod = new CreditCardPayment();
                        break;
                    }
                    case 2:
                    {
                        paymentMethod = new debitCardPayment();
                        break;
                    }
                    case 3:
                    {
                        paymentMethod = new UpiPayment();
                        break;
                    }
                    case 4:
                    {
                        exit = true;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid selection.");
                        exit = true;
                        break;
                    }
                }
                if (paymentMethod != null)
                {
                    paymentMethod.paymentProcess(paymentAmount);
                    exit = true; // Ends loop after a successful payment
                }
                
            }
            Console.WriteLine("\nThank you for using our system!");
            Console.ReadKey();
        }
  
    }
};

