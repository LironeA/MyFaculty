using System.ComponentModel.DataAnnotations;

namespace MyFacultyWebApplication.Models;

public partial class TeacherToSubjectRelation
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Вчитель")]
    public int TeacherId { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Предмет")]
    public int SubjectId { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
