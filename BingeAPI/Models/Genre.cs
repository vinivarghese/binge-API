using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BingeAPI.Models
{
    public class Genre
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreID { get; set; }

        [Required]
        public string GenreName { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
