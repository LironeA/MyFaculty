using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;

namespace MyFacultyWebApplication.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int GroupId { get; set; }

    public virtual Group ?Group { get; set; } = null!;

    public int StatusId { get; set; }

    public virtual Status ?Status { get; set; } = null!;

    public string ?UserId { get; set; } = null!;

    public virtual User ?User { get; set; } = null!;
}
