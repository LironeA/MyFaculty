using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Models;

public partial class Degree
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TeacherToDegreeRelation> TeacherToDegreeRelations { get; } = new List<TeacherToDegreeRelation>();
}
