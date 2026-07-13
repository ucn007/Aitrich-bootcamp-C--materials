namespace BanckScheme.Scheme.Bank_Scheme;

public class SavingsAccount: BankScheme
{
    public Double Balance { get; set; }
    public int WithdrawLimit { get; set; }
    
    public SavingsAccount(
        string schemeName,
        float interestRate, 
        int withdrawLimit,
        double minimumBalance)
        : base(schemeName, interestRate, minimumBalance)
    {
        Balance =0;
        WithdrawLimit = withdrawLimit;
    }
    public override double CalculateMaturityAmount(double amount)
    {
        // Savings accounts don't have a maturity amount.
        return amount;
    }
    
    public override double CalculateInterest(double balance)
    {
        if (balance >= MinimumBalance)
        {
            return balance * (InterestRate / 100);
        }
        else
        {
            Console.WriteLine("Minimum balance not maintained.");
            return 0;
        }
       
    }
}