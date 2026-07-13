namespace JobAdmin.Model;

public class Job
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string Description { get; set; }
   public double Salary { get; set; }
   public string Location { get; set; }

   public Job(int id, string name, string description, double salary, string location)
   {
      Id = id;
      Name = name;
      Description = description;
      Salary = salary;
      Location = location;
   }
}