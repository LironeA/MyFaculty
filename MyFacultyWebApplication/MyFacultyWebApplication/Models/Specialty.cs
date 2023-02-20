using System;
using System.Collections.Generic;

namespace MyFacultyWebApplication.Models;

public partial class Specialty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; } = new List<Group>();
}
