using System;
using fatmamba.Common;
using Microsoft.AspNetCore.Mvc;

namespace fatmamba.Controllers
{
    public class ArtistController : Controller
    {
        private readonly RedisHelper db = new RedisHelper();
        
        // GET api/Artist
        [HttpGet]
        public IActionResult Get()
        {
            var artists = db.GetArtistSet();

            return View(artists);
        }

        // GET api/Artist/{id}
        [HttpGet]
        public IActionResult Get(int id)
        {
            return View(db.GetArtist(id.ToString()));
        }

        [HttpPost]
        public IActionResult Post(Artist artist)
        {
            db.AddOrUpdateArtist(artist);
            return Ok();
        }
    }
}