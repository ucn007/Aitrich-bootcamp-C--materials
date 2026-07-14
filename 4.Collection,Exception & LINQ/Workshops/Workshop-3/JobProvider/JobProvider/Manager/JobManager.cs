using JobProvider;
using JobProvider.Interface;
using JobProvider.Interfaces;
using JobProvider.Manager;
using JobProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Job.Manager
{
    public class JobManager : IMenu
    {
        IJobProvider Jobs = new JobPortal();
        private User loggedUser;
        private Lists display = new Lists();
        public JobManager(User loggedUser)
        {
            this.loggedUser = loggedUser;
        }
        public void DisplayMenu()
        {
            ShowAdminMenu();
        }
        public void Logout()
        {
            loggedUser = new User();
            Console.WriteLine("Logged out successfully!");

        }
        private void ShowAdminMenu()
        {
            Console.WriteLine("1. Post a  job ");
            Console.WriteLine("2. List all Jobs ");
            Console.WriteLine("3. Logout");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Job title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Job description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter Job location: ");
                    string location = Console.ReadLine();
                    Console.Write("Enter Job Type: ");
                    string type = Console.ReadLine();
                    Console.Write("Enter Job salary range: ");
                    string salary = (Console.ReadLine());
                    Console.Write("Enter Job company: ");
                    string company = (Console.ReadLine());
                    Job job = new Job(title, description, location, type, salary, company);
                    Jobs.PostJob(job);
                    Console.WriteLine("Job posted successfully.");
                    ShowAdminMenu();
                    break;
                case "2":
                    List<Job> jobs = Jobs.GetJobs();
                    display.Print(jobs);
                    ShowAdminMenu();
                    break;
                case "3":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowAdminMenu();
                    break;
            }
        }
    }
}
