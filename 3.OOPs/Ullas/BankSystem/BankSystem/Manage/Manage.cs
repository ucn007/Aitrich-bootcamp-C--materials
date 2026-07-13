namespace BankSystem.Manage;

public class BankManager
{
    private BankAccount[] accounts = new BankAccount[100];
    private int count = 0;

    public void CreateAccount()
    {
        Console.WriteLine("1. Savings Account");
        Console.WriteLine("2. Current Account");

        int choice = Convert.ToInt32(Console.ReadLine());

        BankAccount account;

        if (choice == 1)
            account = new SavingsAccount();
        else
            account = new CurrentAccount();

        Console.Write("Account Number: ");
        account.AccountNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Customer Name: ");
        account.CustomerName = Console.ReadLine();

        Console.Write("Initial Balance: ");
        account.Balance = Convert.ToDouble(Console.ReadLine());

        accounts[count++] = account;

        Console.WriteLine("Account Created Successfully.");
    }

    private BankAccount FindAccount(int accountNo)
    {
        for (int i = 0; i < count; i++)
        {
            if (accounts[i].AccountNumber == accountNo)
                return accounts[i];
        }

        return null;
    }

    public void Deposit()
    {
        Console.Write("Enter Account Number: ");
        int accNo = Convert.ToInt32(Console.ReadLine());

        BankAccount account = FindAccount(accNo);

        if (account != null)
        {
            Console.Write("Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            ((ITransactions)account).Deposit(amount);
        }
    }

    public void Withdraw()
    {
        Console.Write("Enter Account Number: ");
        int accNo = Convert.ToInt32(Console.ReadLine());

        BankAccount account = FindAccount(accNo);

        if (account != null)
        {
            Console.Write("Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            ((ITransactions)account).Withdraw(amount);
        }
    }

    public void CalculateInterest()
    {
        Console.Write("Enter Account Number: ");
        int accNo = Convert.ToInt32(Console.ReadLine());

        BankAccount account = FindAccount(accNo);

        if (account != null)
        {
            Console.WriteLine($"Interest = {account.CalculateInterest()}");
        }
    }

    public void Display()
    {
        Console.Write("Enter Account Number: ");
        int accNo = Convert.ToInt32(Console.ReadLine());

        BankAccount account = FindAccount(accNo);

        if (account != null)
            account.DisplayDetails();
    }
}