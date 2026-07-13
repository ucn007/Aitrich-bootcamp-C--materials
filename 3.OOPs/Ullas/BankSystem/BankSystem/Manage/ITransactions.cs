namespace BankSystem.Manage;

public interface ITransactions
{
 
    void Deposit(double amount);
    void Withdraw(double amount);

}