using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCraft.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana.")]
        [Display(Name = "Nazwa Użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu e-mail.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(100, ErrorMessage = "{0} musi mieć co najmniej {2} znaków długości.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdzenie Hasła")]
        [Compare("Password", ErrorMessage = "Hasło i potwierdzenie hasła nie są zgodne.")]
        public string ConfirmPassword { get; set; }
    }
}