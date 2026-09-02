using System;
using System.Collections.Generic;

namespace ConsoleApp2.Migrations;

public partial class User
{
    public Guid Id { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public int Role { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? TelephoneNo { get; set; }

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();
}
