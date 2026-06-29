using System.Linq.Expressions;

internal class Program
{


    struct jobseeker
    {
        public string Name;
        public string email;
        public string password;
        public string qualification;
        public string skill;
        public int experience;
    }

    static jobseeker[] seeker = new jobseeker[10];
    static int seekercount = 0;
    static jobseeker loggedinuser;
   

    private static void Main(string[] args)
    {

        string choice;
        do
        {
            Console.WriteLine("Welcome to the jobseeker portal!");
            Console.WriteLine("Welcome to the job portal!");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            string ch = Console.ReadLine();

            switch (ch)
            {
                case "1":
                    register();
                    break;

                case "2":
                    login();
                    break;
                default:

                    Console.WriteLine("Invalid choice");
                    break;


            }



            Console.WriteLine("Do you want to continue (Y/N)?");
            choice = Console.ReadLine();
        }
        while (choice == "y" || choice == "Y");

    }


    static void register()
    {
        jobseeker js = new jobseeker();
        Console.WriteLine("Enter Name");
        js.Name = Console.ReadLine();

        Console.Write("Enter Email: ");
        js.email = Console.ReadLine();

        Console.Write("Enter Password: ");
        js.password = Console.ReadLine();

        Console.Write("Enter Qualification: ");
        js.qualification = Console.ReadLine();

        Console.Write("Enter Skill: ");
        js.skill = Console.ReadLine();

        Console.WriteLine("Enter experience");
        js.experience = Convert.ToInt32(Console.ReadLine());

        seeker[seekercount] = js;
        seekercount++;

        Console.WriteLine("Registration successfully");



    }


    static void login()
    {
        Console.WriteLine("Enter email");
        string mail = Console.ReadLine();

        Console.WriteLine("Enter password");
        string pass = Console.ReadLine();

        bool loginsuccess = false;

        for (int i = 0; i < seekercount; i++)
        {
            if (seeker[i].email == mail && seeker[i].password == pass)
            {
                loggedinuser = seeker[i];
                loginsuccess = true;
                Console.WriteLine("Login successfully");
                loginmenu();
                break;

            }
        }

    }


    static void loginmenu()
    {
        string choice;
        do
        {
            Console.WriteLine("List all jobs");
            Console.WriteLine("My profile");
            Console.WriteLine("Logout");
            Console.WriteLine("Enter your choice");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    listjob();
                    break;
                case "2":
                    display();
                    break;
                case "3":
                    Console.WriteLine("Logged out successfully");
                    return;
                default:

                    Console.WriteLine("Invalid choice");
                    break;
            }

        }

        while (true);
    }

    static void listjob()
    {
        Console.WriteLine("\nAvailable Jobs:");
        Console.WriteLine("1. Software Developer - ₹40,000/month - Bangalore");
        Console.WriteLine("2. Web Designer - ₹35,000/month - Chennai");
        Console.WriteLine("3. Data Analyst - ₹50,000/month - Pune");
        Console.WriteLine("4. .NET Developer - ₹60,000/month - Hyderabad");


    }

    static void display()
    {
        Console.WriteLine($"Name:{loggedinuser.Name}");
        Console.WriteLine($"Email:{loggedinuser.email}");
        Console.WriteLine($"Qualification:{loggedinuser.qualification}");
        Console.WriteLine($"Skill:{loggedinuser.skill}");
        Console.WriteLine($"Experience:{loggedinuser.experience}");
        

    }
}