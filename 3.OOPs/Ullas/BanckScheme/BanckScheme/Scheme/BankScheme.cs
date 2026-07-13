namespace BanckScheme.Scheme;

public abstract class BankScheme
{
    public String SchemeName { get; set; }
    public float InterestRate { get; set; }
    public Double MinimumBalance { get; set; }

    
    public BankScheme(string schemeName, float interestRate, Double minimumBalance)
    {
        SchemeName = schemeName;
        InterestRate = interestRate;
        MinimumBalance = minimumBalance;
    }
    
   
    public abstract double CalculateInterest(double amount);
    
    
    public abstract double CalculateMaturityAmount(double amount);
    
}



