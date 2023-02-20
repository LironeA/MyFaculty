using System;
using System.Collections.Generic;

namespace MyFacultyWebApplication.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int DegreeId { get; set; }

    public virtual Degree Degree { get; set; } = null!;

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; } = new List<TeacherToSubjectRelation>();
}
