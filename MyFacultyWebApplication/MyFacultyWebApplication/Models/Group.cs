<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;
=======
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

namespace MyFacultyWebApplication.Models;

public partial class Group
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Назва")]
    public string Name { get; set; } = null!;
    //[Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Спеціальність")]
    [Required, ForeignKey("Specialty")]
    public int SpecialtyId { get; set; }
    
    public virtual Specialty? Specialty { get; set; } = null!;

    public virtual ICollection<GroupToSpecialtyRelation> GroupToSpecialtyRelations { get; } = new List<GroupToSpecialtyRelation>();

    public virtual ICollection<GroupToSubjectRelation> GroupToSubjectRelations { get; } = new List<GroupToSubjectRelation>();

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
