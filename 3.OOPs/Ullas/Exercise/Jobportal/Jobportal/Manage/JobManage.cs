using Jobportal.Models;

namespace Jobportal.Manage;

public class JobManage
{
    Job[] job = new Job[100];
int jobIndex = 0;
    public void AddJob()
    {
        if (job.Length >= jobIndex)
        {
            Console.WriteLine("Job limit reached");
        }
        else
        {
            Console.WriteLine("Add Job");
            Console.WriteLine("Enter job Id:");
            int jobId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter job Name:");
            string jobName = Console.ReadLine();
            Console.WriteLine("Enter job Description:");
            string jobDescription = Console.ReadLine();
            Console.WriteLine("Enter job Salary:");
            int jobSalary = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter job Location:");
            string jobLocation = Console.ReadLine();
            
            job[jobIndex++] = new Job(jobId, jobName, jobDescription,  jobLocation, jobSalary);
        }
    }
    
    public void Listjobs()
    {
        Console.WriteLine("Listing Jobs");
        for (int i = 0; i < job.Length; i++)
        {
            Console.WriteLine("\n");
            
            Console.WriteLine("========================== Job Id: " + job[i].id + "========================== ");
            Console.WriteLine("Job Name: " + job[i].name);
            Console.WriteLine("Job Description: " + job[i].description);
            Console.WriteLine("Job Location" + job[i].Location);
            Console.WriteLine("Job Salary: " + job[i].Salary);
            Console.WriteLine("\n");
        }
    }
}