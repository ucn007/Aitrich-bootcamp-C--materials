namespace Exercise.Models;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CompanyName { get; set; }
    public string Location { get; set; }
    public double Salary { get; set; }

    public Job(int id, string title, string description, string companyName, string location, double salary)
    {
        Id = id;
        Title = title;
        Description = description;
        CompanyName = companyName;
        Location = location;
        Salary = salary;
        
    }
}