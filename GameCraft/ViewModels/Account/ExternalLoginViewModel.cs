using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCraft.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    
        {
            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Nazwa Użytkownika")]
            public string UserName { get; set; }
        }
    }
