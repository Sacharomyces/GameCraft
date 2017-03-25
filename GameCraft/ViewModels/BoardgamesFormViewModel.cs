using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GameCraft.Models;

namespace GameCraft.ViewModels
{
    public class BoardgamesFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }


        [Required(ErrorMessage = "Pole Wymagane")]
        [Display(Name = "Tytuł")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole Wymagane")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "Podana wartość musi byc większa od 0")]
        [Display(Name = "Minimalna ilość gracy")]
        public byte? MinPlayerNumber { get; set; }

        [Required(ErrorMessage = "Podana wartość musi byc większa od 0")]
        [Display(Name = "Maksymalna ilość graczy")]
        public byte? MaxPlayerNumber { get; set; }

        [Range(1,20,ErrorMessage = "Wymagana ilość pomiędzy 1 a 20")]
        [Display(Name = "Dostępna ilość")]
        public byte? InStock { get; set; }



        public BoardgamesFormViewModel()
        {
            Id = 0;
        }

        public BoardgamesFormViewModel(Boardgame boardgame)
        {
            Id = boardgame.Id;
            Name = boardgame.Name;
            GenreId = boardgame.GenreId;
            MinPlayerNumber = boardgame.MinPlayerNumber;
            MaxPlayerNumber = boardgame.MaxPlayerNumber;
            InStock = boardgame.InStock;
        }
    }
}