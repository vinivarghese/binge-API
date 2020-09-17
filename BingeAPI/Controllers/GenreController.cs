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
    public class GenreController : Controller
    {
        private AppDatabase _context;

        public  GenreController(AppDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetGenres")]
        public List<Genre> GetGenres()
        {
            try
            {
                var genres = _context.Genre.OrderBy(g => g.GenreName).ToList();
                return genres;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }

        [HttpGet]
        [Route("GetGenre/{genreId}")]
        public Genre GetGenreById(int genreId)
        {
            try
            {
                var genre = _context.Genre.FirstOrDefault(g => g.GenreID == genreId);
                return genre;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        [HttpPost]
        [Route("AddGenre")]
        public async Task<IActionResult> AddGenre([FromBody] Genre genre)
        {
            try
            {
                genre.CreatedDate = DateTime.UtcNow;
                _context.Genre.Add(genre);
                await _context.SaveChangesAsync();

                return CreatedAtAction("addGenre", new { id = genre.GenreID }, genre);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        [HttpPut]
        [Route("UpdateGenre")]
        public async Task<IActionResult> UpdateGenre([FromBody] Genre genre)
        {
            try
            {
                var selectedGenre = _context.Genre.FirstOrDefault(g => g.GenreID == genre.GenreID);
                selectedGenre.GenreName = genre.GenreName;
                selectedGenre.UpdatedDate = DateTime.UtcNow;
                selectedGenre.UserId = genre.UserId;

                await _context.SaveChangesAsync();

                return CreatedAtAction("updateGenre", selectedGenre);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}
