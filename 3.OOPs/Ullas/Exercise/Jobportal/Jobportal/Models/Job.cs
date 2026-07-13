namespace Jobportal.Models;

public class Job
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string Location { get; set; }
    public double Salary { get; set; }

    public Job(int Id, string Name, string Description, string Location, double Salary)
    {
        this.id = Id;
        this.name = Name;
        this.description = Description;
        this.Location = Location;
        this.Salary = Salary;
        
    }
}