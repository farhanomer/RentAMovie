using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovieDTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public decimal ImdbRating { get; set; }
        [Required]
        public int TotalRatings { get; set; }
        [Required]
        public int MinAgeLimit { get; set; }
        public ICollection<GenreOnlyDTO> Genres { get; set; }
        public ICollection<MovieCopyDTO> MovieCopyList { get; set; }
        public ICollection<MovieRentDTO> MovieRentList { get; set; }
        public ICollection<MovieCharacterDTO> MovieCharacterList { get; set; }
    }
    public class MovieOnlyDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public decimal ImdbRating { get; set; }
        [Required]
        public int TotalRatings { get; set; }
        [Required]
        public int MinAgeLimit { get; set; }
    }
}
