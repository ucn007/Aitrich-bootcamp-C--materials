

using JobProvider.Enums;

namespace JobProvider.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public User() { }
        public User(int id, string firstname, string lastname, string email, long phone, string password, Roles roles)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Phone = phone;
            Password = password;
            Role = roles;
        }
    }
}
