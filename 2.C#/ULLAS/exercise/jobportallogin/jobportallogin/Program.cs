using System;

namespace jobportallogin
{
    class Program
    {
        struct candidate
        {
            public string name;
            public string password;
            public string email;
            public string phoneNumber;
        }

        
        static candidate[] users = new candidate[10];

        
        static int userCount = 0;

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("------------------------------ Welcome to Job Portal ------------------------------");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    {
                        Console.WriteLine("Login to Job Portal");
                        Console.Write("Username: ");
                        string uname = Console.ReadLine();

                        Console.Write("Password: ");
                        string pass = Console.ReadLine();

                        bool found = false;

                        for (int i = 0; i < userCount; i++)
                        {
                            if (users[i].name == uname && users[i].password == pass)
                            {
                                Console.WriteLine("Login Successful");

                                found = true;

                              Console.WriteLine("1. Search Job");
                              Console.WriteLine("2. Logout");
                              choice = Convert.ToInt32(Console.ReadLine());
                              switch (choice)
                              {
                                  case 1:
                                  {
                                      Console.WriteLine("Frontend Developer");
                                      Console.WriteLine("Infosys , cochin");
                                      Console.WriteLine("1. Apply");
                                      Console.WriteLine("2. Cancel");
                                      int selection =  Convert.ToInt32(Console.ReadLine());
                                      switch (selection)
                                      {
                                          case 1:
                                          {
                                              Console.WriteLine("Application Successful");
                                              break;
                                          }
                                          case 2:
                                          {
                                              Console.WriteLine("Application Cancelled");
                                              break;
                                          }
                                      }
                                      break;
                                  }
                                  case 2:
                                  {
                                      Console.WriteLine("Logout done");
                                      break;
                                  }
                              }
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Invalid Username or Password.");
                        }

                        Console.ReadKey();
                        break;
                    }

                    case 2:
                    {
                        Console.WriteLine("Register");

                        Console.Write("Username: ");
                        users[userCount].name = Console.ReadLine();

                        Console.Write("Password: ");
                        users[userCount].password = Console.ReadLine();

                        Console.Write("Email: ");
                        users[userCount].email = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        users[userCount].phoneNumber = Console.ReadLine();

                        userCount++;

                        Console.WriteLine("Registration Successful.");

                        Console.ReadKey();
                        break;
                    }

                    case 3:
                    {
                        exit = true;
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }
}