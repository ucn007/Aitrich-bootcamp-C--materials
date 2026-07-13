using JobAdmin.Interface;
using JobAdmin.Model;

namespace JobAdmin.Manager;

public class JobManager: Ijob
{
    private int jobcount = 0;
    private Job[] job = new Job[100];

    public void AddJob()
    {
        if (jobcount == job.Length)
        {
            Console.WriteLine("Jobs Limit reached");
        }
        
        Console.WriteLine("Enter Job Id:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Job Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Job Description:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter Salary:");
        double salary = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Location:");
        string location = Console.ReadLine();
        
        job[jobcount++]= new Job(id, name, description, salary, location);
        
        Console.WriteLine("Job Added Successfully");
        
        
    }

   

    public void ListJob()
    {
        Console.WriteLine("Available Jobs");

        for (int i = 0; i < jobcount; i++)
        {
            Console.WriteLine("*****************************************************************************************");
            Console.WriteLine("\n");
            Console.WriteLine("Job Id: " + job[i].Id);
            Console.WriteLine("Job Name: " + job[i].Name);
            Console.WriteLine("Job Description: " + job[i].Description);
            Console.WriteLine("Job Salary: " + job[i].Salary);
            Console.WriteLine("Job Location: " + job[i].Location);
            Console.WriteLine("\n");
            Console.WriteLine("*****************************************************************************************");
        }
    }
}