using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCraft.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public string Name { get; set; }
    }
}