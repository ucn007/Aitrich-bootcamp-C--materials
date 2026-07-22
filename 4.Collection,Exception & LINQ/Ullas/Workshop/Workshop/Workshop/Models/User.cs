using WorkShop.Enums;

namespace WorkShop.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsAdmin { get; set; }
    public Roles Role { get; set; }
    public ExperienceLevel ExperienceLevel { get; set; }
    

    public User(int id, string username, string password, string email, string firstName, string lastName  )
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}