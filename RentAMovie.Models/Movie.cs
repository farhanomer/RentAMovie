using System.ComponentModel.DataAnnotations.Schema;

namespace RentAMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Column(TypeName = "text")]
        public string Summary { get; set; }
        public decimal ImdbRating { get; set; }
        public int TotalRatings { get; set; }
        public int MinAgeLimit { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<MovieCopy> MovieCopyList { get; set; }
        public ICollection<MovieRent> MovieRentList { get; set; }
        public ICollection<MovieCharacter> MovieCharacterList { get; set; }
        
    }
}
