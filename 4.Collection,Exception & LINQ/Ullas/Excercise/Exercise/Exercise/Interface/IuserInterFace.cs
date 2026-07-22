using Exercise.Models;

namespace Exercise.Interface;

public interface IuserInterFace
{
   public void Register(User user);

    User Login(string email, string password);

    List<User> GetAllUsers();

  
}