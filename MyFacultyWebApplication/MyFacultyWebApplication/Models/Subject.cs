using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFacultyWebApplication.Models;

public partial class Subject
{
    public int Id { get; set; }
    [DisplayName("Ім'я")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string Name { get; set; } = null!;
    [DisplayName("Кількість годин")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public int NumberOfHours { get; set; }
    [DisplayName("Скорочення")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string Abbreviation { get; set; } = null!;

    public virtual ICollection<GroupToSubjectRelation> GroupToSubjectRelations { get; } = new List<GroupToSubjectRelation>();

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; } = new List<TeacherToSubjectRelation>();
}
