using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;
using NuGet.Protocol;

namespace MyFacultyWebApplication.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int DegreeId { get; set; }

    public string UserId { get; set; } = null!;

    public virtual ICollection<TeacherToDegreeRelation> TeacherToDegreeRelations { get; } = new List<TeacherToDegreeRelation>();

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; } = new List<TeacherToSubjectRelation>();
}
