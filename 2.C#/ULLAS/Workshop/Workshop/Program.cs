namespace  Workshop
{
    public class Program
    {
      
        struct adminProfile
        {
            public string fullname;
            public string username;
            public string Email;
            public long Phonenumber;
        }
        public static void Main(string[] args)
        {
            string ch;
          
            do
            {
                adminProfile[] admin = new adminProfile[1];
                Console.WriteLine("---------------------- Admin Profile ---------------------- ");
                Console.WriteLine("");
                Console.WriteLine("Please Select Your option:");
                Console.WriteLine("A. Registed Admin");
                Console.WriteLine("D. Display Admin");
                string choice = Console.ReadLine();
               
               
                switch (choice)
                {
                    case "A":
                    {
                        Console.WriteLine("---------------------- Add Profile ---------------------- ");
                        Console.WriteLine("Please enter Admin Full Name:");
                        admin[0].fullname = Console.ReadLine();
                        Console.WriteLine("Please enter Admin Username:");
                        admin[0].username = Console.ReadLine();
                        Console.WriteLine("Please enter Admin Email:");
                        admin[0].Email = Console.ReadLine();
                        Console.WriteLine("Please enter Admin Phone Number:");
                        admin[0].Phonenumber = long.Parse(Console.ReadLine());
                        
                        break;
                    }
                    case "D":
                    {
                        Console.WriteLine("---------------------- Admin Details  ---------------------- ");
                        if (string.IsNullOrEmpty(admin[0].fullname))
                        {
                            Console.WriteLine("No Admin Profile Found, Please create a new Admin Profile");
                            break;
                        }
                        Console.WriteLine("Enter name of Admin :  {0}", admin[0].fullname,"\n");
                                    
                        Console.WriteLine("Enter the username of admin :{0} ", admin[0].username,"\n");
                        Console.WriteLine("Enter the Email of Admin :{0} ", admin[0].Email,"\n");
                        Console.WriteLine("Enter the Phone no of Admin : {0}", admin[0].Phonenumber,"\n");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Please Select a valid option");
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to Continue? (Y/N)");
                ch = Console.ReadLine();
                
            } while ( ch == "Y" || ch == "y");
        }
    }
}