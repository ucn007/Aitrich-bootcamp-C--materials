using BanckScheme.Scheme;

namespace BanckScheme.Person;

public class Customer: Person
{
    private int _customerId;

    public int CustomerId
    {
        get => _customerId;
        set => _customerId = value;
    }

    private BankScheme[] bankSchemes = new BankScheme[20];
    private int schemeCount = 0;

    public BankScheme[] BankSchemes
    {
        get => bankSchemes;
    }

    public Customer(int customerId, string name, string contactNumber)
        : base(name, contactNumber)
    {
        CustomerId = customerId;
    }

    public void AddScheme(BankScheme scheme)
    {
        if (schemeCount < bankSchemes.Length)
        {
            bankSchemes[schemeCount++] = scheme;
        }
        else
        {
            Console.WriteLine("Cannot add more schemes.");
        }
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("===== Customer Details =====");
        Console.WriteLine($"Customer ID : {CustomerId}");
        Console.WriteLine($"Name        : {Name}");
        Console.WriteLine($"Contact     : {Number}");

        Console.WriteLine("Linked Schemes:");

        if (schemeCount == 0)
        {
            Console.WriteLine("No schemes linked.");
        }
        else
        {
            for (int i = 0; i < schemeCount; i++)
            {
                Console.WriteLine($"{i + 1}. {bankSchemes[i].SchemeName}");
            }
        }
    }
}