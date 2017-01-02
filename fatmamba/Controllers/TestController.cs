using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fatmamba.Common;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace fatmamba.Controllers
{
    public class TestController : Controller
    {
        // GET: /<controller>/
        public IActionResult Fun()
        {
            Artist art = new Artist
            {
                ArtistName = "Ian Philpot"
            };

            return View(art);
        }

        // GET: /<controller>/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Fun(Artist artist)
        {
            if (ModelState.IsValid)
            {
                var msg = artist.Score;
                return RedirectToAction("Success", new { message = msg });
            }

            return View(artist);
        }

        public IActionResult Success(string message)
        {
            ViewData["Message"] = "The score is: " + message;

            return View();
        }
    }
}
