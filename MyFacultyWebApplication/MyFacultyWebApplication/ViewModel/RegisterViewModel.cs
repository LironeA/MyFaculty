﻿using Microsoft.DotNet.Scaffolding.Shared.Project;
using MyFacultyWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace MyFacultyWebApplication.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Рік народження")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [Display(Name = "Підтвердження Пароля")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
