using System;
using System.Collections.Generic;

namespace MyFacultyWebApplication.Models;

public partial class GroupToSubjectRelation
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int SubjectId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
