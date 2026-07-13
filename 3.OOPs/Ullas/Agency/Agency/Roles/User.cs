namespace Agency.Roles;

public class User: IUser
{
   void addUser(IUser user)
   {
      Console.WriteLine("Enter user Id:");
      user.Id =  int.Parse(Console.ReadLine());
      Console.WriteLine("Enter user Name:");
      user.Name = Console.ReadLine();
      Console.WriteLine("Enter user Email:");
      
      user.Email = Console.ReadLine();
      
   } 
}