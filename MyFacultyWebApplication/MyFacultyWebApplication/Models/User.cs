using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFacultyWebApplication.Models
{
    public class User : IdentityUser
    {
        public bool IsStudent { get; set; } 
        public DateTime Date { get; set; }

    }
}
