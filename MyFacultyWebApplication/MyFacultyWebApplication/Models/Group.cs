using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public virtual ICollection<GroupToSubjectRelation> GroupToSubjectRelations { get; } = new List<GroupToSubjectRelation>();

    public virtual Specialty Specialty { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
