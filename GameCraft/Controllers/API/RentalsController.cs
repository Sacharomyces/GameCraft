using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using AutoMapper;
using GameCraft.Dtos;
using GameCraft.Models;

namespace GameCraft.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult GetRentals()
        {
            var rentalsInDb =  _context.Rentals.ToList();
            

            return Ok(rentalsInDb);
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var boardgames = _context.Boardgames.Where(b => newRental.BoardgameIds.Contains(b.Id)).ToList();

            foreach ( var boardgame in boardgames)
            {
                if (boardgame.NumberAvailable == 0)
                    return BadRequest("Boardgame is not available");

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