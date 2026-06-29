using System;

namespace CompanyRegistrationApp

{
    public class Program
    {
        struct Company
        {
            public string CompanyName;
            public string Email;
            public string Website;
            public string phone;
            public string Location;
            public string Password;
        }

        struct Interview
        {

            public string Title;
            public string Date;
            public string Time;
            public string Location;
            public string CompanyName;

        }

        static Company[] companies = new Company[10];
        static Interview[] interviews = new Interview[20];

        static int companyCount = 0;
        static int interviewCount = 0;
        static Company loggedInCompany;

        static void Main(string[] args)
        {
            int choice;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the jobseeker portal!");
                Console.WriteLine("Welcome to the job portal!");
                Console.WriteLine("1.RegisterCompany");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine("please enter your choice:");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterCompany();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        exit = true;
                        Console.WriteLine("exting application---------Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice! Try Again");
                        break;
                }

                //if (!exit)
                //{
                //Console.WriteLine("\n press enter to continue...");
                //Console.ReadLine();


                //}
            }
        }
        static void RegisterCompany()
        {
            if (companyCount >= companies.Length)
            {
                Console.WriteLine("Company limit reached!");
                return;
            }
            Company c = new Company();

            Console.WriteLine("\n-------------Register new Company ------------\n");
            Console.Write("Please Enter your Company Name: ");
            c.CompanyName = Console.ReadLine();
            Console.Write("Enter Company Email:");
            c.Email = Console.ReadLine();
            Console.Write("Enter Company Website: ");
            c.Website = Console.ReadLine();
            Console.Write("Please enter company phone number: ");
            c.phone = Console.ReadLine();
            Console.Write("Please Enter Company Location: ");
            c.Location = Console.ReadLine();
            Console.Write("Please Enter Company Password :");
            c.Password = Console.ReadLine();


            companies[companyCount] = c;
            companyCount++;

            Console.WriteLine("\nRegistration Successfull!");
        }

        static void Login()
        {
            Console.WriteLine("\n----------Company Login--------\n");
            Console.Write("Please Enter Company Email:");
            string email = Console.ReadLine();
            Console.Write("Please Enter your password:");
            string password = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < companyCount; i++)
            {
                if (companies[i].Email == email && companies[i].Password == password)
                {
                    loggedInCompany = companies[i];
                    found = true;

                    Console.WriteLine($"\nLoggin Successfull{loggedInCompany.CompanyName}!");
                    CompanyMenu();
                    break;


                }
            }

            if (!found)
            {
                Console.WriteLine("Invalid  Email or Password ");
            }
        }

        static void CompanyMenu()
        {
            bool logout = false;

            while (!logout)
            {
                Console.WriteLine("\n -------Company Dashboard------\n");
                Console.WriteLine("1. Schedule Interview :");
                Console.WriteLine("2. View Scheduled Interviews:");
                Console.WriteLine("3. Logout:");
                Console.Write("Enter your choice :");
                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        ScheduleInterview();
                        break;
                    case 2:
                        ViewScheduledInterviews();
                        break;
                    case 3:
                        logout = true;
                        Console.WriteLine("you have been logged out Successfully.");
                        break;
                    default:
                        Console.WriteLine("Invlid choice! Try again.");
                        break;
                }

            }
        }

        static void ScheduleInterview()
        {
            if (interviewCount >= interviews.Length)
            {
                Console.WriteLine("Interview Limit Reached!");
                return;
            }

            Interview i = new Interview();

            Console.WriteLine("\n -------Schedule New Interview--------");
            Console.Write("Title:");
            i.Title = Console.ReadLine();
            Console.WriteLine("Date (DD-MM-YYYY): ");
            i.Date = Console.ReadLine();
            Console.Write("Time: ");
            i.Time = Console.ReadLine();
            Console.Write("Location :");
            i.Location = Console.ReadLine();
            i.CompanyName = loggedInCompany.CompanyName;


            interviews[interviewCount] = i;
            interviewCount++;

            Console.WriteLine("\nInterview Scheduled Successfully!\n");
        }


        static void ViewScheduledInterviews()
        {
            Console.WriteLine($"\n ---- scheduled interviews for {loggedInCompany.CompanyName} ---");
            bool found = false;

            for (int i = 0; i < interviewCount; i++)
            {
                if (interviews[i].CompanyName == loggedInCompany.CompanyName)
                {
                    Console.WriteLine($"\nTitle: {interviews[i].Title}");
                    Console.WriteLine($"Date: {interviews[i].Date}");
                    Console.WriteLine($"Time:{interviews[i].Time}");
                    Console.WriteLine($"Location: {interviews[i].Location}");
                    Console.WriteLine("-------------------------");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No interviews Scheduled yet.");
            }
        }
    }
}





