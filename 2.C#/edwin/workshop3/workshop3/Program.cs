using System.Diagnostics.Metrics;
using System.Xml.Linq;

internal class Program
{
    struct job
    {
        public string Title;
        public string Description;
        public string Salary;
        public string Location;
    }
    private static void Main(string[] args)
    {
        job[] jobs = new job[10];
        int jobcount = 0;

        string choice;
        do
        {
            Console.WriteLine("\n-------------------------------- JOB PROVIDER --------------------------------\n");
            Console.WriteLine("A. Post job");
            Console.WriteLine("D. Display posted jobs");
            Console.WriteLine("Please select the options");
            string command = Console.ReadLine()?.Trim().ToUpper();

            switch (command)
            {
                case "A":
                    Console.WriteLine("How many jobs you want to post??");
                    int count = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < count && jobcount < jobs.Length; i++)
                    {
                        Console.WriteLine($"\n---- Job Details {jobcount + 1}----");
                        Console.WriteLine("Enter the name of the job");
                        jobs[jobcount].Title = Console.ReadLine();

                        Console.WriteLine("Enter the Description of the job");
                        jobs[jobcount].Description = Console.ReadLine();

                        Console.WriteLine("Enter the Salary of the job");
                        jobs[jobcount].Salary = Console.ReadLine();

                        Console.WriteLine("Enter the Location of the job");
                        jobs[jobcount].Location = Console.ReadLine();

                        jobcount++;
                    }
                    break;

                case "D":
                    Console.WriteLine("\n------------------ List of Jobs ------------------");
                    if (jobcount == 0)
                    {
                        Console.WriteLine("No jobs posted yet.");
                    }
                    else
                    {
                        for (int i = 0; i < jobs.Length; i++)
                        {
                            Console.WriteLine($"\n Job ID:{i + 1}");
                            Console.WriteLine($"Name of Job: {jobs[i].Title}");
                            Console.WriteLine($"Description: {jobs[i].Description}");
                            Console.WriteLine($"Salary: {jobs[i].Salary}");
                            Console.WriteLine($"Location: {jobs[i].Location}");
                        }

                    }
                    break;

                default:
                    Console.WriteLine("Invalid option! Please choose A or D.");
                    break;
            }
            Console.WriteLine("\n Do You want to continue? (yes/no)");
            choice = Console.ReadLine().Trim().ToLower();
        } while (choice == "yes");
    }
}





internal class Program
{
    struct JobProvider
    {
        public string email;
        public string password;
        public int userid;
        public string name;
        public string designation;
        public long phone_no;
    }
    static JobProvider[] jobProviders = new JobProvider[4];

    private static void Main(string[] args)
    {
        string ch;
        do
        {
            Console.WriteLine("****");
            Console.WriteLine("Welcome to the hire me now portal!");
            Console.WriteLine("----");
            Console.WriteLine("1. Please login for add,list members");
            Console.WriteLine("****");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Login();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            Console.WriteLine("Do you want to continue? (Y/N)");
            ch = Console.ReadLine();

        } while (ch == "Y" || ch == "y");
    }
    static void Login()
    {
        JobProvider jobProvider = new JobProvider();
        Console.WriteLine("Enter Your email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Enter your password: ");
        string password = Console.ReadLine();
        if (email == "new@gmail.com" && password == "new123")
        {
            Console.WriteLine();
            Console.WriteLine("Login successfully");
            Console.WriteLine();
            string select;
            do
            {
                Console.WriteLine("1. List all company members");
                Console.WriteLine("2. Add company members");
                Console.WriteLine("3. Logout ");
                Console.WriteLine("Choose one option");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("List of company members");
                        Console.WriteLine("*********");
                        Console.WriteLine($"Member id: {jobProvider.userid}\n Name: {jobProvider.name}\n Designation: {jobProvider.designation}\n Email: {jobProvider.email}\n Phone number: {jobProvider.phone_no}");
                        break;
                    case "2":
                        Console.WriteLine("Add members to company");
                        Console.WriteLine("*********");
                        Console.WriteLine("Enter userid: ");
                        jobProvider.userid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name: ");
                        jobProvider.name = Console.ReadLine();
                        Console.WriteLine("Enter Designation: ");
                        jobProvider.designation = Console.ReadLine();
                        Console.WriteLine("Enter email: ");
                        jobProvider.email = Console.ReadLine();
                        Console.WriteLine("Enter phone number: ");
                        jobProvider.phone_no = long.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Successfully added the member");
                        Console.WriteLine("*********");
                        Console.WriteLine($"Member id: {jobProvider.userid}\n Name: {jobProvider.name}\n Designation: {jobProvider.designation}\n Email: {jobProvider.email}\n Phone number: {jobProvider.phone_no}");
                        break;
                    case "3":
                        Console.WriteLine("Exiting");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (select != "3");

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Please enter correct email and password");
        }
    }
}

