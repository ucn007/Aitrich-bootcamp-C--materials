using System;
using System.Collections.Generic;

namespace School_app.Models;

public partial class AuditLog
{
    public long Id { get; set; }

    public string TableName { get; set; } = null!;

    public long? RecordId { get; set; }

    public string Action { get; set; } = null!;

    public string? OldData { get; set; }

    public string? NewData { get; set; }

    public string? PerformedBy { get; set; }

    public DateTime PerformedAt { get; set; }
}
