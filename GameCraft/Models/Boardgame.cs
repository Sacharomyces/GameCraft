using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameCraft.Models
{
    public class Boardgame
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Wymagane")]
        [Display (Name ="Tytuł")]
        public string Name { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Pole Wymagane")]
        public byte GenreId { get; set; }

        [Range(1,10,ErrorMessage = "Wartość pomiędzy 1 a 10")]
        [Display (Name = "Minimalna ilość gracy")]
        public byte MinPlayerNumber { get; set; }
  
        [Range(1,20,ErrorMessage = "Wartość pomiędzy 1 a 20")]
        [Display(Name = "Maksymalna ilość graczy")]
        public byte MaxPlayerNumber { get; set; }

        [Required]
        [Display(Name = "Dostępna ilość")]
        public byte InStock { get; set; }
    }
}