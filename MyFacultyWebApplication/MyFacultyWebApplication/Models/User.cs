using Microsoft.AspNetCore.Identity;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFacultyWebApplication.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }

    }
}
