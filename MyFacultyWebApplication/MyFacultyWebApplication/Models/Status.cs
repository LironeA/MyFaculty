using System.ComponentModel.DataAnnotations;

namespace MyFacultyWebApplication.Models;

public partial class Status
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Назва")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
