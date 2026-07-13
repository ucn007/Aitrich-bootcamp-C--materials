using Jobportal.Models;

namespace Jobportal.Manage;

public class MenuManage
{
    JobManage job = new JobManage();
    public void ProviderMenu(User[] users, int userIndex)
    {
        User currentUser = users[userIndex];

        while (true)
        {
            Console.WriteLine($"\nWelcome {currentUser.Name}");
            Console.WriteLine("Provider Menu");
            Console.WriteLine("1. List All Jobs");
            Console.WriteLine("2. Post Job");
            Console.WriteLine("3. View Scheduled Interviews");
            Console.WriteLine("4. Logout");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                   job.Listjobs();
                    Console.WriteLine("List all jobs");
                    break;

                case 2:
                    job.AddJob();
                    Console.WriteLine("Post a job");
                    break;

                case 3:
                    Console.WriteLine("View scheduled interviews");
                    break;

                case 4:
                    Console.WriteLine("Logged out successfully.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    public void SeekerMenu(User[] users, int userIndex)
    {
        User currentUser = users[userIndex];

        while (true)
        {
            Console.WriteLine($"\nWelcome {currentUser.Name}");
            Console.WriteLine("Seeker Menu");
            Console.WriteLine("1. List All Jobs");
            Console.WriteLine("2. My Profile");
            Console.WriteLine("3. View Applied Jobs");
            Console.WriteLine("4. Logout");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("List all jobs");
                    job.Listjobs();
                    break;

                case 2:
                    Console.WriteLine($"Name  : {currentUser.Name}");
                    Console.WriteLine($"Email : {currentUser.Email}");
                    Console.WriteLine($"Role  : {currentUser.Role}");
                    break;

                case 3:
                    Console.WriteLine("View applied jobs");
                    break;

                case 4:
                    Console.WriteLine("Logged out successfully.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}