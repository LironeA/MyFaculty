using System;
using System.Collections.Generic;

namespace MyFacultyWebApplication.Models;

public partial class Degree
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; } = new List<Teacher>();
}
