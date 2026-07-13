using BanckScheme.Person;
using BanckScheme.Scheme;
using BanckScheme.Scheme.Bank_Scheme;

namespace BanckScheme.ManageScheme;

public class ManageScheme
{
    public BankScheme[] scheme = new BankScheme[20];
    public Customer[] customers = new Customer[20];
    int schemeIndex = 0;

    public void AddScheme()
    {
        Console.WriteLine("Select scheme"); 
        Console.WriteLine("1. Fixed Deposit"); 
        Console.WriteLine("2. Savings Account"); 
        Console.WriteLine("3. Recurring Deposit"); 
        Console.WriteLine("\n Enter your Scheme");
        
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine("Enter Scheme Name:");
            string schemeName = Console.ReadLine();
            Console.WriteLine("Enter Interest Rate:");
            float interestRate = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Tenure:"); 
            int tenure = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter MinimumDepositAmount:");
            double minimumDepositAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Deposit:");
            double deposit = double.Parse(Console.ReadLine());
            scheme[schemeIndex++] = new FixedDeposit(schemeName, interestRate, deposit,tenure, minimumDepositAmount);
            Console.WriteLine("Scheme Created");
            
        }
        else if (choice == 2)
        {
            Console.WriteLine("Enter Scheme Name:");
            string schemeName = Console.ReadLine();
            Console.WriteLine("Enter Interest Rate:");
            float interestRate = float.Parse(Console.ReadLine());
           Console.WriteLine("Enter MinimumDepositAmount:");
            double minimumDepositAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Withdrawlimit:");
            int withdrawLimit = int.Parse(Console.ReadLine());

           
            scheme[schemeIndex++] =  new SavingsAccount(schemeName, interestRate, withdrawLimit, minimumDepositAmount);
            
        }
        
    }
  
    public void DisplaySchemes()
    {
        Console.WriteLine("Available Schemes");

        for(int i=0;i<schemeIndex;i++)
        {
            Console.WriteLine($"{i+1}. {scheme[i].SchemeName}");
        }
    }
    
    private int customerIndex = 0;

    public void RegisterCustomer()
    {
        Console.Write("Customer Id : ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Customer Name : ");
        string name = Console.ReadLine();

        Console.Write("Contact Number : ");
        string number = Console.ReadLine();

        customers[customerIndex++] =
            new Customer(id,name,number);

        Console.WriteLine("Customer Registered Successfully.");
    }
    
    public void LinkScheme()
    {
        Console.Write("Customer Id : ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Scheme Name : ");
        string schemeName = Console.ReadLine();

        Customer customer=null;
        BankScheme selectedScheme=null;

        for(int i=0;i<customerIndex;i++)
        {
            if(customers[i].CustomerId==id)
            {
                customer=customers[i];
                break;
            }
        }

        for(int i=0;i<schemeIndex;i++)
        {
            if(scheme[i].SchemeName.Equals(schemeName,StringComparison.OrdinalIgnoreCase))
            {
                selectedScheme=scheme[i];
                break;
            }
        }

        if(customer!=null && selectedScheme!=null)
        {
            customer.AddScheme(selectedScheme);

            Console.WriteLine("Scheme Linked Successfully.");
        }
        else
        {
            Console.WriteLine("Customer or Scheme not found.");
        }
    }
    
    
    
    public void CalculateInterest()
    {
        Console.Write("Customer Id : ");
        int id=int.Parse(Console.ReadLine());

        Customer customer=null;

        for(int i=0;i<customerIndex;i++)
        {
            if(customers[i].CustomerId==id)
            {
                customer=customers[i];
                break;
            }
        }

        if(customer==null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        Console.WriteLine("Interest Details");

        foreach(BankScheme scheme in customer.BankSchemes)
        {
            if(scheme!=null)
            {
                Console.WriteLine($"{scheme.SchemeName}");
            }
        }
    }
    
    public void DisplayCustomer()
    {
        Console.Write("Customer Id : ");

        int id=int.Parse(Console.ReadLine());

        for(int i=0;i<customerIndex;i++)
        {
            if(customers[i].CustomerId==id)
            {
                customers[i].DisplayDetails();
                return;
            }
        }

        Console.WriteLine("Customer not found.");
    }
}