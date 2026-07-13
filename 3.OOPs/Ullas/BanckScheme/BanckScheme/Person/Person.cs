namespace BanckScheme.Person;

public abstract class Person
{
    public string Name { get; set; }
    public string Number { get; set; }
    
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Number: {Number}");
    }
    public Person(string name, string number)
    {
        Name = name;
        Number = number;
    }
}
