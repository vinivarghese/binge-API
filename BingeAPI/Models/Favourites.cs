using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BingeAPI.Models
{
    public class Favourites
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FavouritesId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ICollection<Movie> Movie { get; set; }

        //[Required]
        //public ICollection<Movie> Movie { get; set; }
    }
}
