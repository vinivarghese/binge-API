using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BingeAPI.Models
{
    public class Movie
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string MovieName { get; set; }

        //[Required]
        //public int GenreId { get; set; }

        [Required]
        public decimal Rating { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Required]
        public string Description { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        //[Required]
        //public ICollection<Genre> Genre { get; set; }

        //[Required]
        //public ICollection<Favourites> Favourites { get; set; }
    }
}
