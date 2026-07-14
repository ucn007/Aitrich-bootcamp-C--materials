using Jobportal.Enum;

namespace Jobportal.Models;

public class User
{
    public int id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ContactNumber { get; set; }
    public Role Role { get; set; }

    public User(int Id, string Name, string Email, string Password, string ContactNumber, Role Role)
    {
        this.id = Id;
        this.Name = Name;
        this.Email = Email;
        this.Password = Password;
        this.ContactNumber = ContactNumber;
        this.Role = Role;
    }
    
}