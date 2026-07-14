namespace BanckScheme.Scheme.Bank_Scheme;

public class FixedDeposit: BankScheme
{
    public Double Deposit { get; set; }
    public int Tenure { get; set; }
    public Double MaturityAmount { get; set; }

    public FixedDeposit(string schemeName, float interestRate, double deposit, int tenure, double minimumBalance) : base(schemeName, interestRate, minimumBalance)
    {
        Deposit = deposit;
        Tenure = tenure; 
    }

    public override double CalculateInterest(double amount)
    {
        return amount * (InterestRate / 100);
    }
    
    public override double CalculateMaturityAmount(double depositAmount)
    {
        return depositAmount +
               ((depositAmount * InterestRate / 100) * Tenure);
    }
        
}