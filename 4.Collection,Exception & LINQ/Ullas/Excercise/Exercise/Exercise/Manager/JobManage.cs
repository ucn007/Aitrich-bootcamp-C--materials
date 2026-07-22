using Exercise.Models;
using Exercise.Repository;

namespace Exercise.Manager;

public class JobManage
{
    private readonly JobRepository repository;
    private readonly JobPrinter printer = new();

    private readonly User loggedUser;

    public JobManage(JobRepository repository, User loggedUser)
    {
        this.repository = repository;
        this.loggedUser = loggedUser;
    }

    public void DisplayMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n========= JOB MENU =========");
            Console.WriteLine("1. Add Job");
            Console.WriteLine("2. List Jobs");
            Console.WriteLine("3. Delete Job");
            Console.WriteLine("4. Logout");

            Console.Write("Choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddJob();
                    break;

                case "2":
                    printer.Print(repository.GetAll());
                    break;

                case "3":
                    DeleteJob();
                    break;

                case "4":
                    exit = true;
                    Console.WriteLine("Logout Successful.");
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }

    private void AddJob()
    {
        Console.Write("Job Id : ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Title : ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Description : ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Company : ");
        string company = Console.ReadLine() ?? "";

        Console.Write("Location : ");
        string location = Console.ReadLine() ?? "";

        Console.Write("Salary : ");
        double salary = double.Parse(Console.ReadLine() ?? "0");

        Job job = new Job(
            id,
            title,
            description,
            company,
            location,
            salary
        );

        repository.Add(job);

        Console.WriteLine("Job Added Successfully.");
    }

    private void DeleteJob()
    {
        Console.Write("Enter Job Id : ");

        int id = int.Parse(Console.ReadLine() ?? "0");

        repository.Delete(id);

        Console.WriteLine("Job Deleted Successfully.");
    }
}