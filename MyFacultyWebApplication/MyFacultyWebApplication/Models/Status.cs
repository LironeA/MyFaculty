using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Models;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudentToStatusRelation> StudentToStatusRelations { get; } = new List<StudentToStatusRelation>();
}
