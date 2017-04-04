using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GameCraft.Models;
using GameCraft.ViewModels;
using Microsoft.Ajax.Utilities;


namespace GameCraft.Controllers
{
    public class BoardgameController : Controller
    {
        private ApplicationDbContext _context;

        public BoardgameController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }


        public ViewResult Index()
        {
            var boardgames = _context.Boardgames.Include(b=>b.Genre).ToList();

            if(User.IsInRole(RoleName.CanManageBoardgames))
                return View("List");
            
            
                return View("ReadOnlyList");
            
        }


        //[Route("Boardgames/Details/{id}")] - custom routing if needed

        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBoardgames)]
        public ActionResult Save(Boardgame boardgame)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BoardgamesFormViewModel(boardgame)
                {
                    Genres = _context.Genres.ToList()
                };
            
                return View("BoardgameForm", viewModel);
            }
            if (boardgame.Id == 0)
                _context.Boardgames.Add(boardgame);
            else
            {
                
                var boardgameInDb = _context.Boardgames.Single(b => b.Id == boardgame.Id);

               Mapper.Map(boardgame,boardgameInDb);
              
            }
           
           
                _context.SaveChanges();
           
           
            
            return RedirectToAction("Index","Boardgame");
        }
        [Authorize(Roles = RoleName.CanManageBoardgames)]
        public ActionResult New()
        {
            var boardgameFormViewModel = new BoardgamesFormViewModel()
            {
               
                Genres = _context.Genres.ToList()
            };

            return View("BoardgameForm",boardgameFormViewModel);
        }

        [Authorize(Roles = RoleName.CanManageBoardgames)]
        public ActionResult Edit(int id)
        {
            var boardgame = _context.Boardgames.SingleOrDefault(b => b.Id == id);

            if (boardgame == null)
                return HttpNotFound();

            var boardgameViewModel = new BoardgamesFormViewModel(boardgame)
            {
                Genres = _context.Genres.ToList()
            };


            return View("BoardgameForm",boardgameViewModel);
        }

       
        public ActionResult Details (int id)
        {

            var boardgames = _context.Boardgames;
            Boardgame boardgame = null;

            foreach (var game in boardgames)
            {
                if (game.Id == id)
                    boardgame = game;
            } 
            if (boardgame == null )
                return HttpNotFound("Gra o podanym Id nie istnieje.");

            return View(boardgame);
        }
    }
}