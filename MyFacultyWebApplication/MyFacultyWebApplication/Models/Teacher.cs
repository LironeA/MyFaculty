<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

namespace MyFacultyWebApplication.Models;

public partial class Teacher
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Ім'я")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Прізвище")]
    public string Surname { get; set; } = null!;
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "По-батькові")]
    public string LastName { get; set; } = null!;
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Дата Народження")]
    public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Ступінь")]
    public int DegreeId { get; set; }

    public string? UserId { get; set; } = null!;

    public virtual ICollection<TeacherToDegreeRelation> TeacherToDegreeRelations { get; } = new List<TeacherToDegreeRelation>();

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; } = new List<TeacherToSubjectRelation>();
}
