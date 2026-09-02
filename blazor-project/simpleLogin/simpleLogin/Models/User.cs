namespace simpleLogin.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    private string _password;

    public string Password
    {
        get => _password;
        set => _password = value;
    }

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; } 
}