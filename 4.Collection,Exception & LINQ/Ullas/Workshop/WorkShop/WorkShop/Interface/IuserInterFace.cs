using WorkShop.Models;

namespace WorkShop.Interface;

public interface IuserInterFace
{
   public void Register(User user);

    User Login(string email, string password);

    List<User> GetAllUsers();

  
}