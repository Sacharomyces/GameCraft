using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameCraft.Models;

namespace GameCraft.ViewModels
{
    public class RandomBoardgameViewModel
    {
        public Boardgame Boardgame { get; set; }
        public List<Customer> Customers { get; set; }

    }
}