internal class Program
{
    struct JobProvider
    {
        public string CompanyName;
        public string email;
        public long phone;
        public string password;
        public string jobrole;
        public int salary;
        public int experiencedR;
    }
    static JobProvider[] jobp = new JobProvider[5];
    static JobProvider loggedUser;
    static int userCount = 0;

    private static void Main(string[] args)
    {
        string ch;
        do
        {
            Console.WriteLine("*********");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register as a new Jobprovider");
            Console.WriteLine("Select a option");

            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    Login();
                    break;

                case "2":
                    Register();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            Console.WriteLine("Do you want to continue? y or N");
            ch= Console.ReadLine();

        }while (ch=="Y" || ch=="y");
        
        static void Login()
        {
            Console.WriteLine("***********");

            Console.WriteLine("Enter email: ");
            string email=Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string pass=Console.ReadLine();

            Console.WriteLine("***********");
            
            bool loginSuccessfull = false;  

            foreach(JobProvider jp in jobp) {
                if(jp.email == email && jp.password == pass)
                {
                    loginSuccessfull = true;
                    loggedUser = jp;

                    Console.WriteLine("Login Successfull");
                    Console.WriteLine("Here are your details :--- ");
                    Console.WriteLine($"Company name: {loggedUser.CompanyName}");
                    Console.WriteLine($"Email: {loggedUser.email}");
                    Console.WriteLine($"Password: {loggedUser.password}");
                    Console.WriteLine($"Salary: {loggedUser.salary}");
                    Console.WriteLine($"ExperinceRequired: {loggedUser.experiencedR}");
                    Console.WriteLine($"JOb role: {loggedUser.jobrole}");
                    Console.WriteLine($"Phone number: {loggedUser.phone}");
                }
            }
            bool loginSuccessful = false;
            if (!loginSuccessful)
            {
                Console.WriteLine("\nInvalid email or password. Please try again.");
            }
        }
        static void Register()
        {
            JobProvider jobProvider = new JobProvider();

            Console.WriteLine("******");
            Console.WriteLine("Enter Company name: ");
            jobProvider.CompanyName = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            jobProvider.email = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            jobProvider.phone=Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter Password:");
            jobProvider.password = Console.ReadLine();



            Console.WriteLine("Enter JobRole:");
            jobProvider.jobrole = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            jobProvider.salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter ExperienceRequired:");
            jobProvider.experiencedR = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("***********");

            jobp[userCount] = jobProvider;
            userCount++;

        }
    }
}