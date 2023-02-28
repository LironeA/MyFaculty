using System.ComponentModel.DataAnnotations;

namespace MyFacultyWebApplication.Models;

public partial class Material
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Назва")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Посилання")]
    public string Url { get; set; } = null!;
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Предмет")]
    public int SubjectId { get; set; }

    public virtual Subject Subject { get; set; } = null!;
}
