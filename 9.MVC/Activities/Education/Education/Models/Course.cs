using System;
using System.Collections.Generic;

namespace Education.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseCode { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int Credits { get; set; }

    public int DurationWeeks { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
