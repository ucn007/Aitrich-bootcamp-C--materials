namespace loginsystem
{
    class Program
    {
        static void Main()
        {
            string username = "ucn@gmail.com";
            string password = "123456";
            
            Console.WriteLine("Please enter your username: ");
            string user = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            string pass = Console.ReadLine();

            if (username == user && password == pass)
            {
                Console.WriteLine("You have successfully logged in!");
            }
            else
            {
                Console.WriteLine("Incorrect username or password");
            }
        }
    }
};

