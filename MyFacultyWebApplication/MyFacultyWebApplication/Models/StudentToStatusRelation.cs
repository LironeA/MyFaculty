using System;
using System.Collections.Generic;

namespace MyFacultyWebApplication.Models;

public partial class StudentToStatusRelation
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int StatusId { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
