using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GameCraft.Dtos;
using GameCraft.Models;

namespace GameCraft.Controllers.API
{
    
        public class NewRentalsController : ApiController
        {
            private ApplicationDbContext _context;

            public NewRentalsController()
            {
                _context = new ApplicationDbContext();
            }
            [HttpPost]
            public IHttpActionResult CreateRental(RentalDto newRental)
            {
                var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

                var boardgames = _context.Boardgames.Where(b => newRental.BoardgameIds.Contains(b.Id)).ToList();

                foreach (var boardgame in boardgames)
                {
                    if (boardgame.NumberAvailable == 0)
                        return BadRequest("Movie is not available");

                    boardgame.NumberAvailable--;

                    var rental = new Rental
                    {
                        Customer = customer,
                        Boardgame = boardgame,
                        DateRented = DateTime.Now

                    };

                    _context.Rentals.Add(rental);
                }

                _context.SaveChanges();

                return Ok();
            }

        }
}