using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovieDTO
{
    public class MovieCopyDTO
    {
        public int Id { get; set; }
        [Required]
        public Guid MovieTagNumber { get; set; }
        [Required]
        public bool IsDamaged { get; set; } = false;
        [Required]
        public int MovieId { get; set; }
        public MovieDTO Movie { get; set; }
    }
}
