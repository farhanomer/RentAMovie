using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAMovie.DTO
{
    public class ActorDTO
    {
        public int Id;
        [Required]
        public string Name { get; set; }
        [Required]
        public string Summary { get; set; }
        public string BioDetails { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        public DateTime? DateofDeath { get; set; }
        public ICollection<MovieCharacterDTO> MovieCharacters { get; set; }
    }
}