namespace BankSystem.Manage;

public class SavingsAccount: BankAccount, ITransactions
{
    public override double CalculateInterest()
    {
        return Balance * 0.05;
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