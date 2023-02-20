using System;
using System.Collections.Generic;

namespace MyFacultyWebApplication.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SpecialtyId { get; set; }

    public virtual ICollection<GroupToSubjectRelation> GroupToSubjectRelations { get; } = new List<GroupToSubjectRelation>();

    public virtual Specialty Specialty { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
