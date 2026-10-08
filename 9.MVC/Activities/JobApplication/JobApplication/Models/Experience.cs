using System;
using System.Collections.Generic;

namespace JobApplication.Models;

public partial class Experience
{
    public Guid ExpId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
