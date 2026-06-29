

//using System;

//namespace InterviewSchdule
//{
//    internal class Program
//    {
//        struct Interview {

//            public string Title;
//            public DateTime date;
//            public string Time;
//            public string location;

//        }

//        static void Main(string[] args)
//        {
//            Interview[] schedule = new Interview[10];
//            int interviewCount = 0;

//            Console.WriteLine("\n-------------------------------------schedule an interview for jobseekers-----------------\n ");

//            string choice;

//            do
//            {
//                Console.WriteLine("A-Schedule an interview");
//                Console.WriteLine("D- Display scheduled interviews");
//                Console.WriteLine("select an option:");
//                string command = Console.ReadLine()?.Trim().ToUpper();

//                switch (command)
//                {
//                    case "A":
//                        Console.WriteLine("How many interviews do you want to schedule?");
//                        int count = Convert.ToInt32(Console.ReadLine());

//                        for (int i = 0; i < count && interviewCount < schedule.Length; i++)

//                        {
//                            Console.WriteLine($"\n----Interview Schedule   {interviewCount + 1}----");
//                            Console.Write("Enter the job title:");
//                            schedule[interviewCount].Title = Console.ReadLine();


//                            Console.Write("Enter the Date (dd-mm-yyyy):  ");
//                            schedule[interviewCount].date = DateTime.Parse(Console.ReadLine());

//                            Console.Write("Enter the Time (hh:mm): ");
//                            schedule[interviewCount].Time = Console.ReadLine();

//                            Console.Write("Enter the location:");
//                            schedule[interviewCount].location = Console.ReadLine();

//                            interviewCount++;


//                        }
//                        break;

//                    case "D":
//                        Console.WriteLine("\n----------scheduled interviews------ ");

//                        if (interviewCount == 0)
//                        {
//                            Console.WriteLine("no interviews scheduled yet.");
//                        }
//                        else
//                        {
//                            for (int i = 0; i < interviewCount; i++)
//                            {
//                                Console.WriteLine($"\nInterview ID: {i + 1}");
//                                Console.WriteLine($"\njobtitle :{schedule[i].Title}");
//                                Console.WriteLine($"\nDate: {schedule[i].date:dd-mm-yyyy}");
//                                Console.WriteLine($"\nTime: {schedule[i].Time}");
//                                Console.WriteLine($"\nLocation: {schedule[i].location}");

//                            }
//                        }
//                        break;


//                    default:
//                        Console.WriteLine("invalid option! please select A or D.");
//                        break;
//                }
//                Console.WriteLine("Do you Want to Continue? (Y/N)");
//                choice = Console.ReadLine()?.Trim().ToUpper();


//            } while (choice == "Y");

//            }
//            }
//    } 




//workshop-4


namespace Provider_App
{
    public class Program
    {
        struct JobProvider
        {
            public string CompanyName;
            public string Email;
            public string phone;
            public string password;
            public string JobRole;
            public string Salary;
            public int ExperienceRequired;
        }

        static JobProvider[] jobprovider = new JobProvider[5];
        static JobProvider loggedinUser;
        static int userCount = 0;
        static void Main(string[] args)
        {


            string ch;
            do
            {
                Console.WriteLine("***************************");
                Console.WriteLine("choose the option you want to from  below:");
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Register as a new JobProvider");
                Console.WriteLine("*******************************");

                string choice = Console.ReadLine();

                switch (choice)
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
                Console.WriteLine("Do you want to continue (Y/N)");

                ch = Console.ReadLine();

            }
            while (ch == "y" || ch == "Y");
        }



        static void Login()
        {

            Console.WriteLine("*******************************");

            Console.WriteLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();


            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("*******************************");

            bool loginSuccessfull = false;


            foreach (JobProvider jp in jobprovider)
            {
                if (jp.Email == email && jp.password == password)
                {
                    loginSuccessfull = true;
                    loggedinUser = jp;


                    Console.WriteLine("Login Successfull");
                    Console.WriteLine();
                    Console.WriteLine("Here are your details:");
                    Console.WriteLine("ComapanyName:{0}", loggedinUser.CompanyName);
                    Console.WriteLine("Email:{0}", loggedinUser.Email);
                    Console.WriteLine("Password: {0}", loggedinUser.password);
                    Console.WriteLine("Salary:{0}", jp.Salary);
                    Console.WriteLine("ExperienceRequired:{0}", jp.ExperienceRequired);
                    Console.WriteLine("JobRole:{0}", jp.JobRole);
                    Console.WriteLine("Phone:{0}", loggedinUser.phone);
                    Console.WriteLine();

                }
            }
        }
        static void Register()
        {
            JobProvider jobProvider = new JobProvider();

            Console.WriteLine("********************************");
            Console.WriteLine();
            Console.WriteLine("Enter CompanyName:");
            jobProvider.CompanyName = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            jobProvider.Email = Console.ReadLine();

            Console.WriteLine("Enter Phone:");
            jobProvider.phone = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            jobProvider.password = Console.ReadLine();



            Console.WriteLine("Enter JobRole: ");
            jobProvider.JobRole = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            jobProvider.Salary = Console.ReadLine();

            Console.WriteLine("Enter ExperienceRequired:");
            jobProvider.ExperienceRequired = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("********************************");

            jobprovider[userCount] = jobProvider;
            userCount++;



        }


    }
}












