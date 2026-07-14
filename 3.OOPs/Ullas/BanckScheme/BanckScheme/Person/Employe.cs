namespace BanckScheme.Person;

public class Employee : Person
{
  private  int _employeeId  ;
  public  string Designation;

  public int employeeId
  {
    get { return _employeeId; }
    set { _employeeId = value; }
  }
  
  public Employee(string name, string designation, int employeeId,string number) : base(name, number)
  {
    _employeeId = employeeId; 
    Designation = designation;
  }

  public override void DisplayDetails()
  {
    Console.WriteLine($"Name: {Name}");
    Console.WriteLine($"Designation: {Designation}");
    Console.WriteLine($"Employee ID: {employeeId}");
    Console.WriteLine($"Number: {Number}");
    
  }
}