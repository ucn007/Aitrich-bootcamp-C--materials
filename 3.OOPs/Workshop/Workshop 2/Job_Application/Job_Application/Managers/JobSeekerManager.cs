using Job_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Application.Managers
{
    public class JobSeekerManager
    {
        public JobSeekerManager() { }

        private JobSeeker[] jobSeekers = new JobSeeker[10];
        int jobSeekerCount = 0;
        public JobSeeker loggedInJobSeeker =new JobSeeker();
    

        public void RegisterJobSeeker()
        {
            JobSeeker newJobSeeker = new JobSeeker();

            Console.WriteLine("Please enter your first name:");
            newJobSeeker.FirstName = Console.ReadLine();

            Console.WriteLine("Please enter your last name:");
            newJobSeeker.LastName = Console.ReadLine();

            Console.WriteLine("Please enter your email address:");
            newJobSeeker.Email = Console.ReadLine();

            Console.WriteLine("Please enter your phone number:");
            newJobSeeker.Phone = Console.ReadLine();

            Console.WriteLine("Please enter a password:");
            newJobSeeker.Password = Console.ReadLine();

           

            jobSeekers[jobSeekerCount] = newJobSeeker;
            jobSeekerCount++;

            Console.WriteLine("Registration successful");
        }

       public bool LoginJobSeeker()
        {
            Console.WriteLine("Please enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();

            bool loginSuccessful = false;
            foreach(JobSeeker seeker in jobSeekers)
            {
                if (seeker !=null && seeker.Email == email && seeker.Password == password)
                {
                    loggedInJobSeeker = seeker;
                    loginSuccessful = true;
                    break;
                }
            }
            
            return loginSuccessful;
         
        }

        public void ShowJobSeekerMenu()
        {
          //  Console.WriteLine("Welcome " + loggedInJobSeeker.FirstName + "!");
          
            Console.WriteLine("1. My profile");
          
            Console.WriteLine("2. Logout");

            string choice = Console.ReadLine();

            switch (choice)
            {
               
                case "1":
                    ViewProfile();
                    ShowJobSeekerMenu();
                    break;
                case "2":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowJobSeekerMenu();
                    break;
            }
        }

       

        public void ViewProfile()
        {
            Console.WriteLine("-------------------------------MY PROFILE-------------------------------------\n");
            Console.WriteLine($"First Name: {loggedInJobSeeker.FirstName}");
            Console.WriteLine($"Last Name: {loggedInJobSeeker.LastName}");
            Console.WriteLine($"Email: {loggedInJobSeeker.Email}");
            Console.WriteLine($"Phone: {loggedInJobSeeker.Phone}");
            Console.WriteLine($"Location: {loggedInJobSeeker.Location}");
            Console.WriteLine($"AboutMe: {loggedInJobSeeker.AboutMe}");
            Console.WriteLine($"ExperienceLevel: {loggedInJobSeeker.ExperienceLevel}");
            Console.WriteLine("\n");

        }

        public void Logout()
        {
            loggedInJobSeeker = new JobSeeker();
            Console.WriteLine("Logged out successfully!");
           ShowMainMenu();
        }

        public  void ShowMainMenu()
        {
            //JobSeekerManager seekerManager = new JobSeekerManager();
            Console.WriteLine("Welcome to the job portal!");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterJobSeeker();
                    break;
                case "2":
                    bool loginRes = LoginJobSeeker();
                    if (loginRes) // check if the user is logged in
                    {
                        Console.WriteLine("Welcome " + loggedInJobSeeker.FirstName + "!");
                        ShowJobSeekerMenu();
                    }
                    else
                    {
                        Console.WriteLine("Login failed...!");

                        ShowMainMenu();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ShowMainMenu();
                    break;
            }
        }


    }
}
