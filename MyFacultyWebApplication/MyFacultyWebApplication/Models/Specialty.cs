using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Models;

public partial class Specialty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GroupToSpecialtyRelation> GroupToSpecialtyRelations { get; } = new List<GroupToSpecialtyRelation>();
}
