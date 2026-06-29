internal class Program
{
    struct jobprovider
    {
        public string CompanyName;
        public string Email;
        public string Phone;
        public string Password;
        public string JobRole;
        public string Salary;
        public int ExperienceRequired;
    }
    static jobprovider[] jobproviders = new jobprovider[5];
    static jobprovider loggedinuser;
    static int usercount = 0;
    private static void Main(string[] args)
    {

        string ch;
        do
        {
            Console.WriteLine("Choose a option");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    login();
                    break;

                case "2":
                    register();
                    break;

                default:
                    Console.WriteLine("invalid choice");
                    break;
            }
            Console.WriteLine("Do you want continue(Y/N)");
            ch = Console.ReadLine();
        }

        while (ch == "y" || ch == "Y");

        static void login()
        {
            Console.WriteLine("Enter the email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string pass = Console.ReadLine();

            bool loginsuccessfull = false;
            foreach (jobprovider jp in jobproviders)
            {
                if (jp.Email == email && jp.Password == pass)
                {
                    loginsuccessfull = true;
                    loggedinuser = jp;

                    Console.WriteLine("Login successfull");
                    Console.WriteLine("Here are your details:");
                    Console.WriteLine("CompanyName:{0}", loggedinuser.CompanyName);
                    Console.WriteLine("Email:{0}", loggedinuser.Email);
                    Console.WriteLine("Password:{0}", loggedinuser.Password);
                    Console.WriteLine("Salary:{0}", jp.Salary);
                    Console.WriteLine("ExperienceRequired:{0}", jp.ExperienceRequired);
                    Console.WriteLine("JobRole:{0}", jp.JobRole);
                    Console.WriteLine("Phone:{0}", loggedinuser.Phone);
                }



            }
        }
        static void register()
        {
            jobprovider jobprovider=new jobprovider();


            Console.WriteLine("Enter company name");
            jobprovider.CompanyName = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            jobprovider.Email = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            jobprovider.Phone = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            jobprovider.Password = Console.ReadLine();



            Console.WriteLine("Enter JobRole:");
            jobprovider.JobRole = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            jobprovider.Salary = Console.ReadLine();

            Console.WriteLine("Enter ExperienceRequired:");
            jobprovider.ExperienceRequired = Convert.ToInt32(Console.ReadLine());

            jobproviders[usercount] = jobprovider;
            usercount++;

        }
    }
}