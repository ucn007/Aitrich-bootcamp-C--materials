using JobSeeker.Interfaces;
using JobSeeker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Manager
{
    public class UserManager:IMenu
    {
        private User loggedUser;
        JobManager jobs = new JobManager();
        public UserManager(User loggedUser)
        {
            this.loggedUser = loggedUser;
        }
        public UserManager()
        {

        }

        public void DisplayMenu()
        {
            ShowJobSeekerMenu();
        }
        public void ShowJobSeekerMenu()
        {
                //  Console.WriteLine("Welcome " + loggedInJobSeeker.FirstName + "!");
                Console.WriteLine("1. List all jobs");
                Console.WriteLine("2. My profile");
                Console.WriteLine("3. Logout");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    jobs.ListJobs();
                        ShowJobSeekerMenu();
                        break;
                    case "2":
                        
                        ShowJobSeekerMenu();
                        break;
                    case "3":
                        Logout();
                        break;


                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        ShowJobSeekerMenu();
                        break;
                }

            }
        public void Logout()
        {
            loggedUser = new User();
            Console.WriteLine("Logged out successfully!");

        }

    }
    
}
