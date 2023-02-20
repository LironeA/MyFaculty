using System;
using System.Collections.Generic;

namespace MyFacultyWebApplication.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
