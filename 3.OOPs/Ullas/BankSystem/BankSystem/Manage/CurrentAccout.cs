namespace BankSystem.Manage;

public class CurrentAccount: BankAccount, ITransactions
{
    public override double CalculateInterest()
    {
        return 0;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
            Balance -= amount;
        else
            Console.WriteLine("Insufficient Balance.");
    }
}