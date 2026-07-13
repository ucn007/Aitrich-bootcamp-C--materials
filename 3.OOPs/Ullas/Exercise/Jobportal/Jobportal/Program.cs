using Jobportal.Manage;

namespace  Jobportal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool exit = false;
            UserManage user =  new UserManage();
            while (!exit)
            {
                Console.WriteLine("Job portal");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.WriteLine("\nEnter Your Choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        user.Login();
                        break;
                    }
                    case 2:
                    {
                        user.Register();
                        break;
                    }
                    case 3:
                    {
                        exit = true;
                        break;
                    }
                }
            }
         
            
            
        }
    }
}