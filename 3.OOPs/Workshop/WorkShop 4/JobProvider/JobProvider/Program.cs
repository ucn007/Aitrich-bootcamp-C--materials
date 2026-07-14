// See https://aka.ms/new-console-template for more in
using JobProvider.Interface;
using JobProvider.Manager;
using JobProvider.Model;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

          ///  JobProvider_Manager jobProvider = new JobProvider_Manager();
            //IjobRepository job = new Job();
            //IUserRepository user = new JobProvider();
            IjobRepository ijob = new JobProvider_Manager();
            Console.WriteLine("Welcome to the job provider module!");

            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ijob.Register();
                        break;
                    case "2":
                        ijob.Login();
                        break;
             
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}

