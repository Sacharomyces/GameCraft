using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using GameCraft.Dtos;
using GameCraft.Models;

namespace GameCraft.Controllers.API
{
    public class BoardgamesController:ApiController
    {
        private ApplicationDbContext _context;

        public BoardgamesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetBoardgames()
        {
            var boardgames = _context.Boardgames.ToList().Select(Mapper.Map<Boardgame,BoardgameDto>);

            return Ok(boardgames);
        }

        public IHttpActionResult GetBoardgame(int id)
        {

            var boardgame = _context.Boardgames.SingleOrDefault(b => b.Id == id);

            if (boardgame ==null)
                return NotFound();

            var boardgameDto = Mapper.Map<Boardgame, BoardgameDto>(boardgame);

            return Ok(boardgameDto);
        }
        [HttpPost]
        public IHttpActionResult CreateBoardgame(BoardgameDto boardgameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newBoardgame = Mapper.Map<BoardgameDto, Boardgame>(boardgameDto);

            _context.Boardgames.Add(newBoardgame);
            _context.SaveChanges();

            boardgameDto.Id = newBoardgame.Id;

            return Created(new Uri(Request.RequestUri + "/" + boardgameDto.Id), boardgameDto);

        }
        [HttpPut]
        public IHttpActionResult UpdateBoardgame(int id, BoardgameDto boardgameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var boardgameInDb = _context.Boardgames.SingleOrDefault(b => b.Id == id);
            if (boardgameInDb ==null)
                return NotFound();

            Mapper.Map<BoardgameDto, Boardgame>(boardgameDto,boardgameInDb);

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteBoardgame(int id)
        {
            var boardgameInDb = _context.Boardgames.SingleOrDefault(b => b.Id == id);

            if (boardgameInDb ==null)
                return NotFound();

            _context.Boardgames.Remove(boardgameInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}