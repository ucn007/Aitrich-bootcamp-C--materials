using Exercise.Models;

namespace Exercise;

public class JobPrinter
{
    public void Print(List<Job> jobs)
    {
        Console.WriteLine();

        Console.WriteLine("================================ JOB LIST ================================");

        Console.WriteLine(
            "{0,-5} {1,-20} {2,-25} {3,-20} {4,-15} {5,10}",
            "ID",
            "Title",
            "Description",
            "Company",
            "Location",
            "Salary"
        );

        Console.WriteLine(new string('-', 105));

        if (jobs.Count == 0)
        {
            Console.WriteLine("No Jobs Available.");
            return;
        }

        foreach (Job job in jobs)
        {
            Console.WriteLine(
                "{0,-5} {1,-20} {2,-25} {3,-20} {4,-15} {5,10}",
                job.Id,
                job.Title,
                job.Description,
                job.CompanyName,
                job.Location,
                job.Salary
            );
        }

        Console.WriteLine();
    }
}