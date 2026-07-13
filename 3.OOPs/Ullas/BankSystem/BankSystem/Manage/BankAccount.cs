public abstract class BankAccount
{
    private int _accountNumber;
    private string _customerName;
    private double _balance;

    public int AccountNumber
    {
        get => _accountNumber;
        set => _accountNumber = value;
    }

    public string CustomerName
    {
        get => _customerName;
        set => _customerName = value;
    }

    public double Balance
    {
        get => _balance;
        set
        {
            if (value >= 0)
                _balance = value;
            else
                Console.WriteLine("Balance cannot be negative.");
        }
    }

    public abstract double CalculateInterest();

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Account Number : {AccountNumber}");
        Console.WriteLine($"Customer Name  : {CustomerName}");
        Console.WriteLine($"Balance        : {Balance}");
    }
}