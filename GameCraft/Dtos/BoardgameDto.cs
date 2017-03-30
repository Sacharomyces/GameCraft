using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GameCraft.Models;

namespace GameCraft.Dtos
{
    public class BoardgameDto
    {
            public int Id { get; set; }

            [Required(ErrorMessage = "Pole Wymagane")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Pole Wymagane")]
            public byte GenreId { get; set; }

            public GenreDto Genre { get; set; }

            [Range(1, 10, ErrorMessage = "Wartość pomiędzy 1 a 10")]
            public byte MinPlayerNumber { get; set; }

            [Range(1, 20, ErrorMessage = "Wartość pomiędzy 1 a 20")]
            public byte MaxPlayerNumber { get; set; }

            [Required]
            public byte InStock { get; set; }
    }
    
}