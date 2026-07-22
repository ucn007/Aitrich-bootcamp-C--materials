using Exercise.Exception;
using Exercise.Interface;
using Exercise.Models;

namespace Exercise.Repository;

public class UserRepository: IuserInterFace
{
    private List<User> users = new();

    public void Register(User user)
    {
        if (users.Any(u => u.Email == user.Email))
        {
            throw new UserAlreadyExists.UserAlreadyExistsException(
                $"A user with email '{user.Email}' already exists."
            );
            return;
        }

        users.Add(user);
        Console.WriteLine("Registration Successful.");
    }

    public User Login(string email, string password)
    {
        return users.FirstOrDefault(u =>
            u.Email == email &&
            u.Password == password);
    }

    public List<User> GetAllUsers()
    {
        return users;
    }

    public User GetUserByEmail(string email)
    {
        return users.FirstOrDefault(u => u.Email == email);
    }

    public bool DeleteUser(string email)
    {
        User user = GetUserByEmail(email);

        if (user != null)
        {
            users.Remove(user);
            return true;
        }

        return false;
    }
}