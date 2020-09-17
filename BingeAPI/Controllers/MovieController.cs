using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BingeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BingeAPI.Controllers
{
    public class MovieController : Controller
    {
        private AppDatabase _context;

        public MovieController(AppDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetMovies")]
        public List<Movie> GetMovies()
        {
            try
            {
                var movies = _context.Movie.OrderBy(m => m.ReleaseYear).ThenByDescending(m=>m.CreatedDate).ToList();
                return movies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        [HttpPost]
        [Route("AddMovie")]
        public async Task<ActionResult> AddMovie([FromBody] Movie movie)
        {
            try
            {
                movie.CreatedDate = DateTime.UtcNow;
                movie.UpdatedDate = DateTime.UtcNow;
                _context.Movie.Add(movie);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        [HttpPut]
        [Route("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie([FromBody] Movie movie)
        {
            try
            {
                var selectedMovie = _context.Movie.FirstOrDefault(m => m.MovieId == movie.MovieId);
                selectedMovie.MovieName = movie.MovieName;
                selectedMovie.UpdatedDate = DateTime.UtcNow;
                selectedMovie.UserId = movie.UserId;
                selectedMovie.Rating = movie.Rating;
                selectedMovie.ReleaseYear = movie.ReleaseYear;
                //selectedMovie.GenreId = movie.GenreId;
                selectedMovie.Description = movie.Description;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        [HttpDelete]
        [Route("DeleteMovie")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            try
            {
                var selectedMovie = _context.Movie.FirstOrDefault(m => m.MovieId == movieId);
                _context.Remove(selectedMovie);
                //var 
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
