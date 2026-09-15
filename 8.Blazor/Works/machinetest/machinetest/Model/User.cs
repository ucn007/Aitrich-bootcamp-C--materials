using System;
using System.Collections.Generic;

namespace machinetest.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Role { get; set; }
}
