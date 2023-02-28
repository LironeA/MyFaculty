using System.ComponentModel.DataAnnotations;

namespace MyFacultyWebApplication.Models;

public partial class GroupToSubjectRelation
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Группа")]
    public int GroupId { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Предмет")]
    public int SubjectId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
