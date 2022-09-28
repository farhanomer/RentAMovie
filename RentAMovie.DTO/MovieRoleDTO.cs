using RentAMovieDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.DTO
{
    public class MovieRoleDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<MovieCharacterDTO> MovieCharacters { get; set; }
        
    }
}
