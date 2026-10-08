using System;
using System.Collections.Generic;

namespace mvc_e_com.Model;

public partial class ActivityLog
{
    public int ActivityLogId { get; set; }

    public string EntityType { get; set; } = null!;

    public int EntityId { get; set; }

    public string Operation { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
}
