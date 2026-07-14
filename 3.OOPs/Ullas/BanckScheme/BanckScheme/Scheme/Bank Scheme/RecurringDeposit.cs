namespace BanckScheme.Scheme.Bank_Scheme;

public class RecurringDeposit: BankScheme
{
    public int MonthlyInstallment { get; set; }
    public int Tenure { get; set; }
    public float InterestRate { get; set; }

    public RecurringDeposit(string schemeName, float interestRate, int tenure, int monthlyInstallment,
        double minimumBalance) : base(schemeName, interestRate, minimumBalance)
    {
        MonthlyInstallment = monthlyInstallment;
        Tenure = tenure;
        InterestRate = interestRate;
        
    }

    public override double CalculateInterest(double MonthlyInstallment)
    {
        double total = MonthlyInstallment * Tenure;

        return total + (total * InterestRate / 100);
         
        
    }
    
    public override double CalculateMaturityAmount(double monthlyInstallment)
    {
        double total = monthlyInstallment * Tenure;
        return total + (total * InterestRate / 100);
    }
}