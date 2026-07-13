using JobAdmin.Model;

namespace JobAdmin.Manager;

public class Admin
{
    private User[] users =  new User[10];
    private int userIndex = 0;
    JobManager jobmanager = new JobManager();
    
    bool loggedIn = false;

    public void Register(string username, string password)
    {
        if (userIndex == users.Length)
        {
           Console.WriteLine("User Limit reached!"); 
        }

        for (int i = 0; i < users.Length; i++)
        {
            
             
                users[userIndex] = new User(username, password);
                userIndex++;
             
        }
        
    }

    public void Login(string username, string password)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i].Username == username && users[i].Password == password)
            {
                loggedIn = true;
                 Console.WriteLine("Welcome, " + users[i].Username);

                 if (loggedIn)
                 {
                     Console.WriteLine("1. Post Job");
                     Console.WriteLine("2. List Job");
                     Console.WriteLine("3. Return to Main Menu");
                     int choice = Convert.ToInt32(Console.ReadLine());

                     if (choice == 1)
                     {
                         jobmanager.AddJob();
                     }
                     else if (choice == 2)
                     {
                         jobmanager.ListJob();
                     }
                     else if (choice == 3)
                     {
                         Console.WriteLine("Exiting..."); 
                         loggedIn = false;
                     }
                     
                 }
            }
            else
            {
                Console.WriteLine("Invalid username or password!");
               
            }
        }

        
    }
}