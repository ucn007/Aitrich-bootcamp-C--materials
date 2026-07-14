namespace MyNamespace;

public interface Ipayment
{
    void paymentProcess(double amount);
}

public class CreditCardPayment: Ipayment
{
    public void paymentProcess(double amount)
    {
        Console.WriteLine($"\nProcessing Credit Card payment of {amount:F2}...");
        Console.WriteLine("Authentication successful! Credit Card charged successfully.");
    }
}

public class debitCardPayment: Ipayment
{
    public void paymentProcess(double amount)
    {
        Console.WriteLine($"\nProcessing Debit Card payment of {amount:F2}...");
        Console.WriteLine("Authentication successful! Debit Card charged successfully.");
    }
}

public class UpiPayment: Ipayment
{
    public void paymentProcess(double amount)
    {
        Console.WriteLine($"\nProcessing Debit Card payment of {amount:F2}...");
        Console.WriteLine("Authentication successful! Upi charged successfully.");
    }
}