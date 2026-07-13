using System.Security.Cryptography;
using Jobportal.Enum;
using Jobportal.Models;

namespace Jobportal.Manage;

public class UserManage
{
    private User[] users = new User[10];
    MenuManage menu = new MenuManage();
    int userIndex = 0;

    
    
    public void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] != null &&
                users[i].Name == username &&
                users[i].Password == password)
            {
                if (users[i].Role == Role.Provider)
                {
                    menu.ProviderMenu(users, i);
                }
                else
                {
                    menu.SeekerMenu(users, i);
                }

                return;
            }
        }

        Console.WriteLine("Invalid username or password.");
    }

    public void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        for (int i = 0; i < users.Length; i++)
        {
            if (username == users[i].Name)
            {
                Console.WriteLine("Username already exists.");
            }
            else
            {
                Console.WriteLine("Enter User ID");
                int userId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter password.");
                string password = Console.ReadLine();
                Console.WriteLine("Enter Email:");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Number:");
                string number = Console.ReadLine();
                Console.WriteLine("Enter Role:");
                Console.WriteLine("1. Provider");
                Console.WriteLine("2. Seeker");
                int role = int.Parse(Console.ReadLine());
                Role r;
                if (role == 1)
                { 
                    r = Role.Provider;
                    users[userIndex++] = new User(userId, username, email, password, number, r);
                }
                else if (role == 2)
                {
                    r = Role.Seeker;
                    users[userIndex++] = new User(userId, username, email, password, number, r);
                }
                else
                {
                    Console.WriteLine("Invalid Role.");
                }

               

            }
        }
       
            
        
    }
}