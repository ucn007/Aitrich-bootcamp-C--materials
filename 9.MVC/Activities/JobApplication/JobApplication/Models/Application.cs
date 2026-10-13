using System;
using System.Collections.Generic;

namespace JobApplication.Models;

public partial class Application
{
    public Guid AppId { get; set; }

    public Guid UserId { get; set; }

    public Guid CompId { get; set; }

    public Guid JobId { get; set; }

    public DateTime? ApplieddAt { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
