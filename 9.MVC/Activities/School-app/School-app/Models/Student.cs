using System;
using System.Collections.Generic;

namespace School_app.Models;

public partial class Student
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long CourseId { get; set; }

    public string AdmissionNumber { get; set; } = null!;

    public DateOnly AdmissionDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
