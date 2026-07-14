using Admin_Job.Interface;
using Admin_Job.Interfaces;
using Admin_Job.Models;
using Admin_Job.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Job.Manager
{
    public class AdminManager:IMenu
    {
        IJobProvider Jobs =new JobManager();
        private User loggedUser;
        private UserRepository Admins = new UserRepository();
        private Lists display = new Lists();
        public AdminManager(User loggedUser)
        {
            this.loggedUser = loggedUser;
        }

        public void DisplayMenu()
        {
            ShowAdminMenu();
        }

        public void ShowAdminMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1.List all admins");
            Console.WriteLine("2.My profile");
            Console.WriteLine("3. Post a  job ");
            Console.WriteLine("4. List all Jobs ");
            Console.WriteLine("5. Logout");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var users = Admins.getAll();
                    display.Print(users);
                    ShowAdminMenu();
                    break;
                case "2":

                    ViewProfile();
                    ShowAdminMenu();
                    break;
                case "3":
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
                case "4":
                    List<Job> jobs = Jobs.GetJobs();
                    display.Print(jobs);
                    ShowAdminMenu();
                    break;
                case "5":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowAdminMenu();
                    break;
            }
        }

        public void ViewProfile()
        {
            User loggeduser = Admins. getLoggedUser ();
            Console.WriteLine("-------------------------------MY PROFILE-------------------------------------\n");
            Console.WriteLine($"First Name: {loggeduser.FirstName}");
            Console.WriteLine($"Last Name: {loggeduser.LastName}");
            Console.WriteLine($"Email: {loggeduser.Email}");
            Console.WriteLine($"Phone: {loggeduser.Phone}");
            Console.WriteLine("\n");

        }


        public void Logout()
        {
            loggedUser = new User();
            Console.WriteLine("Logged out successfully!");

        }
    }
}
