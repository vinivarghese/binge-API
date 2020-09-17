using System;
using Microsoft.EntityFrameworkCore;
namespace BingeAPI.Models
{
    public class AppDatabase : DbContext
    {
        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {

        }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<Favourites> Favourites { get; set; }
    }
}
