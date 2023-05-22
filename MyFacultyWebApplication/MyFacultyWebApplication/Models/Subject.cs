<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

namespace MyFacultyWebApplication.Models;
[Display(Name = "Предмет")]
public partial class Subject
{
    public int Id { get; set; }
<<<<<<< HEAD
    [DisplayName("Ім'я")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public string Name { get; set; } = null!;
    [DisplayName("Кількість годин")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    public int NumberOfHours { get; set; }
    [DisplayName("Скорочення")]
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
=======
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Назва")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Кількість годин")]
    public int NumberOfHours { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Скорочення")]
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
    public string Abbreviation { get; set; } = null!;

    public virtual ICollection<GroupToSubjectRelation> GroupToSubjectRelations { get; } = new List<GroupToSubjectRelation>();

    public virtual ICollection<TeacherToSubjectRelation> TeacherToSubjectRelations { get; } = new List<TeacherToSubjectRelation>();
}
