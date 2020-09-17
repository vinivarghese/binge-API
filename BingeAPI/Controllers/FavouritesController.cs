using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BingeAPI.Models;
using System.Collections;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BingeAPI.Controllers
{
    public class FavouritesController : Controller
    {
        private AppDatabase _context;

        public FavouritesController(AppDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetFavourites")]
        public List<Favourites> GetFavourites()
        {
            try
            {
                var favourites = _context.Favourites.OrderBy(f => f.UserId).ThenByDescending(f => f.CreatedDate).ToList();
                return favourites;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        [HttpPost]
        [Route("AddFavourites")]
        public async Task<IActionResult> AddFavourites([FromBody] Favourites favourites)
        {
            try
            {
                favourites.CreatedDate = DateTime.UtcNow;
                _context.Favourites.Add(favourites);
                await _context.SaveChangesAsync();

                return CreatedAtAction("addFavourites", new { id = favourites.FavouritesId }, favourites);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        [HttpPut]
        [Route("UpdateFavourites")]
        public async Task<IActionResult> UpdateFavourites([FromBody] Favourites favourites)
        {
            try
            {
                var selectedFavourites = _context.Favourites.FirstOrDefault(f => f.FavouritesId == favourites.FavouritesId);
                //selectedFavourites.Movie = favourites.Movie;
                selectedFavourites.UpdatedDate = DateTime.UtcNow;
                selectedFavourites.UserId = favourites.UserId;

                await _context.SaveChangesAsync();

                return CreatedAtAction("updateFavourites", selectedFavourites);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}
