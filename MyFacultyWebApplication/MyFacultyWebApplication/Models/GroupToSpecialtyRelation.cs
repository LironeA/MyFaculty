using System;
using System.Collections.Generic;

namespace MyFacultyWebApplication.Models;

public partial class GroupToSpecialtyRelation
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int SpecialtyId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Specialty Specialty { get; set; } = null!;
}
