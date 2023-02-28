using System.ComponentModel.DataAnnotations;

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
    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Статус")]
    public int StatusId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
