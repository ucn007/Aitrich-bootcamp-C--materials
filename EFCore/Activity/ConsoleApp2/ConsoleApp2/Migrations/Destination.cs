using System;
using System.Collections.Generic;

namespace ConsoleApp2.Migrations;

public partial class Destination
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? City { get; set; }

    public string? Description { get; set; }

    public Guid? CreatedBy { get; set; }

    public virtual User? CreatedByNavigation { get; set; }
}
