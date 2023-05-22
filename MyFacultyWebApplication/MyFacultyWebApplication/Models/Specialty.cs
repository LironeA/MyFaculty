<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using MyFacultyWebApplication.Models;
=======
﻿using System.ComponentModel.DataAnnotations;
>>>>>>> 59fc604a407e294acf4cfcaf8766e2accc31f2f6

namespace MyFacultyWebApplication.Models;

public partial class Specialty
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Назва")]
    public string Name { get; set; } = null!;

    public virtual ICollection<GroupToSpecialtyRelation> GroupToSpecialtyRelations { get; } = new List<GroupToSpecialtyRelation>();
}
