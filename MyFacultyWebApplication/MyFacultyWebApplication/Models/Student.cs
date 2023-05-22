<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

namespace MyFacultyWebApplication.Models;

public partial class Student
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
    [Display(Name = "Группа")]
    public int GroupId { get; set; }
<<<<<<< HEAD

    public virtual Group ?Group { get; set; } = null!;

=======
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Статус")]
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6
    public int StatusId { get; set; }

    public virtual Status ?Status { get; set; } = null!;

    public string ?UserId { get; set; } = null!;

    public virtual User ?User { get; set; } = null!;
}
