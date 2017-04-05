using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCraft.Controllers
{
    public class RentalController : Controller
    {
        // GET: Renta
        public ActionResult New()
        {
            return View();
        }
    }
}